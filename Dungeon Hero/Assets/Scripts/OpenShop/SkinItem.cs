using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinItem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Sprite _skin;
    [SerializeField]
    GameObject _PressE;
    bool _inbuyZone = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider != null && collision.collider.tag == "Player")
        {
            _inbuyZone = true;
            _PressE.SetActive(true);
         
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision != null && collision.tag == "Player")
        {
            Debug.Log("press");

        }
       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider != null && collision.collider.tag == "Player")
        {
            _PressE.SetActive(false);
        }
    }
}
