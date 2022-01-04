using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _player;
    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y,-10);

    }
}
