using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSo> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0.5f;
    WaveConfigSo currentWave;
    [SerializeField] bool isLooping;
    // List<Transform> waypoints;
    void Start()
    {
        StartCoroutine(SpawnEnemiesWaves());
    }

    public WaveConfigSo GetCurrentWave(){
        return currentWave;
    }
    IEnumerator SpawnEnemiesWaves(){
        do
        {
            foreach(WaveConfigSo wave in waveConfigs)
            {
                currentWave = wave;
                for(int i =0; i < currentWave.GetEnemyCount(); i++) 
                {
                    Instantiate(currentWave.GetEnemyPrefabs(i), 
                                currentWave.GetStartingWayPoint().position,
                                Quaternion.Euler(0,0,180),
                                transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping );
    }

}
