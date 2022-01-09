using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 4.0f;
    private Rigidbody2D rigidBody;
    private Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position.x += 0.1f * Time.deltaTime * speed;
        position.y += .1f * Time.deltaTime * speed;

        transform.position = position;
    }
}
