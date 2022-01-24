using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class OpenLevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        PlayableDirector director = GetComponent<PlayableDirector>();
        
        if(GameStateManager.Instance.IsNewGame)
        {
            GameStateManager.Instance.SetGameState(GameState.CUTS);
            StartCoroutine(PlayTimelineRoutine((director)));
        } else
        {
            GameStateManager.Instance.SetGameState(GameState.PLAY);
        }  
    }

    // Update is called once per frame
    

    private IEnumerator PlayTimelineRoutine(PlayableDirector playableDirector)
    {
        playableDirector.Play();
        yield return new WaitForSeconds((float)playableDirector.duration);
        GameStateManager.Instance.SetGameState(GameState.PLAY);
        GameStateManager.Instance.IsNewGame = false;
        
    }
}
