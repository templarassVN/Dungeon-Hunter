using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFollowing : EnermyBulletController
{
    public float waitTime = 1f;

    //public GameObject tail;
    // Start is called before the first frame update
    protected override void  Start()
    {

    }

    // Update is called once per frame
    protected override void Update()
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
}
