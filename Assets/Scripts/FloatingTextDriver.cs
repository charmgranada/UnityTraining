using UnityEngine;
using System.Collections;

public class FloatingTextDriver : MonoBehaviour {

	public GameObject target;
	public FloatingText ft_prefab;
	public UIBaseFont font;
	public Transform parent;
	
	public void OnClick ()
	{
		FloatingText ft = Instantiate ( ft_prefab ) as FloatingText;
		
		Vector3 size =  ft.transform.localScale;
		
		ft.SpawnAt (target, size, parent);
		
		ft.transform.parent = parent;
		
		ft.Init("Test", Color.white, target);
		ft.FollowTarget = true;
		//ft.Font = font;
		
		TweenPosition tp = ft.TweenPos;
		tp.duration = 2;
		
		Vector3 targetPos = target.transform.parent.localPosition;
		Vector3 newPos = new Vector3(targetPos.x * 60, targetPos.y - 50, targetPos.z);
		
		tp.from = newPos;
		tp.to = tp.from + Vector3.up * 70; 
		tp.eventReceiver = ft.gameObject;
		tp.callWhenFinished = "DestroyMe";
	}
}
