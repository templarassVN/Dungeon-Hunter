using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_1_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameStateManager.Instance.SetGameState(GameState.PLAY);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
