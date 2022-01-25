using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : EnemyController
{
    public static BossController instance;

    [SerializeField]
    BossAction[] actions;
    int currentAction;
    float actionCounter;

    [SerializeField]
    BossSequence[] sequences;
    int currentSequence;


    float shotCounter;

    int damageColision = 2;
    float timeDamageColision = 1f;
    float damageColisionCounter = 1f;

    // spin bullet
    public float spin_speed = 100f;
    float time;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        actions = sequences[currentSequence].actions;

        rigidbody2d = GetComponent<Rigidbody2D>();
        actionCounter = actions[currentAction].actionLength;

        UIBossController.instance.bossHealthBar.maxValue = health;
        UIBossController.instance.bossHealthBar.value = health;
    }

    // // Update is called once per frame
    protected override void Update()
    {
        if (actionCounter > 0)
        {
            actionCounter -= Time.deltaTime;
            Move();
            Attack();
        }
        else
        {
            currentAction++;
            if (currentAction >= actions.Length)
            {
                currentAction = 0;
            }
            actionCounter = actions[currentAction].actionLength;
        }
    }

    void FixedUpdate()
    {
        if (actions[currentAction].shouldSpinShoot)
        {
            time += Time.fixedDeltaTime;
            attackPoint.transform.rotation = Quaternion.Euler(0, 0, time * spin_speed);
        }
    }

    protected override void Move()
    {
        // handle movement
        moveDirection = Vector2.zero;
        if (actions[currentAction].shouldMove)
        {
            if (actions[currentAction].shouldChasePlayer)
            {
                moveDirection = PlayerController.instance.transform.position - transform.position;
                moveDirection.Normalize();
            }
            if (actions[currentAction].shouldMoveToPoint)
            {
                moveDirection = actions[currentAction].pointToMove.position - transform.position;
                moveDirection.Normalize();
            }
        }
        rigidbody2d.velocity = moveDirection * actions[currentAction].moveSpeed;
    }

    protected override void Attack()
    {
        // handle shooting
        if (actions[currentAction].shouldShoot)
        {
            if (!actions[currentAction].attackType2)
            {
                shotCounter -= Time.deltaTime;
                if (shotCounter <= 0)
                {
                    shotCounter = actions[currentAction].timeBetweenShots;
                    foreach (Transform t in actions[currentAction].shotPoints)
                    {
                        Instantiate(actions[currentAction].itemsToShould[0], t.position, t.rotation);
                    }
                }
                if (actions[currentAction].shouldSummon) {
                    Instantiate(actions[currentAction].itemsToSummon, transform.position + new Vector3(3, -3, 0), transform.rotation);
                    Instantiate(actions[currentAction].itemsToSummon, transform.position + new Vector3(3, 3, 0), transform.rotation);
                    Instantiate(actions[currentAction].itemsToSummon, transform.position + new Vector3(-3, 3, 0), transform.rotation);
                    Instantiate(actions[currentAction].itemsToSummon, transform.position + new Vector3(-3, -3, 0), transform.rotation);
                    actions[currentAction].shouldSummon = false;
                }
            }
            else
            {
                shotCounter -= Time.deltaTime;
                if (shotCounter <= 0)
                {
                    shotCounter = actions[currentAction].timeBetweenShots;
                    for (int i = 0; i < actions[currentAction].numberBullet2; i++)
                    {
                        int randomTypeBullet = Random.Range(0, actions[currentAction].itemsToShould.Length);
                        float randomPositionX = Random.Range(-3f, 3f);
                        float randomPositionY = Random.Range(-3f, 3f);
                        float positionX = attackPoint.position.x + randomPositionX;
                        float positionY = attackPoint.position.y + randomPositionY;
                        GameObject bullet = actions[currentAction].itemsToShould[randomTypeBullet];
                        Instantiate(bullet, new Vector2(positionX, positionY), attackPoint.rotation);
                    }
                }
            }
        }
    }

    public override void TakedDamage(int damage)
    {
        base.TakedDamage(damage);
        if (health <= 0)
        {
            UIBossController.instance.bossHealthBar.gameObject.SetActive(false);
        }
        else if (health <= sequences[currentSequence].endSequenceHealth && currentSequence < sequences.Length - 1)
        {
            currentSequence++;
            actions = sequences[currentSequence].actions;
            currentAction = 0;
            actionCounter = actions[currentAction].actionLength;
        }
        UIBossController.instance.bossHealthBar.value = health;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            damageColisionCounter -= Time.deltaTime;
            if (damageColisionCounter <= 0)
            {
                playerController.getHit(-damageColision);
                damageColisionCounter = timeDamageColision;
            }

        }
    }
}

[System.Serializable]
public class BossAction
{
    [Header("Action")]
    public float actionLength;

    // action
    public bool shouldMove;
    public bool shouldChasePlayer;
    public bool shouldMoveToPoint;
    public Transform pointToMove;

    // speed
    public float moveSpeed;

    // shoot
    public bool shouldShoot;
    public bool shouldSpinShoot;
    public GameObject[] itemsToShould;
    public float timeBetweenShots;
    public Transform[] shotPoints;

    public bool attackType2;
    public int numberBullet2;

    // summon
    public bool shouldSummon;
    public GameObject itemsToSummon;
}

[System.Serializable]
public class BossSequence
{
    [Header("Sequence")]

    public BossAction[] actions;

    public int endSequenceHealth;
}
