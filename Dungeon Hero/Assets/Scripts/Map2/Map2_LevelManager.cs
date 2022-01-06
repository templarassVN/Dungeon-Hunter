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
    Transform _Player;
    [SerializeField]
    float _speed = 1;
    private void Awake()
    {
        _maincam = Camera.main;
        
    }
    void Start()
    {
        PlayableDirector director = GetComponent<PlayableDirector>();
        UIController.Instance.SetGameState(GameState.CUTS);
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
        UIController.Instance.SetGameState(GameState.PLAY);
    }
}
