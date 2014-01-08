using UnityEngine;
using System.Collections;

public class FloatingText : MonoBehaviour
{
	//follow the gameobject around on the screen
	public GameObject _target;
	
	public bool _active;
	
	//will keep on the target as it moves on the world
	public Camera worldCamera;
	public Camera guiCamera;
	
	//pass in a string to be displayed, get a reference to the UILabel
	private UILabel _lbl;
	
	private Transform _t;
	public bool _followTarget;
	
	void Awake ()
	{
		_t = transform;
		//assign reference
		_lbl = GetComponent<UILabel>();
		
		if(_lbl == null)
			Debug.LogError( "Could not find the UILable for the floating text" );
			
	}
	
	
	void Start ()
	{	
		guiCamera = NGUITools.FindCameraForLayer( gameObject.layer );
	}
	
	
	void LateUpdate ()
	{
		if(!_active)
			return;
		
		worldCamera = NGUITools.FindCameraForLayer( _target.layer );//will look for the camera at the Default layer
		guiCamera = NGUITools.FindCameraForLayer ( gameObject.layer );//will look for the camera at the NGUI layer
		
		Vector3 pos = worldCamera.WorldToViewportPoint ( _target.transform.position );
		pos = guiCamera.ViewportToWorldPoint ( pos );
		pos.z = 0.0f;
		transform.position = pos;
		
		if(_followTarget)
			Following();
	}
	
	
	//set a Getter/Setter for the Properties of FloatingText
	public void Init( string txt, Color clr, GameObject go )
	{
		TextColor = clr;
		Text = txt;
		Target = go; 
	}
	
	//set a Getter/Setter for the Target
	public GameObject Target
	{
		get { return _target; }
		set { 
			_target = value; 
			worldCamera = NGUITools.FindCameraForLayer ( _target.layer );
		}
	}
	
	//set a Getter/Setter for the text Color
	public Color TextColor
	{
		get { return _lbl.color; }
		set { _lbl.color = value; }
	}
	
	//set a Getter/Setter for the text Input
	public string Text
	{
		get { return _lbl.text; }
		set { _lbl.text = value; }
	}
	
	public bool FollowTarget
	{
		get { return _followTarget; }
		set { _followTarget = value; }
	}
	
	
	public UIBaseFont Font
	{
		get { return _lbl.font; }
		set { _lbl.font = value; }
	}
	
	public Vector3 FontSize
	{
		get { return _lbl.transform.localScale; }
		set { _lbl.transform.localScale = value; }
	}
	
	public bool Active
	{
		get { return _active; }
		set { _active = value; }
	}
	
	public void SpawnAt (GameObject target, Vector3 size, Transform parent)
	{
		Target = target;
		_t.parent = parent;
		FontSize = size;
	}
	
	private void Following()
	{
	}
	
	public TweenPosition TweenPos
	{
		get
		{
			TweenPosition tp = GetComponent<TweenPosition>();
			
			if(tp == null)
				tp = gameObject.AddComponent<TweenPosition>();
			
			return tp;
		}
	}
	
	public void DestroyMe ()
	{
		Debug.Log( "Destroy Me");
		Destroy (gameObject);
	}
}
