using UnityEngine;
using System.Collections;

public class DetectTouch : MonoBehaviour {
	
	public static int touchCount = 0;
	public static string touchPhase;
	public static string acceleration;
	
	public static float x;
		
		
	// Update is called once per frame
	void Update () {
		
		// Accelerometer
		if(SceneModel.activeFunction == SceneModel.accelerometer)
		{
			acceleration = "Input.acceleration: \n" + Input.acceleration;
		}
		
	
		// Touch
		else if(SceneModel.activeFunction == SceneModel.touch)
		{
			touchCount = Input.touchCount;
			
			TouchInfos();
			
			TouchSwipe();
		}
		
		
		// Touch Swipe
		else
		{
			touchCount = Input.touchCount;
			
			TouchSwipe();
		}
	}
	
	
	void TouchSwipe ()
	{
		int i = 0;
		
		while( i < Input.touchCount)
		{
			//if(Input.GetTouch(i).phase == TouchPhase.Began)
				//touchPhase = "TOUCH BEGAN:\n" + Input.GetTouch(i).deltaPosition;
			if(Input.GetTouch(i).phase == TouchPhase.Moved && Input.GetTouch(i).phase != TouchPhase.Stationary)
				x = Input.GetTouch(i).deltaPosition.x * 0.01f;// * Time.deltaTime;
			//if(Input.GetTouch(i).phase == TouchPhase.Ended)
				//x = 0;
			
			++i;
		}
		
		Debug.Log("TouchSwipe: " + x);
	}
	
	
	void TouchInfos ()
	{
		int i = 0;
		
		while( i < Input.touchCount)
		{
			if(Input.GetTouch(i).phase == TouchPhase.Began)
				touchPhase = "TOUCH BEGAN:\n" + Input.GetTouch(i).deltaPosition;
			if(Input.GetTouch(i).phase == TouchPhase.Moved)
				touchPhase = "TOUCH MOVED:\n" + Input.GetTouch(i).deltaPosition;
			if(Input.GetTouch(i).phase == TouchPhase.Stationary)
				touchPhase = "TOUCH STATIONARY:\n" + Input.GetTouch(i).deltaPosition;
			if(Input.GetTouch(i).phase == TouchPhase.Ended)
				touchPhase = "TOUCH ENDED:\n" + Input.GetTouch(i).deltaPosition;
			
			++i;
		}
		
		//Debug.Log(touchPhase);
	}
}
