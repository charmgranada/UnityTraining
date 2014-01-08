using UnityEngine;
using System.Collections;

public class SceneController_Scripts : MonoBehaviour
{
	public GameObject cubeEmpty;
	public GameObject sphere;
	public GameObject sphere_prefab;
	private GameObject cubeChild;
	
	public Material cubeColor;
	public AudioClip audioClip;
	
	private float yForce = 0.25f;
	
	private Vector3 origPosition_sphere;
	private float raycastDist = 10f;
	
	private float lowPassFactor = 0.1f;
	private float maxOffset = 2.0f;
	private Vector3 accelPrev = Vector3.zero;
	//private bool sphereCloned = false;
	//private bool lerpColor = true;
	
    private Vector3 vec;
	
	
	void Start ()
	{	
		cubeChild = cubeEmpty.GetComponentInChildren<Transform>().GetChild(0).gameObject;
		
		SceneReset.InitialState(cubeEmpty, cubeChild, cubeColor);
		
		origPosition_sphere = sphere.transform.position;
	}
	
	
	void Update ()
	{	
		if(sphere.activeSelf)
			sphere.SetActive(false);	
		
		Method_Scripts();
		
		if(SceneView_Scripts.buttonClicked && SceneModel.activeFunction != SceneModel.lerp)
			ResetSettings();
		
		//if(SceneView_Scripts.buttonClicked && SceneModel.activeFunction == SceneModel.instantiate)
			//InstantiateSphere();
		if(SceneModel.activeFunction == SceneModel.instantiate)
			InstantiateShootSphere();
		
		CheckClick();
	}
	
	
	void LateUpdate()
	{
		if(SceneModel.activeFunction == SceneModel.accelerometer)
		{
			//acceleration = "Input.acceleration: \n" + Input.acceleration;
			accelPrev = new Vector3(Input.acceleration.normalized.x, 0,0);
			
			float a = Round(Input.acceleration.x, 2);//normalized
			
			double b = (a * lowPassFactor) + (accelPrev.x * (1.0 - lowPassFactor) * maxOffset);
			Debug.Log("ACCEL: " + (float)b*maxOffset);
			
			accelPrev = new Vector3((float)b*maxOffset,0,0);
			
			cubeEmpty.transform.position = accelPrev;
		}
	}
	
	
	void InstantiateShootSphere()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);
		
		RaycastHit hit;
		
		if(Input.GetButton("Fire1"))
		{
			if(Physics.Raycast(ray.origin, ray.direction * raycastDist, out hit))
			{
				Vector3 newPos = hit.point;
				
				if(hit.point.y <= 0)
					newPos = new Vector3(hit.point.x, 0, hit.point.z);
				
				Debug.Log("HitPoint: " + newPos);
				
				GameObject g = Instantiate(sphere_prefab, newPos, Quaternion.identity) as GameObject;
				g.rigidbody.velocity = transform.TransformDirection(new Vector3(0,0,5f));
				g.rigidbody.AddForce(Vector3.forward);
			}
		}
	}
	
	
	void CheckClick ()
	{
		SceneView_Scripts.buttonClicked = false;
	}
	
	
	void ResetSettings ()
	{
		SceneReset.ResetSettings(cubeEmpty, cubeChild);
		
		sphere.transform.position = origPosition_sphere;
	}
	
	
	void InstantiateSphere ()
	{	
		// Instantiate sphere
		Instantiate(sphere_prefab, new Vector3(Random.Range(-3, 3), Random.Range(1.0f, 3.5f), Random.Range(2, -5)), Quaternion.identity);
	}
	
	
	//* Scripts *//
	void Method_Scripts ()
	{	
		if(SceneModel.activeFunction == SceneModel.reset)
			ResetSettings();
		
		// Get Button
		else if(SceneModel.activeFunction == SceneModel.getButton)
		{
			if(Input.GetButton("Horizontal"))
				MoveRotateCube(yForce);
			
			else if(Input.GetButton("Vertical"))
				MoveRotateCube(-yForce);
		}
		
		// Get Key
		else if(SceneModel.activeFunction == SceneModel.getKey)
		{
			if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) ||
				Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) ) 
				MoveRotateCube(yForce);
			
			else if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) ||
				Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) ) 
				MoveRotateCube(-yForce);
		}
		
		// Get Axis
		else if(SceneModel.activeFunction == SceneModel.getAxis)
		{
			float a = Input.GetAxis("Horizontal");
			SceneView_Scripts.axisValues = ""+a;
			
			if(SceneView_Scripts.toggleValue)
				cubeEmpty.transform.position = new Vector3(a*5.0f,0,0);
			else
				cubeEmpty.transform.Rotate(new Vector3(a*5.0f,0,0));
		}
		
		// Touch
		else if(SceneModel.activeFunction == SceneModel.touch)
		{
			float a = DetectTouch.x;
			
			Debug.Log("SceneModel.touch: " + a);
			
			if(SceneView_Scripts.toggleValue)
			{
				MoveRotateCube(-a*1.5f);
				//cubeEmpty.transform.position = new Vector3(a*5.0f,0,0);
				cubeEmpty.transform.rotation = new Quaternion(0,45f,0,0);
			}
			else
				cubeEmpty.transform.Rotate(new Vector3(a*5.0f,0,0));
		}
		
		// Accelerometer
		/*else if(SceneModel.activeFunction == SceneModel.accelerometer)
		{
			//acceleration = "Input.acceleration: \n" + Input.acceleration;
			
			float a = Round(Input.acceleration.x, 2);
			cubeEmpty.transform.position = new Vector3(a*5.0f,0,0);
		}*/
		
		// Look At
		else if(SceneModel.activeFunction == SceneModel.lookAt)
		{
			sphere.SetActive(true);
			cubeEmpty.transform.LookAt(sphere.transform);
			AnimateSphere();
		}
		
		// Destroy
		else if(SceneModel.activeFunction == SceneModel.destroy)
		{
			DestroySphere();
		}
		
		// Lerp
		else if(SceneModel.activeFunction == SceneModel.lerp)
		{	
			Color origColor = cubeChild.renderer.material.color;
		
			if(SceneView_Scripts.lerped)
			{
				cubeChild.transform.position = Vector3.Lerp(cubeChild.transform.position, new Vector3(-3,0,0), 2.0f * Time.deltaTime);
				cubeChild.renderer.material.color = Color.Lerp(origColor, Color.blue, 2.0f * Time.deltaTime);
			}
			else
			{
				cubeChild.transform.position = Vector3.Lerp(cubeChild.transform.position, new Vector3(3,0,0), 2.0f * Time.deltaTime);
				cubeChild.renderer.material.color = Color.Lerp(origColor, Color.red, 2.0f * Time.deltaTime);
			}
		}
		
	}
	
	
	void MoveRotateCube (float y)
	{
		if(SceneView_Scripts.toggleValue)
			cubeEmpty.transform.Translate(new Vector3(y,0,0));
		else
			cubeEmpty.transform.Rotate(new Vector3(0,y,0));
	}
	
	
	void AnimateSphere ()
	{
		if(sphere.transform.position.y <= 4.5f)
			sphere.transform.Translate(new Vector3(0, 1.0f, 0) * Time.deltaTime);
		if(sphere.transform.position.y >= 4.5f &&
			sphere.transform.position.x < 4.5f)
			sphere.transform.Translate(new Vector3(1.0f, 0, 0) * Time.deltaTime);
			
	}
	
	
	void DestroySphere ()
	{
		Destroy(GameObject.Find("Sphere_Rigidbody(Clone)"));
		
		//Destroy objects on where Ray is cast
		/*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);
		
		RaycastHit hit;
		
		if(Physics.Raycast(ray.origin, ray.direction * 100f, out hit))
		{
			Debug.Log(hit.collider.gameObject.name);
		}*/
	}
	
	
	float Round(float v, int digits)
	{
		float mult = Mathf.Pow(10.0f, (float)digits);
		return Mathf.Round(v * mult)/mult;
	}
	
	string TouchInfo ()
	{
		int i = 0;
		string touchPhaseStr = "";
		
		while( i < Input.touchCount)
		{
			if(Input.GetTouch(i).phase == TouchPhase.Began)
				touchPhaseStr = "TOUCH BEGAN:\n" + Input.GetTouch(i).deltaPosition;
			if(Input.GetTouch(i).phase == TouchPhase.Moved)
				touchPhaseStr = "TOUCH MOVED";//:\n" + Input.GetTouch(i).deltaPosition;
			if(Input.GetTouch(i).phase == TouchPhase.Stationary)
				touchPhaseStr = "TOUCH STATIONARY:\n" + Input.GetTouch(i).deltaPosition;
			if(Input.GetTouch(i).phase == TouchPhase.Ended)
				touchPhaseStr = "TOUCH ENDED:\n" + Input.GetTouch(i).deltaPosition;
			
			++i;
		}
		
		
		//Debug.Log(touchPhaseStr);
		return touchPhaseStr;
		
	}
	
}
