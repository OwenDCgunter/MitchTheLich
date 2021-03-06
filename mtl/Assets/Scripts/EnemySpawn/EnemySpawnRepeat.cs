﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnRepeat : MonoBehaviour {

	//Author: Owen.Gunter
	//Purpose: To repeatbly spawn an enemy at a location every 2 seconds up to 5 enemies for now
	//Date: 24/09/2018
	//reference to bunny prefab
	public GameObject bunny;
    GameObject bunnyClone;
	//reference to BunnySpawnRepeat object in Inspector
	public Transform enemyspawner;
	// this delays each spawn by a particular time
	public float spawnDelay = mtl.EnemySpawner.spawnTimer;
	// starts at zero and equals whatever time.time was before
	private float lastSpawnTime;
	// this controls the total amount of enemies that can be spawned from the enemyspawner transform
	public int amountofenemies = mtl.EnemySpawner.AmountOfEnemies;
	// increments by 1 each time an enemy spawns
	private int counter = 0;

	void Update()
	{
		//Calls the EnemySpawnerR function
		EnemySpawnerR ();

	}
	public void EnemySpawnerR()
	{
        //Time.time means the time in seconds since start of the game
        // if time is greater than the last time it spawned plus whatever the delay is
        // set lastFireTime = to the current time
        // and create a bunny at the location of where the enemyspawner transform is
       
		if (Time.time > (lastSpawnTime + spawnDelay) && counter < amountofenemies) {
			lastSpawnTime = Time.time;
			bunnyClone = Instantiate(bunny, enemyspawner.position, enemyspawner.rotation) as GameObject;
			counter++;
			print ("bunny number " + counter + " created ");
		}

	}
}
