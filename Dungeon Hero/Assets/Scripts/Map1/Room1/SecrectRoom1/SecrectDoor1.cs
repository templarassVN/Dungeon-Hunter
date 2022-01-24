using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecrectDoor1 : MonoBehaviour
{
    [SerializeField]
    GameObject _secrectRoom1;
    bool _isOpen = false;
    ///Variable
    ///
    [SerializeField]
    GameObject _UI_PressE;
    [SerializeField]
    Room1Control _Room1;
    // Start is called before the first frame update
    void Start()
    {
        _secrectRoom1.SetActive(false);
        _UI_PressE.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_isOpen && GameStateManager.Instance.State.Equals(GameState.PLAY))
        {
            if (Input.GetKey(KeyCode.E))
            {
                _secrectRoom1.SetActive(true);
                gameObject.SetActive(false);
                if (PlayerController.instance.transform.position.y < transform.position.y)
                {

                    Camera.main.orthographicSize = 2.5f;
                    _secrectRoom1.GetComponent<SecrecRoom1>().StartBreakInto();
                    MusicManager.Instance.changeGroup(3);
                }
                else
                    Camera.main.orthographicSize = 5f;
                
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider != null && collision.collider.name == "Player")
        {
            if (((collision.collider.transform.position.y < transform.position.y) && _Room1.Completechallenge())
                || ((collision.collider.transform.position.y >= transform.position.y) && _secrectRoom1.GetComponent<SecrecRoom1>().IsFinished))
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
