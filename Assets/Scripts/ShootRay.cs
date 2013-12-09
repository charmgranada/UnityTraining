using UnityEngine;
using System.Collections;

public class ShootRay : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		Debug.Log("SHOOT");
	}
	
	// Update is called once per frame
	void Update () {
	
		ShootRayCast();
	}
	
	
	void ShootRayCast ()
	{
		if(Input.GetMouseButtonDown(0))
		{	
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
			if(Physics.Raycast(ray, out hit))
			{
				if(hit.collider.gameObject.tag == "doorframe")
				{
					rigidbody.AddForce(Vector3.forward * 100);
					Debug.Log(Vector3.forward * 100);
				}
			}
		}
	}
}
