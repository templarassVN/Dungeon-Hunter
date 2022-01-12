using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_CameraController : MonoBehaviour
{
    [SerializeField]
    GameObject _mPlayer;
    // Start is called before the first frame update

    
    void Start()
    {
        _mPlayer = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(_mPlayer.transform.position.x, 0f, 9f),
                                           Mathf.Clamp(_mPlayer.transform.position.y, -1f, 0f),
                                           transform.position.z);
    }
}
