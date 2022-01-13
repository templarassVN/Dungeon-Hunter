using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecrectKey1 : MonoBehaviour
{
    [SerializeField]
    SecrecRoom1 _secrectRoom;
    // Start is called before the first frame update
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _secrectRoom.IsFinished = true;
        Destroy(gameObject);
    }
}
