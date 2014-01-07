using UnityEngine;
using System.Collections;

public class SceneView : MonoBehaviour
{
	public float yHeight = 60.0f;
	public float ySpace = 32.0f;
	
	public GUISkin guiSkin;
	
	public Rect boxRect;
	public Rect labelRect = new Rect(184,200,300,50);
	
	public Rect toggleRect;
	public static bool toggleValue = true;
	
	public static string codeText;
	public bool isGetAxis = false;
	public static string axisValues;
	
	public int arrCount;
	
	
	public virtual void setYHeight(float y)
	{
		yHeight = y;
	}
	
	
	public virtual void setBox(Rect boxRectSize)
	{
		boxRect = boxRectSize;
	}
	
	
	public void setArrCount ()
	{
		arrCount = 0;
		
		arrCount = SceneModel.arrList.Count;
	}
	
	public void ResetView ()
	{
		SceneModel.activeFunction = SceneModel.reset;
		codeText = "";
		//Debug.Log("ACTIVE: " + SceneModel.activeFunction);
	}
	
	void Update ()
	{
		if(SceneModel.activeFunction == SceneModel.accelerometer)
		{
			codeText = DetectTouch.acceleration;//SceneController_Scripts.acceleration;
		}
	}
	
	
	public virtual void OnGUI ()
	{
		GUI.skin = guiSkin;
		
		// Text Area
		GUI.Box(boxRect, new GUIContent(codeText), guiSkin.box);

		
		// Update Axis Values if GetAxis
		if(isGetAxis)
			GUI.Label(labelRect, "axis: "+axisValues);
		
		
		// Exit Button
		//if(GUI.Button(new Rect(10, 5, 70, 20), "BACK", customExit()))
		if(GUI.Button(new Rect(600, 20, 100, 50), "BACK", customExit()))
		//if(GUI.Button(new Rect(842, 575, 100, 50), "BACK", customExit()))
		{
			SceneModel.LoadMainScene();
		}
	}
	
	
	public GUIStyle customExit ()
	{
		GUIStyle buttonstyle = new GUIStyle(GUI.skin.button);
		buttonstyle.fontSize = 18;
		buttonstyle.fontStyle = FontStyle.BoldAndItalic;
		buttonstyle.onNormal.textColor = Color.yellow;
		buttonstyle.normal.textColor = Color.yellow;
		buttonstyle.hover.textColor = Color.cyan;
		
		return buttonstyle;
	}
}
