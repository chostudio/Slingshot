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

    private float increase = 0f;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {

    }


    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2f-increase)
        {
            if (increase < 1.5f)
            {
                increase += 0.05f;
            }
            
            timer = 0f;

            Invoke("SpawnNewEnemy", 0f);
        }

    }

    private void SpawnNewEnemy()
    {
        randomXposition = Random.Range(-2.5f, 2.5f);
        spawnPosition = new Vector3(randomXposition, startingYposition, 0f);
        newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
    }
}
