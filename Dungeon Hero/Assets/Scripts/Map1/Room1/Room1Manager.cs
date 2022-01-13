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
    [SerializeField]
    GameObject _Timer;
    [SerializeField]
    GameObject Door;
    // Start is called before the first frame update
    void Start()
    {
        _Timer.SetActive(false);
        _secrectRoom1.SetActive(false);
        Door.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterSecrectRoom1()
    {
        GameStateManager.Instance.SetGameState(GameState.CUTS);
        StartCoroutine(BreakIntoSecrect1());

    }

    public void EnterRoom1()
    {
        _Timer.SetActive(true);
    }

    IEnumerator BreakIntoSecrect1()
    {
        _entrance.Play();
        yield return new WaitForSeconds((float)_entrance.duration);
        _secrectRoom1.SetActive(true);
        GameStateManager.Instance.SetGameState(GameState.PLAY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnterRoom1();
        GetComponent<BoxCollider2D>().enabled = false;
        Door.SetActive(true);

    }
}
