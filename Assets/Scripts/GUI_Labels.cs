using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GUI_Labels : MonoBehaviour
{
	public GUIText gameObjPosition;
	public GUIText touchPhase;
	public GUIText statusLog;
	
	public GUIText timerText;
	private float timer;
	
	public GameObject cube;
	
	private bool isTimer = false;
	private bool isTouch = false;
	private bool isStatusLog = false;
	
	
	void Start ()
	{
		if(timerText) 
			isTimer = true;
		
		if(touchPhase) 
			isTouch = true;
		
		if(statusLog)
			isStatusLog = true;
	}
	
	
	void Update ()
	{
		if(cube)
			gameObjPosition.text = "Position: " + cube.transform.position.ToString();
		
		if(isTimer)
			ComputeTimer();
		
		if(isTouch)
			DetectTouchFunc();
		
		if(isStatusLog)
			StatusLog();
	}
	
	
	void ComputeTimer ()
	{
		timer += Time.deltaTime;
		
		int minutes = Mathf.FloorToInt(timer / 60.0f);
	    int seconds = Mathf.FloorToInt(timer - minutes * 60.0f);
	 
	    string formatTime = string.Format("{0:0}:{1:00}", minutes, seconds);
		
		timerText.text = "Timer: " + formatTime;
	}
	
	
	void DetectTouchFunc ()
	{
		if(SceneModel.activeFunction == SceneModel.touch)
			touchPhase.text = "TouchPhase: " + DetectTouch.touchPhase + //SceneController_Scripts.touchPhase + 
							"\n\n\nTouchCount: " + DetectTouch.touchCount; //SceneController_Scripts.touchCount;
		else
			touchPhase.text = "TouchPhase:";
	}
	
	
	void StatusLog ()
	{
		statusLog.text = "" + SceneController_Physics.collisionLog;
	}
	
}
