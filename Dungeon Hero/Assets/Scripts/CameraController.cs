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

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.position = _player_tf.position;
    }
}
