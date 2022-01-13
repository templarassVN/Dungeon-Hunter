using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public float attackSpeed;
    private float timeCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            timeCount -= Time.deltaTime;
            if (timeCount <= 0)
            {
                Instantiate(bullet, firePos.position, firePos.rotation);
                timeCount = attackSpeed;
            }
        }
    }
}
