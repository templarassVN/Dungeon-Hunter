using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletController : EnermyBulletController
{
    // Start is called before the first frame update
    protected override void Start()
    {
        direction = transform.right;
    }

    // Update is called once per frame
    // protected override void Update()
    // {
    //     transform.position += direction * speed * Time.deltaTime;
    //     // if (!BossController.instance.gameObject.activeInHierarchy)
    //     // {
    //     //     Destroy(gameObject);
    //     // }

    // }
}
