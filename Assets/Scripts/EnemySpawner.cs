using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 1f;
    [SerializeField] bool isLooping = true;
    WaveConfigSO currentWave;
    
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(WaveSpawn());
        StartCoroutine(SpawnEnemyWaves());
        
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;

                for (int j = 0; j < currentWave.GetEnemyCount(); j++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(j), currentWave.GetStartingwaypoint().position, Quaternion.identity, transform);
                    //Standard Instantiation requires a rotation value - quaternian.identity
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                    //requires loop to wait until time has elapsed. Time to wait is calculated with the waveconfig method GetRandomSpawnTime and applied
                }

                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping == true);
        
    }
    

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
}
