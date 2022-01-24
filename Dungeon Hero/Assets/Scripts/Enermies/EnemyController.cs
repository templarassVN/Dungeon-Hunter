using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 150;

    public float speed = 3f;
    public int rateAppear = 1;
    protected Rigidbody2D rigidbody2d;
    protected Vector3 moveDirection;

    public float rangeToChasePlayer = 7f;

    protected Animator animator;

    [SerializeField]
    protected GameObject[] deathSplatters;

    [SerializeField]
    protected ParticleSystem hitEffect;
    public float attackSpeed;
    protected float attackCounter;
    public float attackRange;

    [SerializeField]
    protected GameObject attackType;

    [SerializeField]
    protected Transform attackPoint;

    [SerializeField]
    protected SpriteRenderer body;

    [SerializeField]
    protected GameObject[] itemsToDrop;
    
    [SerializeField]
    protected float itemDropPercent;

    // Start is called before the first frame update
    virtual protected void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        attackCounter = attackSpeed;
        float randomSpeed = Random.Range(-0.5f, 1f);
        speed += randomSpeed;
    }

    // Update is called once per frame
    virtual protected void Update()
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

            // drop item
            float dropChance = Random.Range(0, 100);
            if (dropChance < itemDropPercent) {
                int randomItem = Random.Range(0, itemsToDrop.Length);
                Instantiate(itemsToDrop[randomItem], transform.position, transform.rotation);
            }
        }
    }

    public void UpgradeStreng(int plusHealth, int plusSpeed, float plusAttackSpeed) {
        health += plusHealth;
        speed += plusSpeed;
        attackSpeed -= plusAttackSpeed;
    }
}
