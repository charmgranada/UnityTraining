using UnityEngine;
using System.Collections;

public class SceneController_Physics : MonoBehaviour
{
	public GameObject sphere_forcetorque;
	public GameObject sphere_phymanager;
	public GameObject boxDrop;
	public GameObject slidingDoor;
	public GameObject springObj1;
	
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
	
	enum PhysicsState
	{
		isReset = 0,
	    isCollision = 1,
		isTrigger = 2,
		isRigidBody = 3,
		isForce,
		isTorque,
		isPhyMaterials,
		isJointHinge,
		isJointSpring,
		isRaycast,
		isPhyManager
	}
	
	
	
	void Start ()
	{	
		origPosition_sphere_forcetorque = sphere_forcetorque.transform.position;
		origPosition_sphere_phymanager = sphere_phymanager.transform.position;
		origPosition_boxdrop = boxDrop.rigidbody.transform.position;
		origPosition_slidingDoor = slidingDoor.rigidbody.transform.position;
		origRotation_slidingDoor = slidingDoor.rigidbody.transform.rotation;
		
		SceneModel.activeFunction = SceneModel.reset;
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
	
	
	void ResetObjectState (PhysicsState state)
	{
		HideAll();
		
		switch (state)
		{
			case PhysicsState.isReset:
			{
				Debug.Log("RESET");
			}
			break;
			
			// Collision / Trigger
			case PhysicsState.isCollision:
			case PhysicsState.isTrigger:
			{
				demo_collisiontrigger.SetActive(true);
			}
			break;
			
			// Force / Torque
			case PhysicsState.isForce:
			case PhysicsState.isTorque:
			{
				demo_forcetorque.SetActive(true);
			}
			break;
			
			// Physic Material
			case PhysicsState.isPhyMaterials:
			{
				demo_phyMaterials.SetActive(true);
			}
			break;
			
			// Joints - Hinge
			case PhysicsState.isJointHinge:
			{
				demo_jointHinge.SetActive(true);
			}
			break;
			
			// Joints - Spring
			case PhysicsState.isJointSpring:
			{
				foreach(Transform t in demo_jointSpring.transform)
				{
					t.renderer.enabled = true;
				}
				showJoints = true;
			}
			break;
			
			// Raycast
			case PhysicsState.isRaycast:
			{
				demo_raycast.SetActive(true);
			}
			break;
			
			// Physics Manager
			case PhysicsState.isPhyManager:
			{
				demo_phyManager.SetActive(true);
			}
			break;
			
		}
	}
	
	void HideAll ()
	{
		Debug.Log("HIDE ALL");
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
		if(!isClicked)
		{	
			if(SceneModel.activeFunction != SceneModel.reset && SceneModel.activeFunction != null)
			{
				EnableClick(true);
			}
			
			// Reset
			if(SceneModel.activeFunction == SceneModel.reset)
			{
				ResetObjectState(PhysicsState.isReset);
			}
			
			// Colliders
			else if(SceneModel.activeFunction == SceneModel.colliders)
			{
				ResetObjectState(PhysicsState.isCollision);
			}
			
			// Triggers
			else if(SceneModel.activeFunction == SceneModel.triggers)
			{
				ResetObjectState(PhysicsState.isTrigger);
			}
			
			// RigidBodies
			else if(SceneModel.activeFunction == SceneModel.rigidbodies)
			{
				ResetObjectState(PhysicsState.isRigidBody);
			}
			
			// Physic Material
			else if(SceneModel.activeFunction == SceneModel.physicsMatl)
			{
				ResetObjectState(PhysicsState.isPhyMaterials);
			}
			
			// Joint - Hinge
			else if(SceneModel.activeFunction == SceneModel.jointHinge)
			{
				ResetObjectState(PhysicsState.isJointHinge);
			}
			
			// Joint - Spring
			else if(SceneModel.activeFunction == SceneModel.jointSpring)
			{
				ResetObjectState(PhysicsState.isJointSpring);
			}
			
			// Raycast
			else if(SceneModel.activeFunction == SceneModel.raycasting)
			{
				ResetObjectState(PhysicsState.isRaycast);
			}
			// Physics Manager
			else if(SceneModel.activeFunction == SceneModel.physicsMgr)
			{
				ResetObjectState(PhysicsState.isPhyManager);
			}
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
				collisionLog = "\nAxis: " + x;
			}
			
			Debug.Log("isTouchEnabled: " + isTouchEnabled + "| x: " + x);
			
			// AddForce
			if(SceneModel.activeFunction == SceneModel.addForce)
			{
				ResetObjectState(PhysicsState.isForce);
				
				demo_forcetorque.rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
				demo_forcetorque.rigidbody.AddForce(Vector3.right * x * 20.0f);
			}
			// AddTorque
			else if(SceneModel.activeFunction == SceneModel.addTorque)
			{
				ResetObjectState(PhysicsState.isTorque);
				
				if(isTouchEnabled)
					x *= -1;
				
				demo_forcetorque.rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotationX;
				demo_forcetorque.rigidbody.AddTorque(Vector3.up * x * 20.0f);
			}
		}
	}
	
	
	void EnableClick (bool enable)
	{
		isClicked = enable;
	}
}
