using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2Manager : MonoBehaviour
{
    [SerializeField]
    bool _isFinished;
    [SerializeField]
    GameObject _notify;

    [SerializeField]
    SpawnEnemy spawnEnemyWave1;
    
    [SerializeField]
    SpawnEnemy spawnEnemyWave2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.instance.transform.position.y < -15 && spawnEnemyWave1.currentEnemy == -1) {
            spawnEnemyWave1.Spawn();
        }
        if (spawnEnemyWave1.currentEnemy == 0) {
            spawnEnemyWave2.Spawn();
            spawnEnemyWave1.currentEnemy = -2;
        }
        if (spawnEnemyWave2.currentEnemy == 0) {
            _isFinished = true;
        }
    }
}
