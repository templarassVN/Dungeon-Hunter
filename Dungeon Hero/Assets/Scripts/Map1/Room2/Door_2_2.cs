using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_2_2 : MonoBehaviour
{
    bool _isOpen = false;

    ///Variable
    ///
    [SerializeField]
    GameObject _UI_PressE;
    [SerializeField]
    RoomManager _mainroom;
   
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
                
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider != null && collision.collider.name == "Player")
        {
            if (_mainroom.isFinished)
            {
                _UI_PressE.SetActive(true);
                _isOpen = true;
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
