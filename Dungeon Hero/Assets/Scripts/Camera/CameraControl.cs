using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float _speed = 5f;
    public bool active = false;

    Camera main;
    [SerializeField]
    Transform _Player;
    private void Awake()
    {
        _Player = GameObject.Find("Player").transform;
    }
    void Start()
    {
        main = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStateManager.Instance.State.Equals(GameState.PLAY))
            transform.position = new Vector3(
                                      Mathf.Lerp(transform.position.x, _Player.position.x, _speed),
                                      Mathf.Lerp(transform.position.y, _Player.position.y, _speed),
                                      transform.position.z);

    }
}
