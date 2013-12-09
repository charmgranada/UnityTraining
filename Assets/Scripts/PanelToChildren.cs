using UnityEngine;
using System.Collections;

public class PanelToChildren : MonoBehaviour
{
	//private Transform[] children;

	// Apply script to All Children
	
	void Start () {
		foreach (Transform child in transform)
		{
			if(child.gameObject.GetComponent<SceneController_NGUI>() == null)
			{
				child.gameObject.AddComponent<SceneController_NGUI>();
			}
		}
		
		//Debug.Log("children: " + children);
	}
}
