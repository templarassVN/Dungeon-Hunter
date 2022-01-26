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
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if(playerController != null)
        {
            EffectManager.Instance.PlaySFX(9);
            Destroy(gameObject);
            playerController.ChangeCoin(_amount);
        }
    }
}
