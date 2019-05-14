using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spawnCubes : MonoBehaviour 
{

	public GameObject cube;
	List<GameObject> cubes;
	public int numCols;
	public int numRows;
	public float startX;
	public float startZ;
	public float xSpacing;
	public float zSpacing;
	public float heightRange;
//	
//	public static double NormalDistribution()
//	{
//		double U, u, v, S;
//		
//		do
//		{
//			u = 2.0 * Random.value - 1.0;
//			v = 2.0 * Random.value - 1.0;
//			S = u * u + v * v;
//		}
//		while (S >= 1.0);
//		
//		double fac = Mathf.Sqrt(-2.0 * Mathf.Log((float)S) / S);
//		return u * fac;
//	}
	

	// Use this for initialization
	void Start () 
	{
		cubes = new List<GameObject>();
		for(int i = 0; i < numRows; i++)
		{
			for(int j = 0; j < numCols; j++)
			{
				//cubes.Add ((GameObject)Instantiate(cube, Vector3(startX + xSpacing*i, Random.Range(-5, 5),  startZ + zSpacing*j), Quaternion.identity));
				GameObject thisObject = Instantiate(cube,new Vector3(startX + xSpacing*i, (float)Random.Range(-7, 20),  startZ + zSpacing*j), Quaternion.identity) as GameObject;
				cubes.Add(thisObject);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
