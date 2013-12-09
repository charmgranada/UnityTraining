using UnityEngine;
using System.Collections;


public class SceneView_Scripts : SceneView
{
	public static bool buttonClicked = false;
	public static bool lerped = false;
	public static bool instantiated = false;
	
	void Start ()
	{
		setBox(new Rect(180,20,400,300));
		
		SceneModel.InitScriptActions();
		setArrCount();
	}
	
	
	public override void OnGUI ()
	{
		base.OnGUI();

		
		// Toggle
		string toggleText = toggleValue ? " Move" : " Rotate";
		toggleValue = GUI.Toggle(toggleRect, toggleValue, new GUIContent(toggleText), guiSkin.toggle);
		
		
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
			buttonClicked = true;
			isGetAxis = false;
			
			GUI.FocusControl(buttonText);
			
			if(buttonText == SceneModel.getButton)
			{
				codeText = "if (Input.GetButton\"Horizontal\")\n{\n\n" +
							"	// code\n	// change Input Name\n" +
							"	// Horizontal keys: right/left/A/D\n" +
							"	// Vertical keys: up/down/W/S\n\n}";
			}
			else if(buttonText == SceneModel.getKey)
			{
				codeText = "if (Input.GetKey(KeyCode.A))\n{\n\n" +
							"	// code\n		// change KeyCode\n\n}";
			}
			else if(buttonText == SceneModel.getAxis)
			{
				isGetAxis = true;
				codeText = "float a = Input.GetAxis(\"Horizontal\");\n\n" +
							"// float value returns to 0\n";
			}
			else if(buttonText == SceneModel.touch)
			{	
				codeText = "Input.touches\n\n" +
					"    - retrieve status of each finger\n" +
					"touching the screen during the last frame\n\n" +
					"Phases:\n" +
					"Began/Moved/Stationary/\n" +
					"Ended/Canceled";
			}
			else if(buttonText == SceneModel.accelerometer)
			{
				codeText = DetectTouch.acceleration;
			}
			else if(buttonText == SceneModel.lookAt)
			{
				codeText = "gameObject.transform.LookAt\n" +
							"(targetGameObject.transform)";
			}
			else if(buttonText == SceneModel.instantiate)
			{
				codeText = "Instantiate (gameObject, Vector3, Quaternion)";
				
				instantiated = !instantiated;
			}
			else if(buttonText == SceneModel.destroy)
			{
				codeText = "Destroy (gameObject)";
			}
			else if(buttonText == SceneModel.lerp)
			{
				codeText = "Lerp (Vector3, Mathf, Color...)\n\n" +
					"gameObject.transform.position = \nVector3.Lerp(from, to, time);";
				
				lerped = !lerped;
			}
			
			
			// Set Active Function
			SceneModel.activeFunction = buttonText;
		}
		
		return buttonText;
	}
	
}
