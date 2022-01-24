using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyBulletController : MonoBehaviour
{
    public float speed = 3f;
    public int damage = 1;
    protected Vector3 direction;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        direction = PlayerController.instance.transform.position - transform.position;
        direction.Normalize();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        Destroy(gameObject);
        PlayerController playerController = other.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.getHit(-damage);
        }
    }

    protected void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
