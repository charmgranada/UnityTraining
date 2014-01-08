using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletManager : MonoBehaviour
{
	public static BulletManager instance = null;
	
	public static List<GameObject> bulletPool = new List<GameObject>();
	public static GameObject bulletSample = Resources.Load("Sphere_Rigidbody") as GameObject;
	
	public static int index;
	
	private static int poolCount = 10;
	
	
	void Start ()
	{
		instance = this;
	}
	
	public static void AddObjectPool ()
	{
		if(bulletPool.Count < poolCount)
		{
			for (int i = 0; i < poolCount; i++)
			{
				bulletPool.Add(Instantiate(bulletSample) as GameObject);
				bulletPool[bulletPool.Count-1].SetActive(false);
			}
		}
	}
	
	public static GameObject GetBullet()
	{
		//get last bullet from the stack
		GameObject g = bulletPool[0];
		
		if(g.activeSelf)
		{
			//remove the last and add at the start
			bulletPool.Remove(g);
			bulletPool.Add(g);
		}
		
		return g;
	}
	
	public static void ActivateProjectiles ()
	{
		if(bulletPool[0] == null)
		{
			bulletPool.Clear();
			AddObjectPool();
		}
	}
}
