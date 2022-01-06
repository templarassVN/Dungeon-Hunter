using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {CUTS, MENU, PLAY, DEATH }
public class UIController : MonoBehaviour
{
    public static UIController Instance;

    [SerializeField]
    private GameObject _MenuCanvas;
    [SerializeField]
    private GameObject _TransitionCanvas;
    public GameState State { get; private set; }

    public void SetGameState(GameState state)
    {
        this.State = state;
        switch (state)
        {
            case GameState.MENU:
                MenuPopUp();
                break;
            case GameState.PLAY:
                Play();
                break;
            
        }
    }


    private void Awake()
    {

        DontDestroyOnLoad(this);

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
    void Start()
    {
        SetGameState(GameState.CUTS);
    }

    // Update is called once per frame
    void MenuPopUp()
    {
        _MenuCanvas.SetActive(true);
    }

    void Play()
    {
        _MenuCanvas.SetActive(false);
    }

    

    
}
