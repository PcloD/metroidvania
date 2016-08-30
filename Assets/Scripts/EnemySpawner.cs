using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

    List<EnemyController> aliveEnemies;

	// Use this for initialization
	void Start () {
        aliveEnemies = new List<EnemyController>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void InstantiateEnemy(GameObject enemy, Vector3 position)
    {
        EnemyController enemySpawned = ((GameObject)Instantiate(enemy,position, Quaternion.identity)).GetComponent<EnemyController>();
        aliveEnemies.Add(enemySpawned);
    }

}
