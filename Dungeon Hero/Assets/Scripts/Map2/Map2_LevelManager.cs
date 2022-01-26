using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Map2_LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Camera _maincam;
    [SerializeField]
    private GameObject _Map2_Stage;

    private void Awake()
    {
        _maincam = Camera.main;
        MusicManager.Instance.PlaySheet(4);
        _Map2_Stage.SetActive(true);
    }
    void Start()
    {
        PlayableDirector director = GetComponent<PlayableDirector>();
        GameStateManager.Instance.SetGameState(GameState.CUTS);
        StartCoroutine(PlayOpenMap2((director)));
    }

    // Update is called once per frame
    void Update()
    {
        if(BossController.instance.health <= 0)
            MusicManager.Instance.PlaySheet(5);
    }
    private IEnumerator PlayOpenMap2(PlayableDirector playableDirector)
    {
        playableDirector.Play();
        yield return new WaitForSeconds((float)playableDirector.duration);
        GameStateManager.Instance.SetGameState(GameState.PLAY);
        _Map2_Stage.SetActive(false) ;
    }

    
}
