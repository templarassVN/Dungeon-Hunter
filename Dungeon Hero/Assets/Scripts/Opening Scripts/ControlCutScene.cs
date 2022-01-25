using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ControlCutScene : MonoBehaviour
{
    [SerializeField] PlayableDirector opening;
    [SerializeField] PlayableDirector FinishMap1;

    // Start is called before the first frame update
    void Start()
    {
        if (GameStateManager.Instance.IsNewGame)
        {
            GameStateManager.Instance.SetGameState(GameState.CUTS);
            StartCoroutine(PlayOpening((opening)));
        }
        else
        {
            GameStateManager.Instance.SetGameState(GameState.PLAY);
        }
        if (GameStateManager.Instance.isFinishMap1)
            StartCoroutine(PlayFinishMap1());
        MusicManager.Instance.PlaySheet(1);
    }

    private void Update()
    {
        
    }

    // Update is called once per frame

    private IEnumerator PlayOpening(PlayableDirector playableDirector)
    {
        playableDirector.Play();
        yield return new WaitForSeconds((float)playableDirector.duration);
        GameStateManager.Instance.SetGameState(GameState.PLAY);
        GameStateManager.Instance.IsNewGame = false;
    }
    
    private IEnumerator PlayFinishMap1()
    {
        FinishMap1.Play();
        yield return new WaitForSeconds((float)FinishMap1.duration);
        GameStateManager.Instance.SetGameState(GameState.PLAY);
    }
}
