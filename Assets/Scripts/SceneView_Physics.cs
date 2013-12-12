using UnityEngine;
using System.Collections;


public class SceneView_Physics : SceneView
{
	void Start ()
	{
		setBox(new Rect(200,26,420,320));
		setYHeight(54.0f);
		
		SceneModel.InitPhysics();
		setArrCount();
		
		ResetView();
	}
	
	
	public override void OnGUI ()
	{
		base.OnGUI();
		
		// Toggle
		//string toggleText = toggleValue ? " Show Box" : " Hide Box";
		//toggleValue = GUI.Toggle(toggleRect, toggleValue, new GUIContent(toggleText), guiSkin.toggle);
		
		// List Actions as GUI Buttons
		for(int i = 0; i < arrCount; i++)
		{
			string buttonText = SceneModel.arrList[i];
			
			GUI.SetNextControlName(buttonText);
				
			buttonCustom (buttonText, 15.0f, yHeight * i + ySpace);
		}
	}
	
	
	string buttonCustom (string buttonText, float xPos, float yPos)
	{
		if(GUI.Button(new Rect(xPos, yPos, 130, 50), buttonText))
		{
			isGetAxis = false;
			
			GUI.FocusControl(buttonText);
			
			if(buttonText == SceneModel.reset)
			{
				codeText = "RESET";
			}
			else if(buttonText == SceneModel.colliders)
			{
				codeText = "COLLIDERS:\n" +
					"     - OnCollisionEnter ()\n" +
					"     - OnCollisionStay ()\n" +
					"     - OnCollisionExit ()\n\n" +
					"     --> takes a Collision parameter\n\n" +
					"<i>* Sphere collides with table</i>";
			}
			else if(buttonText == SceneModel.triggers)
			{
				codeText = "TRIGGERS:\n" +
					"     - OnTriggerEnter ()\n" +
					"     - OnTriggerStay ()\n" +
					"     - OnTriggerExit ()\n\n" +
					"     --> takes a Collider parameter\n\n" +
					"<i>* Sphere hits trigger on the ground object\n(passes through)</i>";
			}
			else if(buttonText == SceneModel.rigidbodies)
			{
				codeText = "* mass: weight of object\n" +
					"* drag: inertia to slow things / air resistance\n" +
					"* velocity: speed & direction of motion\n\n" +
					"- move by 'force' & 'torque' (not transform)\n\n\n" +
					"* STATIC Colliders\n\n" +
					"* DYNAMIC Colliders (with rigidbody)\n\n" +
					"* Triggers (pass through)";
			}
			else if(buttonText == SceneModel.addForce)
			{
				codeText = "ADDFORCE:\n\n" +
					"     rigidbody.AddForce(Vector3.forward * 100);\n\n" +
					"<i>* Swipe Right/Left to apply Force</i>";
			}
			else if(buttonText == SceneModel.addTorque)
			{
				codeText = "ADDTORQUE:\n\n" +
					"float h = Input.GetAxis(\"Horizontal\") \n" +
					"           * amount * Time.deltaTime;\n\n" +
					"float v = Input.GetAxis(\"Vertical\") \n" +
					"           * amount * Time.deltaTime;\n\n\n" +	
					"rigidbody.AddTorque(Vector3.up  * h);\n" +
					"rigidbody.AddTorque(Vector3.right * v);\n\n" +
					"<i>* Swipe Right/Left to apply Torque</i>";
			}
			else if(buttonText == SceneModel.physicsMatl)
			{
				codeText = "PHYSICS MATERIAL:\n" +
					"     // controls the surface of an object\n" +
					"     and how it responds to other\n\n" +
					"* Dynamic Friction: while object is moving\n\n" +
					"* Static Friction: force to move the object\n" +
					"from a static position\n\n" +
					"<i>* Box physic material = 0 friction (slippery)</i>";
			}
			else if(buttonText == SceneModel.jointHinge || buttonText == SceneModel.jointSpring)
			{
				codeText = "JOINTS:\n" +
				 	"     - locks a gameobject to a point in the world,\n" +
					"     or to a connected rigidbody\n\n" +
					"* Fixed Joint: fixed position\n\n" +
					"* Hinge Joint: connects 2 rigidbodies (ex. door)\n\n" +
					"* Spring Joint: connects 2 rigidbodies\n" +
					"                like connected to a spring\n\n" +
					"* The hinge will rotate at the point \n" +
					"specified by the Anchor property,\n" +
					"moving around the specified Axis property";
			}
			else if(buttonText == SceneModel.raycasting)
			{
				codeText = "RAYCASTING:\n\n" +
					"     - process of using an invisible ray\n\n" +
					"Physics.RayCast\n" +
					"(Vector3 origin, Vector3 direction,\n" +
					"RayCastHit hitInfo, float distance, int layerMask);\n\n\n" +
					"<i>* draw line will show on Scene View only</i>\n\n" +
					"<i>* ex. shoots sphere bullets on where ray is casted</i>";
			}
			else if(buttonText == SceneModel.physicsMgr)
			{
				codeText = "Layer Collision Matrix\n\n" +
					"     - defines how the layer-based\n" +
					"       collision detection system will behave.\n\n" +
					"     - which layers on the Collision Matrix\n" +
					"       will interact with the other layers\n\n" +
					"<i>* Edit > Project Settings > Physics (settings)</i>";
			}
			
			// Set Active Function
			SceneModel.activeFunction = buttonText;
		}
		
		return buttonText;
	}
}
