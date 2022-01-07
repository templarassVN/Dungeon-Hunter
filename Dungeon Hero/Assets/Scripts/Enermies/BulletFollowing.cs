using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFollowing : MonoBehaviour
{
    public float speed;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = PlayerController.instance.transform.position - transform.position;
        direction.Normalize();
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other) {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController != null) {
            // damage to player
        }
        Destroy(gameObject);
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
