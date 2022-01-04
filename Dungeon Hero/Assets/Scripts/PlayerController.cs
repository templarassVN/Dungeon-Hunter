using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance; 

    [SerializeField]
    private float _speedMove = 5;
    private Rigidbody2D _playerrb;

    public bool _gotya = false;
   
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _playerrb = GetComponent<Rigidbody2D>();
        _gotya = false;  
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse_pos = Input.mousePosition;
        MoveWASD(); 
    }

    void MoveWASD()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 move = new Vector2(x, y);
        move.Normalize();
        _playerrb.velocity = move * _speedMove;
    }

    bool Got_1()
    {
        return _gotya;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        GameObject temp = collision.gameObject;
        
        if (temp.tag == "Finish")
        {
            _gotya = true;
        }
    }


}
