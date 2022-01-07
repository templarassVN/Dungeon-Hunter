using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { CUTS, MENU, PLAY, DEATH }
public class GameStateManager : MonoBehaviour
{
    public bool _NewGame = true;
    public GameState State { get; private set; }
    public static GameStateManager Instance;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    
    public void SetGameState(GameState state)
    {
        
        this.State = state;
        switch (state)
        {
            case GameState.MENU:
                UIController.Instance.MenuPopUp(); 
                break;
            case GameState.PLAY:
                UIController.Instance.Play();
                break;
        }
        Debug.Log(State);
    }
}
