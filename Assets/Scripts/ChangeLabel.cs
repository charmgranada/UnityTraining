using UnityEngine;
using System.Collections;

public class ChangeLabel : MonoBehaviour
{
	public void Change(string text)
	{
		gameObject.GetComponent<UILabel>().text = text;
		Debug.Log("CHANGE: " + text);
	}
}
