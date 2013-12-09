using UnityEngine;
using System.Collections;


public class SceneView_iTween : SceneView
{
	void Start ()
	{
		setBox(new Rect(200,20,420,300));
		
		SceneModel.InitiTweens();
		setArrCount();
	}
	
	
	public override void OnGUI ()
	{
		base.OnGUI();
		
		
		// Text Area
		GUI.Box(boxRect, new GUIContent(codeText), guiSkin.box);
		
		
		// List Actions as GUI Buttons
		for(int i = 0; i < arrCount; i++)
		{
			string buttonText = SceneModel.arrList[i];
				
			GUI.SetNextControlName(buttonText);
				
			buttonCustom(buttonText, 15.0f, yHeight * i + ySpace);
		}
	}
	
	
	string buttonCustom (string buttonText, float xPos, float yPos)
	{
		if(GUI.Button(new Rect(xPos, yPos, 130, 50), buttonText))
		{
			GUI.FocusControl(buttonText);
			
			if(buttonText == SceneModel.reset)
			{
				codeText = "RESET";
			}
			else if(buttonText == SceneModel.fadeTo)
			{
				codeText = "iTween.FadeTo (gameObject,\n" +
					"iTween.Hash(\"alpha\", 0.2f, \"time\", 2.0f));\n" +
					"\n// will work on Transparent Material only";
			}
			else if(buttonText == SceneModel.moveTo)
			{
				codeText = "iTween.MoveTo (gameObject,\n" +
					"iTween.Hash(\"position\", new Vector3(3,0,0),\n" +
					"\"time\", 2.0f))";
			}
			else if(buttonText == SceneModel.scaleTo)
			{
				codeText = "iTween.ScaleTo(cubeChild,\niTween.Hash(\"y\", 10, \"time\", 2.0));";
			}
			else if(buttonText == SceneModel.rotateTo)
			{
				codeText = "iTween.RotateTo (gameObject,\n" +
					"iTween.Hash(\"rotation\", new Vector3(0,180,0),\n" +
					"\"time\", 2.0f))";
			}
			else if(buttonText == SceneModel.rotateBy)
			{
				codeText = "iTween.RotateBy (gameObject,\n" +
					"iTween.Hash(\"y\", 1.0f,\"time\", 4.0f))";
			}
			else if(buttonText == SceneModel.colorTo)
			{
				codeText = "iTween.ColorTo(cubeChild, iTween.Hash(\n" +
					"\"r\", 0, \"g\", 0.5f, \"b\", 1, \"delay\", 0.5, \"time\", 1.0));";
			}
			else if(buttonText == SceneModel.shakePosition)
			{
				codeText = "iTween.ShakePosition(gameObject, \n" +
					"iTween.Hash(\"y\", -0.5, \"time\", 1.0, \"delay\", 1.0));";
			}
			else if(buttonText == SceneModel.punchPosition)
			{
				codeText = "iTween.PunchPosition(cubeChild, \n" +
					"iTween.Hash(\"y\", -2, \"time\", 3.0, \"delay\", 1.5));";
			}
			else if(buttonText == SceneModel.stab)
			{
				codeText = "// Plays an Audio File based on \n" +
					"// source & delay supplied\n\n" +
					"iTween.Stab(cubeChild, iTween.Hash(\n" +
					"\"delay\", 1.5, \"time\", 3.0, \"audioclip\", audioClip));";
			}
			
			// Set Active Function
			SceneModel.activeFunction = buttonText;
		}
			
		
		return buttonText;
	}
}
