using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_A_B : MonoBehaviour
{
    bool _isOpen = false;

    ///Variable
    ///
    [SerializeField]
    GameObject _UI_PressE;
    [SerializeField]
    GameObject _room_to_close;
    [SerializeField]
    GameObject _room_to_open;
    // Start is called before the first frame update
    void Start()
    {
        _UI_PressE.SetActive(false);
        _room_to_open.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_isOpen && GameStateManager.Instance.State.Equals(GameState.PLAY))
        {

            if (Input.GetKey(KeyCode.E))
            {
                gameObject.SetActive(false);
                if (_room_to_open != null)
                    _room_to_open.SetActive(true);
                if (_room_to_close != null)
                    _room_to_close.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Room0Manager room0CloseManager = _room_to_close.GetComponent<Room0Manager>();
        if (room0CloseManager != null)
        {
            if (room0CloseManager.isFinish)
            {
                if (collision.collider != null && collision.collider.name == "Player")
                {
                    _UI_PressE.SetActive(true);
                    _isOpen = true;
                }
            }
        }
        Room1Manager room1CloseManager = _room_to_close.GetComponent<Room1Manager>();
        if (room1CloseManager != null)
        {
            if (room1CloseManager.isFinished)
            {
                if (collision.collider != null && collision.collider.name == "Player")
                {
                    _UI_PressE.SetActive(true);
                    _isOpen = true;
                }
            }
        }

        MainRoom room2CloseManager = _room_to_close.GetComponent<MainRoom>();
        if (room2CloseManager != null)
        {
            if (room2CloseManager.isFinished)
            {
                if (collision.collider != null && collision.collider.name == "Player")
                {
                    _UI_PressE.SetActive(true);
                    _isOpen = true;
                }
            }
        }

        Room3Manager room3CloseManager = _room_to_close.GetComponent<Room3Manager>();
        if (room3CloseManager != null)
        {
            if (room3CloseManager.isFinished)
            {
                if (collision.collider != null && collision.collider.name == "Player")
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
