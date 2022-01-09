using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnermyController : EnemyController {
    protected override void Attack()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < attackRange)
        {
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                animator.SetTrigger("Attack");
                attackCounter = attackSpeed;
                Instantiate(attackType, attackPoint.position, attackPoint.rotation);
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