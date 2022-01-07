using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxController : MonoBehaviour
{
    // Start is called before the first frame update
    public float castTime = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        castTime -= Time.deltaTime;
        if (castTime <= 0) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other);
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController != null) {
            // playerController nhận damage
        }
    }
}
