using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlockSpwanner : MonoBehaviour {


	public Transform[] spawnPoints; //to reference rotation and all...

	public GameObject blockPrefab;

	public float timeBetweenWaves = 1f;

	private float timeToSpawn = 2f; //first block will spwan after 2 sec of the game's start

	void Update () 
	{
		if (Time.time >= timeToSpawn) 
		{
			SB ();
			timeToSpawn = Time.time + timeBetweenWaves;
			Score.scoreValue += 1;
		}
	}

	void SB() //spwan block
	{
		//Score.scoreValue += 1;
		int randomIndex = Random.Range (0, spawnPoints.Length);
		for (int i = 0; i < spawnPoints.Length; i++) 
		{
			if (randomIndex != i) 
			{
				Instantiate (blockPrefab, spawnPoints[i].position, Quaternion.identity);
			}
		}
	}
		

}