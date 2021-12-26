using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform _player_tf;
    void Awake()
    {
        
    }

    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
        transform.position = new Vector3(_player_tf.position.x, _player_tf.position.y,-10);

    }
}
