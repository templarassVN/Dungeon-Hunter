using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 7.5f;
    private Rigidbody2D rigidBody;
    public float timeDestroy = 2.0f;
    float timeCount = 0.0f;
      public int damage; 
    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody.velocity = transform.right * speed;
        timeCount += Time.deltaTime;
        if (timeCount >= timeDestroy)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other){
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        EnemyController e = other.GetComponent<EnemyController>();
        if (e != null) {
            e.TakedDamage(damage);
        }
    }
}
