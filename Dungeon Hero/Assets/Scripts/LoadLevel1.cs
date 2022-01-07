using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel1 : MonoBehaviour
{
    GameObject _player ;
    Sub_PlayerController _playerScript;
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerScript = _player.GetComponent<Sub_PlayerController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject temp = collision.gameObject;
        if(temp.tag == "Player")
        {
            LoadScene_1();
        }
    }

    void LoadScene_1()
    {
        _player.transform.position = new Vector3(-4.71f, -12f, 0);
        _player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        SceneManager.LoadScene(1);

    }

   
}
