using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    
    [SerializeField] private GameObject enemy;
    private GameObject newEnemy;

    private float randomXposition;
    [SerializeField] private float startingYposition;
    private Vector3 spawnPosition;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnNewEnemy", 0f, 1.5f);
    }

    private void Update()
    {
       
    }

    private void SpawnNewEnemy()
    {
        randomXposition = Random.Range(-2.5f, 2.5f);
        spawnPosition = new Vector3(randomXposition, startingYposition, 0f);
        newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
    }

}
