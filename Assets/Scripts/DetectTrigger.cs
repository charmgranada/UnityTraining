using UnityEngine;
using System.Collections;

public class DetectTrigger : MonoBehaviour
{
	void OnTriggerEnter (Collider collider)
	{
		SceneController_Physics.collisionLog = collider.gameObject.name + " Enters trigger";
		Debug.Log("Object Enters Trigger:\n" + collider);
		
		//hideObject.SetActive(false);
	}
	
	
	void OnTriggerStay (Collider collider)
	{
		SceneController_Physics.collisionLog = collider.gameObject.name + " Stays on trigger";
		Debug.Log("Object Stays onTrigger:\n" + collider);
	}
	
	
	void OnTriggerExit (Collider collider)
	{
		SceneController_Physics.collisionLog = collider.gameObject.name + " Exits trigger";
		Debug.Log("Object Exits Trigger:\n" + collider);
		
		//hideObject.SetActive(true);
	}
}


