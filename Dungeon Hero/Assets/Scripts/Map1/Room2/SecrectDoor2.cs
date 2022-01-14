using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecrectDoor2 : MonoBehaviour
{
    bool _isOpen = false;

    ///Variable
    ///
    [SerializeField]
    GameObject _UI_PressE;
    [SerializeField]
    NPC _npc;
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
            if (_npc.isFinished)
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
