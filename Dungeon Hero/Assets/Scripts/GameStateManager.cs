using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { CUTS, MENU, MISSION, PLAY, DEATH }
public class GameStateManager : MonoBehaviour
{
    [SerializeField] Texture2D sprite;
    [SerializeField] private bool _NewGame = true;
    [SerializeField] private bool _finishMap1 = false;
    public GameState State { get; private set; }
    public static GameStateManager Instance;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    // Start is called before the first frame update

    private void Start()
    {
        Vector2 hotspot = new Vector2(sprite.width / 2, sprite.height / 2);
        Cursor.SetCursor(sprite, hotspot, CursorMode.Auto);
    }
    public void SetGameState(GameState state)
    {
        this.State = state;
        switch (state)
        {
            case GameState.MENU:
                UIController.Instance.MenuPopUp(); 
                break;
            case GameState.PLAY:
                
                break;
        }
        Debug.Log(State);
    }

    public bool IsNewGame
    {
        get { return _NewGame; }
        set { _NewGame = value; }
    }

    public bool isFinishMap1
    {
        get { return _finishMap1; }
        set { _finishMap1 = value; }
    }
}
