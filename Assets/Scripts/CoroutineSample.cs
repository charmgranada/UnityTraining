using UnityEngine;
using System.Collections;

public class CoroutineSample : MonoBehaviour {

	private bool _keyPressed = false;
	
	// Use this for initialization
	void Start ()
	{
		StartCoroutine (FirstFunction());
	}
	
	public IEnumerator FirstFunction ()
	{
		yield return StartCoroutine(WaitForKeyPress("Jump"));
		Debug.Log("Coroutine Ends.");
	}
	
	
	public IEnumerator WaitForKeyPress (string _button)
	{
		while(!_keyPressed)
		{
			if(Input.GetButton(_button))
			{
				Debug.Log(_button);
				StartGame();
				break;
			}
			
			print ("Awaiting Input....");
			yield return 0;
		}
	}
	
	void StartGame ()
	{
		Debug.Log("START");
	}
}
