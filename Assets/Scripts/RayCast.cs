using UnityEngine;
using System.Collections;

public class RayCast : MonoBehaviour
{
	
	// Update is called once per frame
	void Update ()
	{	
		/*RaycastHit hit;
		
		Ray ray = new Ray(gameObject.transform.position, Vector3.right);
	
		if(Physics.Raycast(ray.origin, ray.direction, out hit, 2.0f))
			Debug.Log("HIT: " + hit.collider.gameObject.name);
		
		Debug.DrawRay(ray.origin, ray.direction * 2.0f, Color.red);*/
		
		RayCastSample();
	}
	
	void RayCastSample()
	{
		Ray ray = new Ray(transform.position, Vector3.forward);
		Debug.DrawRay(ray.origin, ray.direction * 2.0f, Color.red);
		
		if(Input.GetButton("Fire1"))
		{
			
			if(Physics.Raycast(ray.origin, ray.direction, 1000))
			{
				Debug.Log("RAY CAST hit detected");
			}
			else
				Debug.Log("RAY CAST hit NOT detected");
		}
	}
}
