using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 moveDirection;
    public Rigidbody2D rigidBody;
    public Transform gunArm;
    private Camera camera;
    public GameObject bullet;
    public Transform firePos;
    public float attackSpeed;
    private float timeCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        moveDirection.Normalize();
        //transform.position += new Vector3(moveDirection.x * Time.deltaTime *moveSpeed, moveDirection.y * Time.deltaTime * moveSpeed, 0f);

        rigidBody.velocity = moveDirection * moveSpeed;

        Vector3 mousePosition = Input.mousePosition;
        Vector3 screenPoint = camera.WorldToScreenPoint(transform.localPosition);

        if(mousePosition.x < screenPoint.x){
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            gunArm.localScale = new Vector3(-1.0f, -1.0f, 1.0f);
        }else{
            transform.localScale = Vector3.one;
            gunArm.localScale = Vector3.one;
        }
        

        //rotate gun arm
        Vector2 offset = new Vector2(mousePosition.x - screenPoint.x, mousePosition.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        gunArm.rotation = Quaternion.Euler(0,0,angle);

        if (Input.GetMouseButtonDown(0)){
            //Instantiate(bullet, firePos.position, firePos.rotation);
        }

        if (Input.GetMouseButton(0)){
            timeCount -= Time.deltaTime;
            if (timeCount <=0) {
                Instantiate(bullet, firePos.position, firePos.rotation);
                timeCount = attackSpeed;
            }
        }
    }
}
