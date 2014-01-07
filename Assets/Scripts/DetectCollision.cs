using UnityEngine;
using System.Collections;

public class DetectCollision : MonoBehaviour
{	
	void OnCollisionEnter(Collision c)
	{
		SceneController_Physics.collisionLog = "Collision Enters the:\n" + c.gameObject.name;
		//Debug.Log("Collision Enter: " + c);
	}
		
	
	void OnCollisionStay(Collision c)
	{
		SceneController_Physics.collisionLog = "Collision Stays on the:\n" + c.gameObject.name;
		//Debug.Log("Collision Stays: " + c);
	}
	
	
	void OnCollisionExit(Collision c)
	{
		SceneController_Physics.collisionLog = "Collision Exits the:\n" + c.gameObject.name;
		//Debug.Log("Collision Exit: " + c);
	}
}
