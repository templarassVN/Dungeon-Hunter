using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Savior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerController = collision.GetComponent<PlayerController>();
        if (playerController != null)
        {
            EffectManager.Instance.PlaySFX(9);
            Destroy(gameObject);
        }
    }
}
