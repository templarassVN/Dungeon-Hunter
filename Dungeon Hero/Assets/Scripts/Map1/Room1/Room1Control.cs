using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1Control : MonoBehaviour
{
    [SerializeField]
    Timer timer;
    [SerializeField]
    SpawnEnemy spawnEnemyWave3;
    [SerializeField]
    bool _challengeFinished = false;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnEnemyWave3.currentEnemy == 0)
        {
            if(timer.Timeleft > 0)
            {
                timer.Stop();
                _challengeFinished = true;
                
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        timer.SetandRun();
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public bool Completechallenge()
    {
        return _challengeFinished;
    }
}
