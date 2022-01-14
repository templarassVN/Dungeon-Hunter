using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Room1Manager : MonoBehaviour
{
    [SerializeField]
    bool _isFinished;
    [SerializeField]
    PlayableDirector _entrance;
    [SerializeField]
    GameObject _secrectRoom1;
    [SerializeField]
    GameObject _Timer;
    
    [SerializeField]
    GameObject clear;
    float timeShowClear = 3f;
    float countTime = 0f;

    [SerializeField]
    SpawnEnemy spawnEnemyWave1;

    [SerializeField]
    SpawnEnemy spawnEnemyWave2;

    [SerializeField]
    SpawnEnemy spawnEnemyWave3;
    
    // Start is called before the first frame update
    void Start()
    {
        _secrectRoom1.SetActive(false);   
        clear.SetActive(false);
        countTime = timeShowClear;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.instance.transform.position.x > -17 && spawnEnemyWave1.currentEnemy == -1) {
            spawnEnemyWave1.Spawn();
        }
        if (spawnEnemyWave1.currentEnemy == 0) {
            spawnEnemyWave2.Spawn();
            spawnEnemyWave1.currentEnemy = -2;
        }
        if (spawnEnemyWave2.currentEnemy == 0) {
            spawnEnemyWave3.Spawn();
            spawnEnemyWave2.currentEnemy = -2;
        }
        if (clear.activeInHierarchy) {
            countTime -= Time.deltaTime;
            if (countTime <= 0) {
                clear.SetActive(false);
            }
        }
        if (spawnEnemyWave3.currentEnemy == 0) {
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

    public void EnterSecrectRoom1()
    {
        GameStateManager.Instance.SetGameState(GameState.CUTS);
        StartCoroutine(BreakInto());
    }

    IEnumerator BreakInto()
    {
        _entrance.Play();
        yield return new WaitForSeconds((float)_entrance.duration);
        _secrectRoom1.SetActive(true);
        GameStateManager.Instance.SetGameState(GameState.PLAY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _Timer.GetComponent<Timer>().SetandRun();
    }
}
