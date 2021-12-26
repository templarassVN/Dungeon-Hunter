using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance; 

    [SerializeField]
    private float _speedMove = 5;
    private Rigidbody2D _playerrb;
    [SerializeField]
    private Transform _skin;

    private void Awake()
    {
           instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _playerrb = GetComponent<Rigidbody2D>();
        _skin.position = transform.position;
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

    

  
    
}
