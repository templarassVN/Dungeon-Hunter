using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other){
        PlayerController controller = other.GetComponent<PlayerController>();
        if (controller != null){
            //controller.getHit(-1);
        }
    }
}
