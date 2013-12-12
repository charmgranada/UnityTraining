using UnityEngine;
using System.Collections;


public class SceneView_NGUI : SceneView
{
	void Start ()
	{
		//new Rect(
		//setBox(new Rect(20,20,420,360));
		
		SceneModel.InitGUI();
		setArrCount();
		
		ResetView();
	}
	
	public override void OnGUI ()
	{
		base.OnGUI();
		
		// Text Area
		//GUI.Box(boxRect, new GUIContent(codeText));
	}
}
