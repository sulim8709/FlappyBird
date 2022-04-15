using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{

    public Pipe pipe;
    
    public float spawnDistance = 5;

    public float spawnDelay = 2;
    public float randomRange = 3;
    float random;

    private void OnEnable() {
        // 주기적으로 생성
        Invoke("SpawnPipe", 2);
    }

    private void OnDisable() {
        // 코루틴 중지
        CancelInvoke("SpawnPipe");
    }
    
    private void SpawnPipe()
    {
        random = Random.Range(-randomRange, randomRange);
        Instantiate(pipe, new Vector2(spawnDistance, random), Quaternion.identity);

        Invoke("SpawnPipe", spawnDelay);
    }
}
