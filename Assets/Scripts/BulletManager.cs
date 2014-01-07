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
			Debug.Log("Object POOL ---> ADD");
		
			for (int i = 0; i < poolCount; i++)
			{
				bulletPool.Add(Instantiate(bulletSample) as GameObject);
				bulletPool[bulletPool.Count-1].SetActive(false);
			}
		}
	}
	
	public static void ActivateProjectiles (Vector3 newPos)
	{
		if(bulletPool[0] == null)
		{
			bulletPool.Clear();
			AddObjectPool();
		}
		
		for (int i = 0; i < poolCount; i++)
		{
			Debug.Log("bulletPool: " + bulletPool[i]);
			
			if(bulletPool[i].activeSelf == false)
			{
				bulletPool[i].SetActive(true);
				bulletPool[i].transform.position = newPos;
				index = i;
				return;
			}
		}
	}
	
	public static void DeactivateProjectile (int i)
	{
		bulletPool[i].SetActive(false);
	}
}
