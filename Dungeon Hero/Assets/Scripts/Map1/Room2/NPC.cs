using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    [SerializeField]
    GameObject _UI_PressF;
    [SerializeField]
    GameObject Dialog;
    bool _isOpen = false;
    [SerializeField]
    bool _accepted = false;
    [SerializeField]
    bool _isfinish = false;

    [SerializeField]
    RoomManager room2Manager;

    void Start()
    {
        _UI_PressF.SetActive(false);
        Dialog.SetActive(false);
    }

    private void Update()
    {
        if (_isOpen && GameStateManager.Instance.State.Equals(GameState.PLAY))
        {
            if (Input.GetKey(KeyCode.F))
            {
                GameStateManager.Instance.SetGameState(GameState.CUTS);
                Dialog.SetActive(true);
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider != null && collision.collider.name == "Player" && !room2Manager.isFinished)
        {
            _UI_PressF.SetActive(true);
            _isOpen = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider != null && collision.collider.name == "Player")
        {
            _UI_PressF.SetActive(false);
            _isOpen = false;
        }
    }

    public bool isAccepted
    {
        get { return _accepted; }
        set { _accepted = value; }
    }

    public bool isFinished
    {
        get { return _isfinish; }
        set { _isfinish = value; }
    }
}
