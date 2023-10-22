using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject trophyObject;
    [SerializeField] int waveCount;

    float timer = 0;
    float timeBetweenChecks = 3;
    int currentWave = 1;
    bool won = false;

    // Update is called once per frame
    void Update()
    {
        if (!won)
        {
            timer += Time.deltaTime;


            //refreshes the list of enemies
            if (timer >= timeBetweenChecks)
            {
                GameObject[] enemies;
                enemies = GameObject.FindGameObjectsWithTag("Enemy");
                if (enemies == null || enemies.Length == 0)
                {
                    spawnWave();
                }
                timer = 0;
            }
        }



    }


    void spawnWave()
    {
        if (currentWave <= waveCount)
        {
            for (int i = 0; i < currentWave+1 * 2; i++)
            {
                Instantiate(enemyPrefab, new Vector3(Random.Range(3180, 3210), 411f, Random.Range(2730, 2760)), Quaternion.identity);
                
            }
            currentWave++;
        }
        else
        {
            Instantiate(trophyObject, new Vector3(3195f, 412.5f, 2742f), Quaternion.identity);
            won = true;
        }



    }
}
