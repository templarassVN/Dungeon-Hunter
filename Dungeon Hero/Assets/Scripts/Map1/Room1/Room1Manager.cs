using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Room1Manager : MonoBehaviour
{
    [SerializeField]
    bool _isFinished;
    [SerializeField]
    PlayableDirector _entrance;
    [SerializeField]
    GameObject _secrectRoom1;
    // Start is called before the first frame update
    void Start()
    {

        _secrectRoom1.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterSecrectRoom1()
    {
        GameStateManager.Instance.SetGameState(GameState.CUTS);
        StartCoroutine(BreakInto());

    }

    IEnumerator BreakInto()
    {
        _entrance.Play();
        yield return new WaitForSeconds((float)_entrance.duration);
        _secrectRoom1.SetActive(true);
        GameStateManager.Instance.SetGameState(GameState.PLAY);
    }
}
