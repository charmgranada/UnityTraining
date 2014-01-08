using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneModel
{
	public static string activeFunction;
	public static string currentScene;// = Application.loadedLevelName;
		
	// Scripts
	public const string reset = "Reset";
	public static string getButton = "GetButton";
	public static string getKey = "GetKey";
	public static string getAxis = "GetAxis";	
	public static string touch = "Touch";
	public static string accelerometer = "Accelerometer";
	public static string lookAt = "LookAt";		
	public static string instantiate = "Instantiate";	
	public static string destroy = "Destroy";	
	public static string lerp = "Lerp";	
	
	
	// iTweens
	public const string fadeTo = "FadeTo";
	public const string moveTo = "MoveTo";
	public const string scaleTo = "ScaleTo";
	public const string rotateTo = "RotateTo";
	public const string rotateBy = "RotateBy";
	public const string colorTo = "ColorTo";
	public const string shakePosition = "ShakePosition";
	public const string punchPosition = "PunchPosition";
	public const string stab = "Stab";
	
	
	// Physics
	public const string colliders = "colliders";
	public const string triggers = "triggers";
	public const string rigidbodies = "rigidbodies";
	public const string addForce = "addForce";
	public const string addTorque = "addTorque";
	public const string physicsMatl = "physicMatl";
	public const string jointHinge = "joints-Hinge";
	public const string jointSpring = "joints-Spring";
	public const string raycasting = "raycasting";
	public const string physicsMgr = "physicsMgr";
	
	
	// Particles
	public static string legacy = "legacy";
	public static string l_thruster = "l_thruster";
	public static string l_hazyGlow = "l_hazyGlow";
	public static string l_explosion = "l_explosion";
	public static string shuriken = "shuriken";
	public static string s_flare = "s_flare";
	public static string s_fireworks = "s_fireworks";
	public static string s_dustdevil = "s_dustdevil";
	
	// GUI
	
	public static List<string> arrList = new List<string>();
	
	/*public struct ButtonNames
	{
		public static string getButton1 = "GetButton";
		public static string getKey1 = "GetKey";
		public static string getAxis1 = "GetAxis";	
	};
	
	public enum ButtonKeys
	{
		getButton,
		getKey,
		getAxis,
		lookAt
	}*/
	
	
	static void SetScene ()
	{
		currentScene = Application.loadedLevelName;
		
		arrList.RemoveRange(0, arrList.Count);
	}
	
	
	public static void InitScriptActions ()
	{
		SetScene();
		
		arrList.Add(reset);
		arrList.Add(getButton);
		arrList.Add(getKey);
		arrList.Add(getAxis);
		arrList.Add(touch);
		arrList.Add(accelerometer);
		arrList.Add(lookAt);
		arrList.Add(instantiate);
		arrList.Add(destroy);
		arrList.Add(lerp);
	}
	
	public static void InitiTweens ()
	{
		SetScene();
		
		arrList.Add(reset);
		arrList.Add(fadeTo);
		arrList.Add(moveTo);
		arrList.Add(scaleTo);
		arrList.Add(rotateTo);
		arrList.Add(rotateBy);
		arrList.Add(colorTo);
		arrList.Add(shakePosition);
		arrList.Add(punchPosition);
		arrList.Add(stab);
	}
	
	public static void InitPhysics ()
	{
		SetScene();
		
		arrList.Add(reset);
		arrList.Add(raycasting);
		arrList.Add(colliders);
		arrList.Add(triggers);
		arrList.Add(rigidbodies);
		arrList.Add(addForce);
		arrList.Add(addTorque);
		arrList.Add(physicsMatl);
		arrList.Add(jointHinge);
		arrList.Add(jointSpring);
		//arrList.Add(raycasting);
		arrList.Add(physicsMgr);
	}
	
	public static void InitParticles ()
	{
		SetScene();
		
		arrList.Add(reset);
		arrList.Add(legacy);
		arrList.Add(l_thruster);
		arrList.Add(l_hazyGlow);
		arrList.Add(l_explosion);
		arrList.Add(shuriken);
		arrList.Add(s_flare);
		arrList.Add(s_dustdevil);
		arrList.Add(s_fireworks);
	}
	
	public static void InitGUI ()
	{
		SetScene();
		
		//arrList.Add(reset);
	}
	
	public static void LoadMainScene ()
	{
		Application.LoadLevel("MainScene");
	}
}
