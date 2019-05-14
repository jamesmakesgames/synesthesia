using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spectrum : MonoBehaviour 
{
	public AudioSource asource;
	public int channel;
	public int numRows;
	public int numCols;
	public float startX, startZ;
	public float xSpacing, zSpacing;
	float[] spectrum; 
	float[] volume;
	float sinAngle = 0;
	public int numSamples;
	public GameObject cube;
	List<GameObject> cubes;

	// Use this for initialization
	void Start () 
	{
		volume = new float[numSamples];
		spectrum = new float[numSamples];
	
		
		cubes = new List<GameObject>();
		for(int i = 0; i < numRows; i++)
		{
			for(int j = 0; j < numCols; j++)
			{
				//cubes.Add ((GameObject)Instantiate(cube, Vector3(startX + xSpacing*i, Random.Range(-5, 5),  startZ + zSpacing*j), Quaternion.identity));
				GameObject thisObject = Instantiate(cube,new Vector3(startX + xSpacing*i, 0,  startZ + zSpacing*j), Quaternion.identity) as GameObject;
				cubes.Add(thisObject);
			}
		}
	
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		asource.GetOutputData(volume, channel);
    	asource.GetSpectrumData(spectrum, channel, FFTWindow.Rectangular);
	
		for (int i=0; i<(numRows*numCols); i++) 
		{
			cubes[i].transform.position = new Vector3(cubes[i].transform.position.x, 5 * Mathf.Sin(sinAngle + ((float)i/360f * 360f)), cubes[i].transform.position.z);
			cubes[i].transform.localScale= new  Vector3(10*spectrum[i] + 1,1,1);
			cubes[i].GetComponent<MeshRenderer>().material.color= new Color(100*spectrum[i],1f/(20*spectrum[i]),1f/(20*spectrum[i]),1);
		}
		
		sinAngle += 0.1f;
	}
	

}
