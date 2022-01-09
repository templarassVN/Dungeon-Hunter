using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinItem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    SpriteRenderer _skin;
    [SerializeField]
    GameObject _PressE;
    bool _inbuyZone = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_inbuyZone)
        {
            if (Input.GetKeyDown("e"))
            {
                _skin.sprite = PlayerController.instance.ChangeSkin(_skin.sprite);
            }
        }
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.tag);
        if (collision.collider != null && collision.collider.tag == "Player")
        {
            _PressE.SetActive(true);
            _inbuyZone = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider != null && collision.collider.tag == "Player")
        {
            _PressE.SetActive(false);
            _inbuyZone = false;
        }
    }
}
