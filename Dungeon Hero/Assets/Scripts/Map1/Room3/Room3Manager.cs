using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room3Manager : MonoBehaviour
{
    [SerializeField]
    bool _isFinished;

    [SerializeField]
    SpawnEnemy spawnEnemyWave1;
    
    [SerializeField]
    SpawnEnemy spawnEnemyWave2;

    [SerializeField]
    GameObject clear;
    float countTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.instance.transform.position.x > 43 && spawnEnemyWave1.currentEnemy == -1) {
            spawnEnemyWave1.Spawn();
        }
        if (spawnEnemyWave1.currentEnemy == 0) {
            spawnEnemyWave2.Spawn();
            spawnEnemyWave1.currentEnemy = -2;
        }
        if (clear.activeInHierarchy) {
            countTime -= Time.deltaTime;
            if (countTime <= 0) {
                clear.SetActive(false);
            }
        }
        if (spawnEnemyWave2.currentEnemy == 0) {
            _isFinished = true;
            if (countTime > 0) {
                clear.SetActive(true);
            }
        }

    }
     public bool isFinished
    {
        get { return _isFinished; }
        set { _isFinished = value; }
    }
}
