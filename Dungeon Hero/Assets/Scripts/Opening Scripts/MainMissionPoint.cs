using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMissionPoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject _UI_PressF;
    [SerializeField]
    GameObject Dialog;
    [SerializeField]
    GameObject mark;
    bool _mission = true;
    bool _isOpen = false;

    void Start()
    {
        Dialog.SetActive(false);
    }

    private void Update()
    {
        if (_isOpen && GameStateManager.Instance.State.Equals(GameState.PLAY))
        {
            if (Input.GetKey(KeyCode.F))
            {
                GameStateManager.Instance.SetGameState(GameState.CUTS);
                _mission = false;
                mark.SetActive(false);
                Dialog.SetActive(true);
            }
        }

        if (_mission)
            mark.SetActive(true);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider != null && collision.collider.name == "Player")
        {
            if (_mission)
            {
                _UI_PressF.SetActive(true);
                _isOpen = true;
            }
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
}
