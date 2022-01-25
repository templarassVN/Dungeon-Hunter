using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletController : EnermyBulletController
{
    float time;

    public bool isType2 = false;

    public float timeToDestroy = 3f;

    // Start is called before the first frame update
    protected override void Start()
    {
        if (isType2)
        {
            Debug.Log("type2");
            direction = PlayerController.instance.transform.position - transform.position;
            direction.Normalize();
        }
        else
        {
            Debug.Log("type1");
            direction = transform.right;
        }
    }

    protected override void Update()
    {
        base.Update();
        if (isType2)
        {
            if (speed > 0)
            {
                speed -= Time.deltaTime;
            }
            else
            {
                timeToDestroy -= Time.deltaTime;
                if (timeToDestroy < 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

}
