using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    Room1Manager _room1Manager;
    [SerializeField]
    SecrecRoom1 _Scerectroom1;
    ///Variable
    ///
    [SerializeField]
    GameObject _UI_PressE;
    bool _isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        _UI_PressE.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (_isOpen && GameStateManager.Instance.State.Equals(GameState.PLAY))
        {
            
            if (Input.GetKey(KeyCode.E))
            {
                gameObject.SetActive(false);
                _room1Manager.EnterSecrectRoom1();
                
            }
        }

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider != null && collision.collider.name == "Player")
        {
            if (collision.collider.transform.position.y < transform.position.y)
            {
                _UI_PressE.SetActive(true);
                _isOpen = true;
            }
            else
            {
                if(_Scerectroom1.IsFinished)
                {
                    _UI_PressE.SetActive(true);
                    _isOpen = true;
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider != null && collision.collider.name == "Player")
        {
            _UI_PressE.SetActive(false);
            _isOpen = false;
        }
    }
}
