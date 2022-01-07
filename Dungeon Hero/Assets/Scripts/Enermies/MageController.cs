using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageController : RangerController
{
    public float rangeToRun = 3f;
    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    protected override void Move()
    {
         if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < rangeToRun)
        {
            moveDirection = transform.position - PlayerController.instance.transform.position;
            animator.SetBool("IsMoving", true);
        }
        else
        {
            moveDirection = Vector3.zero;
            animator.SetBool("IsMoving", false);
        }
        moveDirection.Normalize();
        if ((PlayerController.instance.transform.position - transform.position).x < 0) {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        rigidbody2d.velocity = moveDirection * speed;
    }

    protected override void Attack()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < attackRange)
        {
            attackCounter -= Time.deltaTime;
            if (1 - Time.deltaTime <= attackCounter && attackCounter <= 1) {
                animator.SetTrigger("Attack");
            }
            if (attackCounter <= 0)
            {
                attackCounter = attackSpeed;
                Instantiate(attackType, attackPoint.position + Vector3.up * 0.5f, attackPoint.rotation);
                Instantiate(attackType, attackPoint.position, attackPoint.rotation);
                Instantiate(attackType, attackPoint.position + Vector3.down * 0.5f, attackPoint.rotation);
            }
        }
    }

    public override void TakedDamage(int damage)
    {
        animator.SetTrigger("Hit");
        health -= damage;
        Instantiate(hitEffect, transform.position, transform.rotation);
        if (health <= 0)
        {
            Destroy(gameObject);

            int selectedSplatter = Random.Range(0, deathSplatters.Length);
            int rotationSplatter = Random.Range(0, 360);

            Instantiate(deathSplatters[selectedSplatter], transform.position, Quaternion.Euler(0, 0, rotationSplatter));
        }
    }
}
