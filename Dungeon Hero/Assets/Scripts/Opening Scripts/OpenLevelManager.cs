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
        UIController.Instance.SetGameState(GameState.CUTS);
        StartCoroutine(PlayTimelineRoutine((director)));
    }

    // Update is called once per frame
    

    private IEnumerator PlayTimelineRoutine(PlayableDirector playableDirector)
    {
        playableDirector.Play();
        yield return new WaitForSeconds((float)playableDirector.duration);
        UIController.Instance.SetGameState(GameState.PLAY);
    }
}
