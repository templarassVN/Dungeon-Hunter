using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFollowing : MonoBehaviour
{
    public float speed;

    public float waitTime = 1f;
    Vector3 direction;

    //public GameObject tail;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime <= 0)
        {
            direction = PlayerController.instance.transform.position - transform.position;
            direction.Normalize();
            transform.position += direction * speed * Time.deltaTime;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            //tail.transform.rotation = Quaternion.Euler(angle + 180, 90, 0);
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.getHit(-1);
        }
        Destroy(gameObject);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
