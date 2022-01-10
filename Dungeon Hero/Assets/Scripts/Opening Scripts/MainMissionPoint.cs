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
    bool _isOpen = false;

    
    void Start()
    {
        Dialog.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
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
        if (collision.collider != null && collision.collider.tag == "Player")
        {
            _UI_PressF.SetActive(true);
            _isOpen = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider != null && collision.collider.tag == "Player")
        {
            _UI_PressF.SetActive(false);
            _isOpen = false;
        }
    }
}
