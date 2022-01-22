using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    int _numsSce;
    GameObject _player;
    PlayerController _playerScript;
    private void Awake()
    {
        _player = GameObject.Find("Player");
        _playerScript = _player.GetComponent<PlayerController>();
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
        if (temp.name == "Player")
        {
            Load_Scene();
        }
    }

    void Load_Scene()
    {
        _player.transform.position = new Vector3(-24f, 3f, 0);
        _player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        SceneManager.LoadScene(_numsSce);
        Debug.Log("a");
    }
}
