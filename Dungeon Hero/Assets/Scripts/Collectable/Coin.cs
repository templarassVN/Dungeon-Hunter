using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    int _amount = 200;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && collision.name.Equals("Player"))
        {
            
            Destroy(gameObject);
        }

    }
}
