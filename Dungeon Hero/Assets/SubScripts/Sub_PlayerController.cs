using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sub_PlayerController : MonoBehaviour
{
    public static Sub_PlayerController Instance;
    /// <summary>
    /// Varialbe
    /// </summary>
    [SerializeField]
    float _speedMove = 5;
    bool _atMenu = false;

    /// <summary>
    /// Component
    /// </summary>
    private Rigidbody2D _playerrb;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        _playerrb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (!_atMenu && GameStateManager.Instance.State.Equals(GameState.PLAY))
            {
                GameStateManager.Instance.SetGameState(GameState.MENU);
            } else
            {
                GameStateManager.Instance.SetGameState(GameState.PLAY);
            }
            _atMenu = !_atMenu;
        }
    }
    private void FixedUpdate()
    {
        if(GameStateManager.Instance.State.Equals (GameState.PLAY))
            MoveWSAD();
        
    }

    void MoveWSAD()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 move = new Vector2(x, y);
        move.Normalize();
        _playerrb.velocity = move * _speedMove;
    }
}
