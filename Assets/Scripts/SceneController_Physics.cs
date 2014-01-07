using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneController_Physics : MonoBehaviour
{
	public GameObject sphere_forcetorque;
	public GameObject sphere_phymanager;
	public GameObject boxDrop;
	public GameObject slidingDoor;
	public GameObject springObj1;
	public GameObject sphere_prefab;
	
	// Spring Joints
	public GameObject springObj2;
	
	private Vector3 origPosition_sphere_forcetorque;
	private Vector3 origPosition_sphere_phymanager;
	private Vector3 origPosition_boxdrop;
	private Vector3 origPosition_slidingDoor;
	private Quaternion origRotation_slidingDoor;
	
	// Demo
	public GameObject demo_collisiontrigger;
	public GameObject demo_forcetorque;
	public GameObject demo_phyMaterials;
	public GameObject demo_jointHinge;
	public GameObject demo_jointSpring;
	public GameObject demo_raycast;
	public GameObject demo_phyManager;	
	
	public static string collisionLog;
	//public static string triggerLog;
	
	private bool isClicked = false;
	private bool showJoints = true;
	private bool isTouchEnabled;
	
	Dictionary<string,string> functionDictionary = new Dictionary<string, string>();
	private string activeFunction = "activeFunction";
	
	
	
	void Start ()
	{	
		origPosition_sphere_forcetorque = sphere_forcetorque.transform.position;
		origPosition_sphere_phymanager = sphere_phymanager.transform.position;
		origPosition_boxdrop = boxDrop.rigidbody.transform.position;
		origPosition_slidingDoor = slidingDoor.rigidbody.transform.position;
		origRotation_slidingDoor = slidingDoor.rigidbody.transform.rotation;
		
		SceneModel.activeFunction = SceneModel.reset;
		
		BulletManager.AddObjectPool();
	}
	
	
	void Update ()
	{
		if(SceneModel.activeFunction == SceneModel.reset)
			ResetSettings();
		
		Method_Physics();
		
		if(DetectTouch.touchCount > 0)
			isTouchEnabled = true;
		else
			isTouchEnabled = false;
	}
	
	
	void ResetSettings ()
	{
		sphere_forcetorque.rigidbody.transform.position = origPosition_sphere_forcetorque;
		sphere_forcetorque.rigidbody.velocity = Vector3.zero;
		
		sphere_phymanager.rigidbody.transform.position = origPosition_sphere_phymanager;
		sphere_phymanager.rigidbody.velocity = Vector3.zero;
		
		boxDrop.rigidbody.transform.position = origPosition_boxdrop;
		boxDrop.rigidbody.velocity = Vector3.zero;
		
		slidingDoor.rigidbody.transform.position = origPosition_slidingDoor;
		slidingDoor.rigidbody.transform.rotation = origRotation_slidingDoor;
		slidingDoor.rigidbody.velocity = Vector3.zero;
		
		EnableClick(false);
	}
	
	
	void ResetObjectState (string activeFunc)
	{
		HideAll();
		Debug.Log("active: " + activeFunc);
		
		switch (activeFunc)
		{
			case SceneModel.reset:
			{
				Debug.Log("RESET");
			}
			break;
			
			// Collision / Trigger
			case SceneModel.colliders:
			case SceneModel.triggers:
			{
				demo_collisiontrigger.SetActive(true);
			}
			break;
			
			// Force / Torque
			case SceneModel.addForce:
			case SceneModel.addTorque:
			{
				demo_forcetorque.SetActive(true);
			}
			break;
			
			// Physic Material
			case SceneModel.physicsMatl:
			{
				demo_phyMaterials.SetActive(true);
			}
			break;
			
			// Joints - Hinge
			case SceneModel.jointHinge:
			{
				demo_jointHinge.SetActive(true);
			}
			break;
			
			// Joints - Spring
			case SceneModel.jointSpring:
			{
				foreach(Transform t in demo_jointSpring.transform)
				{
					t.renderer.enabled = true;
				}
				showJoints = true;
			}
			break;
			
			// Raycast
			case SceneModel.raycasting:
			{
				demo_raycast.SetActive(true);
				InstantiateShootSphere();
			}
			break;
			
			// Physics Manager
			case SceneModel.physicsMgr:
			{
				demo_phyManager.SetActive(true);
			}
			break;
		}
	}
	
	
	void HideAll ()
	{
		//Debug.Log("HIDE ALL");
		demo_collisiontrigger.SetActive(false);
		demo_forcetorque.SetActive(false);
		demo_phyMaterials.SetActive(false);
		demo_jointHinge.SetActive(false);
		if(showJoints)
		{
			foreach(Transform t in demo_jointSpring.transform)
			{
				t.renderer.enabled = false;
			}	
			showJoints = false;
		}
		demo_raycast.SetActive(false);
		demo_phyManager.SetActive(false);
	}
	
	
	//* Physics *//
	void Method_Physics ()
	{
		functionDictionary[activeFunction] = SceneModel.activeFunction;
		Debug.Log("FunctionDICTIONARY: " + functionDictionary[activeFunction]);
			
		if(!isClicked)
		{	
			if(SceneModel.activeFunction != SceneModel.reset && SceneModel.activeFunction != null)
			{
				EnableClick(true);
			}
			
			ResetObjectState(functionDictionary[activeFunction]);
		}
		else
		{
			EnableClick(false);
			
			float x;
			
			if(isTouchEnabled)
			{
				x = DetectTouch.x;
				collisionLog = "\nTouch: " + x;
			}
			else
			{
				x = Input.GetAxis("Horizontal");
				collisionLog = "";//"\nAxis: " + x;
			}
			
			//Debug.Log("isTouchEnabled: " + isTouchEnabled + "| x: " + x);
			
			// AddForce
			if(SceneModel.activeFunction == SceneModel.addForce)
			{
				ResetObjectState(functionDictionary[activeFunction]);
				
				demo_forcetorque.rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
				demo_forcetorque.rigidbody.AddForce(Vector3.right * x * 30.0f);
			}
			// AddTorque
			else if(SceneModel.activeFunction == SceneModel.addTorque)
			{
				ResetObjectState(functionDictionary[activeFunction]);
				
				if(isTouchEnabled)
					x *= -1;
				
				demo_forcetorque.rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX;
				demo_forcetorque.rigidbody.AddTorque(Vector3.up * x * 30.0f);
			}
		}
	}
	
	
	void InstantiateShootSphere()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);
		
		RaycastHit hit;
		
		if(Input.GetButton("Fire1"))
		{
			if(Physics.Raycast(ray.origin, ray.direction * 100f, out hit))
			{
				Vector3 newPos = hit.point;
				
				if(hit.point.y <= 0)
					newPos = new Vector3(hit.point.x, 0, hit.point.z);
				
				//Debug.Log("HitPoint: " + newPos);
				
				BulletManager.ActivateProjectiles(newPos);
				
				StartCoroutine(Deactivate(BulletManager.index));
				
				// Not Using Object Pooling
				/*GameObject sphere = Instantiate(sphere_prefab, newPos, Quaternion.identity) as GameObject;
				sphere.rigidbody.velocity = transform.TransformDirection(new Vector3(0,0,5f));
				sphere.rigidbody.AddForce(Vector3.forward);
				Destroy(sphere, 1.0f);*/
			}
		}
	}
	
	IEnumerator Deactivate(int index)
	{
		yield return new WaitForSeconds(1.0f);
		BulletManager.DeactivateProjectile(index);
	}
	
	void EnableClick (bool enable)
	{
		isClicked = enable;
	}
}
