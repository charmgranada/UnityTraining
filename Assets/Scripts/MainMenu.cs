using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MainMenu : MonoBehaviour
{
	private List<string> menu = new List<string>();
	
	void Start ()
	{
	}
	
	
	void OnSelect(bool boolValue)
	{
		if(boolValue)
			Application.LoadLevel(gameObject.name);
	}
}
