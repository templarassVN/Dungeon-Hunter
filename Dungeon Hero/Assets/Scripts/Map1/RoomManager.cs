using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField]
    bool _isFinished;
    [SerializeField]
    SpawnEnemy spawnEnemyWave1;

    [SerializeField]
    SpawnEnemy spawnEnemyWave2;

    [SerializeField]
    SpawnEnemy spawnEnemyWave3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.instance.transform.position.x > -17 && spawnEnemyWave1.currentEnemy == -1)
        {
            spawnEnemyWave1.Spawn();
        }
        if (spawnEnemyWave1.currentEnemy == 0)
        {
            spawnEnemyWave2.Spawn();
            spawnEnemyWave1.currentEnemy = -2;
        }
        if (spawnEnemyWave2.currentEnemy == 0)
        {
            spawnEnemyWave3.Spawn();
            spawnEnemyWave2.currentEnemy = -2;
        }
        if (spawnEnemyWave3.currentEnemy == 0)
        {
            _isFinished = true;
        }
    }

    public bool isFinished
    {
        get { return _isFinished; }

    }
}
