using UnityEngine;
using System.Collections;

public class SceneController_iTween : MonoBehaviour
{
	public 	GameObject cubeEmpty;
	private GameObject cubeChild;
	
	private Hashtable hashtable = new Hashtable();
	
	public Material  cubeColor;
	public AudioClip audioClip;
	
	private bool isClicked = false;
	
	
	
	void Start ()
	{
		cubeChild = cubeEmpty.GetComponentInChildren<Transform>().GetChild(0).gameObject;
		
		SceneReset.InitialState(cubeEmpty, cubeChild, cubeColor);
		
		iTween.Init(cubeChild);
			
		hashtable = iTween.Hash
		(
			"alpha", 0.0f,
			"time", 2.0f,
			"rotation", new Vector3(0,270,0),
			//"looptype", "pingpong",
			//"looptype", iTween.Defaults.loopType,
			"position", new Vector3(5,0,0),
			//"easeType", "easeInBack",
			"delay", 0.5f,
					
			//start
			"onstart", "EnableClick",
			"onstarttarget", gameObject,
			"onstartparams", true,
					
			// complete
			"oncomplete", "ResetSettings",
			"oncompletetarget", gameObject
		);
	}
	
	
	void Update ()
	{	
		if(SceneModel.activeFunction == SceneModel.reset)
		{
			ResetSettings();
		}
		else
		{
			Method_iTweens();
		}
	}
	
	
	void ResetSettings ()
	{
		SceneReset.ResetSettings(cubeEmpty, cubeChild);
		
		EnableClick(false);
	}
	
	
	//* iTweens *//
	void Method_iTweens ()
	{
		if(!isClicked)
		{	
			// Reset
			if(SceneModel.activeFunction != SceneModel.reset && SceneModel.activeFunction != null)
			{
				EnableClick(true);
				Debug.Log("Method_iTweens: " + SceneModel.activeFunction);
			}
			
			// Fade
			if(SceneModel.activeFunction == SceneModel.fadeTo)
			{
				iTween.FadeTo(cubeChild, iTween.Hash("alpha", 0.0f, "time", 2.0f, 
					"oncomplete", "ResetSettings", "oncompletetarget", gameObject));
				//iTween.FadeTo(cubeChild, hashtable);
			}
			
			// Move
			else if(SceneModel.activeFunction == SceneModel.moveTo)
			{
				iTween.MoveTo(cubeChild, iTween.Hash("position", new Vector3(5,0,0), "time", 2.0, 
					"oncomplete", "ResetSettings", "oncompletetarget", gameObject));
				//iTween.MoveTo(cubeChild, hashtable);
			}
			
			// Scale
			else if(SceneModel.activeFunction == SceneModel.scaleTo)
			{
				iTween.ScaleTo(cubeChild,iTween.Hash("y", 10, "time", 2.0, 
					"oncomplete", "ResetSettings", "oncompletetarget", gameObject));
			}
			
			// RotateTo
			else if(SceneModel.activeFunction == SceneModel.rotateTo)
			{
				iTween.RotateTo(cubeChild, iTween.Hash("rotation", new Vector3(0,180,0), 
					"oncomplete", "ResetSettings", "oncompletetarget", gameObject));
				//iTween.RotateTo(cubeChild, hashtable);
			}
			
			// RotateBy
			else if(SceneModel.activeFunction == SceneModel.rotateBy)
			{
				iTween.RotateBy(cubeChild, iTween.Hash("y", 1.0f, "time", 4.0f, 
					"oncomplete", "ResetSettings", "oncompletetarget", gameObject));
			}
			
			// ColorTo
			else if(SceneModel.activeFunction == SceneModel.colorTo)
			{
				iTween.ColorTo(cubeChild, iTween.Hash("r", 0, "g", 0.5f, "b", 1, "delay", 0.5, "time", 1.0, 
					"oncomplete", "ResetSettings", "oncompletetarget", gameObject));
			}
			
			// ShakePosition
			else if(SceneModel.activeFunction == SceneModel.shakePosition)
			{
				iTween.ShakePosition(cubeChild, iTween.Hash("y", -0.5, "time", 1.0, "delay", 1.0, 
					"oncomplete", "ResetSettings", "oncompletetarget", gameObject));
			}
			
			// PunchPosition
			else if(SceneModel.activeFunction == SceneModel.punchPosition)
			{
				iTween.PunchPosition(cubeChild, iTween.Hash("y", -2, "time", 3.0, "delay", 1.5, 
					"oncomplete", "ResetSettings", "oncompletetarget", gameObject));
			}
			
			// Stab
			else if(SceneModel.activeFunction == SceneModel.stab)
			{
				if(audioClip != null)
					iTween.Stab(cubeChild, iTween.Hash("delay", 1.5, "time", 3.0, "audioclip", audioClip, 
						"oncomplete", "ResetSettings", "oncompletetarget", gameObject));
			}
		}
	}
	
	void EnableClick (bool enable)
	{
		Debug.Log("EnableClick: " + enable);
		isClicked = enable;
	}
	
}
