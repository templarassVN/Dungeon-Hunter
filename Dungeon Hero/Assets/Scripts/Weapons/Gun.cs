using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public float attackSpeed;
    private float timeCount = 0;
    Camera _main_cam;

    public string weaponName;
    public Sprite gunUI;

    // Start is called before the first frame update
    void Start()
    {
        _main_cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            timeCount -= Time.deltaTime;
            if (timeCount <= 0)
            {
                EffectManager.Instance.PlaySFX(1);
                Instantiate(bullet, firePos.position, firePos.rotation);
                timeCount = attackSpeed;
            }
        }
    }
}
