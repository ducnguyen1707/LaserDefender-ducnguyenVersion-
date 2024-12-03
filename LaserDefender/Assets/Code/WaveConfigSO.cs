using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSo : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 4;
    [SerializeField] float timeBetweenEnemySpawns =  1f;
    [SerializeField] float spawnTimeVar = 0f;
    [SerializeField] float miniumSpawnTime = 0.2f;

    public int GetEnemyCount(){
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefabs(int index){
        return enemyPrefabs[index];
    }
    public Transform GetStartingWayPoint(){
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints(){
        List<Transform> waypoints = new  List<Transform>();
        foreach(Transform child in pathPrefab){
            waypoints.Add(child); 
        }
        return  waypoints;
    }
    public float GetMoveSpeed(){
        return moveSpeed;
    }

    public float GetRandomSpawnTime(){
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVar,
                                        timeBetweenEnemySpawns + spawnTimeVar);
        return Mathf.Clamp(spawnTime, miniumSpawnTime, float .MaxValue);
    }
}
