using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room0Manager : MonoBehaviour
{

    public bool isFinish = true;
    // Start is called before the first frame update
    void Start()
    {
        MusicManager.Instance.PlaySheet(2);
        GameStateManager.Instance.SetGameState(GameState.PLAY);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
