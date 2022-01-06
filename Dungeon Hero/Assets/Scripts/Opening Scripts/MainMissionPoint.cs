using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMissionPoint : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject _UI_PressF;
    BoxCollider2D _boxCollider2D;
    int playerLayer = 1 << 3;
    
    void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position - transform.up;
        RaycastHit2D hit = Physics2D.BoxCast(_boxCollider2D.bounds.center,_boxCollider2D.bounds.size,0f,Vector2.down, 1f, playerLayer);
       
        if (hit.collider != null && hit.collider.tag == "Player")
        {
            _UI_PressF.SetActive(true);
            if (Input.GetKeyDown("f"))
            {
                
            }
        }
        else
            _UI_PressF.SetActive(false);
        
       }
}
