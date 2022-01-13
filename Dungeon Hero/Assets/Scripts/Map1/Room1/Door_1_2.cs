using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_1_2 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject _GridRoom;
    [SerializeField]

    ///Variable
    GameObject _UI_PressE;
    bool _isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        _GridRoom.SetActive(true);
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
                _GridRoom.SetActive(false);

            }
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider != null && collision.collider.name == "Player")
        {
            _UI_PressE.SetActive(true);
            _isOpen = true;
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
