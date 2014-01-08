using UnityEngine;
using System.Collections;

public class SceneController_Particles : MonoBehaviour
{
	public GameObject legacy1;
	public GameObject legacy2;
	public GameObject legacy3;
	public GameObject shuriken1;
	public GameObject shuriken2;
	public GameObject shuriken3;
	
	private Transform[] _shuriken1Children;
	private Transform[] _shuriken2Children;
	private Transform[] _shuriken3Children;
	
	
	void Start ()
	{
		_shuriken1Children = shuriken1.gameObject.GetComponentsInChildren<Transform>();
		_shuriken2Children = shuriken2.gameObject.GetComponentsInChildren<Transform>();
		_shuriken3Children = shuriken3.gameObject.GetComponentsInChildren<Transform>();
		
		legacy1.SetActive(false);
		legacy2.SetActive(false);
		legacy3.SetActive(false);
		shuriken1.SetActive(false);
		shuriken2.SetActive(false);
		shuriken3.SetActive(false);
		
		ResetSettings();
	}
	
	
	void Update ()
	{	
		if(SceneModel.activeFunction == SceneModel.reset)
		{
			ResetSettings();
		}
		else
		{
			Method_Particles();
		}
	}
	
	
	void ResetSettings ()
	{
		legacy1.particleEmitter.emit = false;
		legacy2.particleEmitter.emit = false;
		legacy3.particleEmitter.emit = false;
		
		foreach(Transform child in _shuriken1Children)
			child.particleSystem.enableEmission = false;
		foreach(Transform child in _shuriken2Children)
			child.particleSystem.enableEmission = false;
		foreach(Transform child in _shuriken3Children)
			child.particleSystem.enableEmission = false;
		
		//shuriken1.particleSystem.Pause();
		//shuriken2.particleSystem.Pause();
		//shuriken3.particleSystem.Pause();
	}
	
	
	//* Particles *//
	void Method_Particles ()
	{
		ResetSettings();
			
		// Reset
		if(SceneModel.activeFunction != SceneModel.reset && SceneModel.activeFunction != null)
		{
			Debug.Log("Method_Particles: " + SceneModel.activeFunction);
		}
		
		// Legacy
		if(SceneModel.activeFunction == SceneModel.legacy)
		{
			
		}
		
		// Legacy - Thruster
		else if(SceneModel.activeFunction == SceneModel.l_thruster)
		{
			if(!legacy1.activeSelf) legacy1.SetActive(true);
			
			legacy1.particleEmitter.emit = true;
		}
		
		// Legacy - Hazy Glow
		else if(SceneModel.activeFunction == SceneModel.l_hazyGlow)
		{
			if(!legacy2.activeSelf) legacy2.SetActive(true);
			legacy2.particleEmitter.emit = true;
		}
		
		// Legacy - Explosion
		else if(SceneModel.activeFunction == SceneModel.l_explosion)
		{
			if(!legacy3.activeSelf) legacy3.SetActive(true);
			legacy3.particleEmitter.emit = true;
		}
		
		// Shuriken
		else if(SceneModel.activeFunction == SceneModel.shuriken)
		{
			
		}
		
		// Shuriken - 
		else if(SceneModel.activeFunction == SceneModel.s_flare)
		{	
			if(!shuriken1.activeSelf) shuriken1.SetActive(true);
			foreach(Transform child in _shuriken1Children)
				child.particleSystem.enableEmission = true;
		}
		
		// Shuriken
		else if(SceneModel.activeFunction == SceneModel.s_dustdevil)
		{
			if(!shuriken2.activeSelf) shuriken2.SetActive(true);
			foreach(Transform child in _shuriken2Children)
				child.particleSystem.enableEmission = true;
		}
		
		// Shuriken
		else if(SceneModel.activeFunction == SceneModel.s_fireworks)
		{
			if(!shuriken3.activeSelf) shuriken3.SetActive(true);
			foreach(Transform child in _shuriken3Children)
				child.particleSystem.enableEmission = true;
		}
	}
}
