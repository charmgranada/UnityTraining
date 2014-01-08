using UnityEngine;
using System.Collections;

public class SceneReset : MonoBehaviour
{	
	private static Vector3 	origScale_cubeChild;
	private static Vector3 	origPosition_cube;
	private static Vector3 	origPosition_cubeChild;
	private static Quaternion 	origRotation_cubeChild;
	private static Quaternion 	origRotation_cube;
	private static Material  _cubeColor;
	
	public static void InitialState (GameObject cubeEmpty, GameObject cubeChild, Material cubeColor)
	{
		origPosition_cube = cubeEmpty.transform.position;
		origRotation_cube = cubeEmpty.transform.rotation;
		origScale_cubeChild = cubeChild.transform.localScale;
		origPosition_cubeChild = cubeChild.transform.position;
		origRotation_cubeChild = cubeChild.transform.rotation;
		
		_cubeColor = cubeColor;
	}
	
	
	public static void ResetSettings (GameObject cubeEmpty, GameObject cubeChild)
	{
		cubeEmpty.transform.position = origPosition_cube;
		cubeEmpty.transform.rotation = origRotation_cube;
		cubeChild.transform.position = origPosition_cubeChild;
		cubeChild.transform.rotation = origRotation_cubeChild;
		cubeChild.transform.localScale = origScale_cubeChild;
		
		cubeChild.renderer.material.color = _cubeColor.color;
	}
}
