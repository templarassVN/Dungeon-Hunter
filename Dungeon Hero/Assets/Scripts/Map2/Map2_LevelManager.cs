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
        
    }
    private IEnumerator PlayOpenMap2(PlayableDirector playableDirector)
    {
        playableDirector.Play();
        yield return new WaitForSeconds((float)playableDirector.duration);
        GameStateManager.Instance.SetGameState(GameState.PLAY);
        Map2_StageChange();
    }

    public void Map2_StageChange()
    {
        _Map2_Stage.SetActive(false);
        _Map2_Stage.SetActive(true);
    }
}
