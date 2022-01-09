using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurController : MeleeEnermyController
{
    public float timeSummon = 10f;
    float summonTimer = 0f;

    void Awake()
    {
        summonTimer = 2f;
    }

    [SerializeField]
    GameObject[] creeps;
    protected override void Attack()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < attackRange)
        {
            // spin
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                animator.SetTrigger("Attack");
                Instantiate(attackType, attackPoint.position, attackPoint.rotation);
                attackCounter = attackSpeed;
            }
        }
        // summon creep
        summonTimer -= Time.deltaTime;
        if (1 - Time.deltaTime <= summonTimer && summonTimer <= 1)
        {
            animator.SetTrigger("Summon");
        }
        if (summonTimer <= 0)
        {
            int chooseCreep = Random.Range(0, 2);
            Instantiate(creeps[chooseCreep], transform.position + Vector3.up * 2f, transform.rotation);
            chooseCreep = Random.Range(0, 2);
            Instantiate(creeps[chooseCreep], transform.position + Vector3.left * 2f, transform.rotation);
            chooseCreep = Random.Range(0, 2);
            Instantiate(creeps[chooseCreep], transform.position + Vector3.right * 2f, transform.rotation);
            chooseCreep = Random.Range(0, 2);
            Instantiate(creeps[chooseCreep], transform.position + new Vector3(-2, -2, 0), transform.rotation);
            chooseCreep = Random.Range(0, 2);
            Instantiate(creeps[chooseCreep], transform.position + new Vector3(2, -2, 0), transform.rotation);
            summonTimer = timeSummon;
        }
    }
}
