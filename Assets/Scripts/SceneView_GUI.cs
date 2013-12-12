﻿using UnityEngine;
using System.Collections;


public class SceneView_GUI : SceneView
{
	void Start ()
	{
		//new Rect(
		setBox(new Rect(520,20,420,360));
		
		SceneModel.InitGUI();
		setArrCount();
		
		ResetView();
	}
	
	
	public override void OnGUI ()
	{
		base.OnGUI();
		
		// Text Area
		GUI.Box(boxRect, new GUIContent(codeText));
	}
}
