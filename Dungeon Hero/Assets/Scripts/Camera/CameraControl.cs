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
        
    }
    void Start()
    {
        _Player = _Player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_Player.transform.position.x,
                                           _Player.transform.position.y,
                                           transform.position.z);
    }
}
