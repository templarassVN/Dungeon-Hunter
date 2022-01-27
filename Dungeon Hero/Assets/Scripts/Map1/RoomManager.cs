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

    [SerializeField]
    GameObject clear;
    float countTimeClear = 3f;
    public int currentRoom;

    bool _winsong = true;

    // Start is called before the first frame update
    void Start()
    {
        if (GameStateManager.Instance._loadGame)
        {
            if (GameStateManager.Instance.currentSavePoint == currentRoom)
            {
                this.gameObject.SetActive(true);
            }
            if (GameStateManager.Instance.currentSavePoint > currentRoom)
                _isFinished = true;
        }
        countTimeClear = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isFinished)
        {
            countTimeClear -= Time.deltaTime;
            if (countTimeClear <= 0)
            {
                clear.SetActive(false);
            }
        }
        if (isFinished) return;
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
            if (_isFinished == false)
            {
                GameStateManager.Instance.currentSavePoint++;
            }
            _isFinished = true;
            if (countTimeClear > 0)
            {
                clear.SetActive(true);
            }
        }

        if (_isFinished && _winsong )
        {
            _winsong = false;
            EffectManager.Instance.PlaySFX(10);
        }

    }

    public bool isFinished
    {
        get { return _isFinished; }

    }
}
