using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitRoomControl : MonoBehaviour
{
    // Start is called before the first frame update
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject temp = collision.gameObject;
        if (temp.name == "Player")
        {
            GameStateManager.Instance.isFinishMap1 = true;
        }
    }
}
