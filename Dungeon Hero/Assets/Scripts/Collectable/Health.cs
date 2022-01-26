using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        PlayerController playerController = other.GetComponent<PlayerController>();

        if (playerController != null) {
            if (playerController.CurrentHealth != playerController.MaxHealth) {
                playerController.getHit(1);
                Destroy(gameObject);
            }
        }
    }
}
