using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level_1_Manager : MonoBehaviour
{
    [SerializeField]
    GameObject deadNotification;
    // Start is called before the first frame update
    void Start()
    {
        GameStateManager.Instance.SetGameState(GameState.PLAY);
        deadNotification.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.instance.CurrentHealth == 0) {
            deadNotification.SetActive(true);
        }
    }
}
