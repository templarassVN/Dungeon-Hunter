using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 150;

    public float speed = 3f;
    protected Rigidbody2D rigidbody2d;
    protected Vector3 moveDirection;

    public float rangeToChasePlayer = 7f;

    protected Animator animator;

    public GameObject[] deathSplatters;

    public ParticleSystem hitEffect;
    public float attackSpeed;
    protected float attackCounter;
    public float attackRange;
    public GameObject attackType;
    public Transform attackPoint;

    public SpriteRenderer body;

    // Start is called before the first frame update
    protected void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        attackCounter = attackSpeed;
    }

    // Update is called once per frame
    protected void Update()
    {
        if (body.isVisible)
        {
            Move();
            Attack();
        }
    }

    virtual protected void Move()
    {
         if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < rangeToChasePlayer)
        {
            moveDirection = PlayerController.instance.transform.position - transform.position;
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

    virtual protected void Attack()
    {
        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < attackRange)
        {
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                attackCounter = attackSpeed;
                Instantiate(attackType, attackPoint.position, attackPoint.rotation);
            }
        }
    }

    virtual public void TakedDamage(int damage)
    {
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
