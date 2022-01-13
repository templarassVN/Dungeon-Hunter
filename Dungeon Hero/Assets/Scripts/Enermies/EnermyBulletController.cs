using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyBulletController : MonoBehaviour
{
    public float speed = 3f;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = PlayerController.instance.transform.position - transform.position;
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other);
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController != null) {
            playerController.getHit(-1);
        }
        Destroy(gameObject);
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
