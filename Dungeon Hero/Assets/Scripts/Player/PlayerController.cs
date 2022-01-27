using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Instance
    public static PlayerController instance;

    //Body
    [SerializeField]
    GameObject _mBody;

    //Moving
    public float moveSpeed = 7.0f;
    private Vector2 moveDirection;
    private float activeSpeed;

    //Rigidbody
    private Rigidbody2D rigidBody;

    //Camera
    private Camera cam;
    //Pause Game
    public GameObject pauseGame;

    public Transform gunArm;
    public List<Gun> availableGun = new List<Gun>();
    private int currentGun = 0;

    /*
        //Shooting 
        public GameObject bullet;
        public Transform firePos;
        public float attackSpeed;
        private float timeCount = 0;*/

    //Animator
    private Animator animator;

    //BodyRenderer
    public SpriteRenderer bodyRenderer;

    //Invicible
    private bool isInvicible = false;
    private float invicibleTime = 2.0f;
    private float invicibleCount = 0.0f;

    // Health & Armor
    private int maxHealth = 5;
    private int currentHealth;

    [SerializeField]
    private int maxArmor = 7;
    private int currentArmor = 0;

    //Get hit timeCount
    private float hitTimeCount = 0;
    private float hitTime = 2.0f;
    //private float recoverSpeed = 1.0f;

    //Dashing
    public float dashingSpeed = 10.0f;
    public float dashLength = .5f;
    public float dashCooldown = 1f;
    private float dashCounter = 0.0f;
    private float dashCoolCounter;

    //MoveBack
    public float moveBackSpeed = 10.0f;
    public float moveBackLength = .5f;
    public float moveBackCooldown = 1f;
    private float moveBackCounter = 0.0f;
    private float moveBackCoolCounter;

    //Speed Up
    public float speedUpSpeed = 15.0f;
    public float speedUpLength = 3.5f;
    public float speedUpCooldown = 5f;
    private float speedUpCounter = 0.0f;
    private float speedUpCoolCounter;

    private int coin = 0;

    private int live = 1;

    [SerializeField]
    Gun[] scriptGun;

    public int CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public int MaxArmor { get => maxArmor; set => maxArmor = value; }
    public int Coin { get => coin; set => coin = value; }
    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public int CurrentGun { get => currentGun; set => currentGun = value; }
    public int CurrentArmor { get => currentArmor; set => currentArmor = value; }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        // Init Player
        moveSpeed = _mBody.GetComponent<SkinStat>().SpeedPoint;
        maxArmor = _mBody.GetComponent<SkinStat>().AmorPoint;
        currentArmor = maxArmor;
        rigidBody = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        animator = GetComponent<Animator>();
        activeSpeed = moveSpeed;

        currentHealth = maxHealth;
        currentArmor = maxArmor;

        // If Load Game
        if (GameStateManager.Instance._loadGame)
        {
            coin = GameStateManager.Instance.Data.coin;
            currentHealth = GameStateManager.Instance.Data.health;
            maxHealth = GameStateManager.Instance.Data.maxHealth;
            maxArmor = GameStateManager.Instance.Data.maxArmor;
            currentGun = GameStateManager.Instance.Data.currentGun;
            availableGun.Clear();
            foreach(string gunName in GameStateManager.Instance.Data.availableGun) {
                switch (gunName) {
                    case "Pistol": {
                        availableGun.Add(scriptGun[0]);
                        break;
                    }
                    case "Uzi": {
                        availableGun.Add(scriptGun[1]);
                        break;
                    }
                    case "Machine": {
                        availableGun.Add(scriptGun[2]);
                        break;
                    }
                }
            }
            SwitchGun();
            transform.position = new Vector3(GameStateManager.Instance.Data.position.x, GameStateManager.Instance.Data.position.y, 0);
        }

        // Set up UI
        IngameUIController.instance.healthSlider.maxValue = maxHealth;
        IngameUIController.instance.healthSlider.value = currentHealth;
        IngameUIController.instance.healthText.text = currentHealth.ToString() + '/' + maxHealth.ToString();

        IngameUIController.instance.armorSlider.maxValue = maxArmor;
        IngameUIController.instance.armorSlider.value = currentArmor;
        IngameUIController.instance.armorText.text = currentArmor.ToString() + '/' + maxArmor.ToString();

        IngameUIController.instance.coinText.text = coin.ToString();

        // Gun UI
        UIGunController.instance.gunUI.sprite = availableGun[currentGun].gunUI;
        UIGunController.instance.gunName.text = availableGun[currentGun].weaponName;
        UIGunController.instance.gunSpeed.text = "Speed: " + availableGun[currentGun].attackSpeed;
        UIGunController.instance.gunDamage.text = "Damage: " + availableGun[currentGun].bullet.GetComponent<BulletController>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0 && live == 1)
        {
            IngameUIController.instance.DeathDisplay();
            return;
        }
        //Moving & Rotate Character
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
        moveDirection.Normalize();

        rigidBody.velocity = moveDirection * activeSpeed;

        Vector3 mousePosition = Input.mousePosition;
        if (cam == null)
            cam = Camera.main;
        Vector3 screenPoint = cam.WorldToScreenPoint(transform.localPosition);

        if (mousePosition.x < screenPoint.x)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            gunArm.localScale = new Vector3(-1.0f, -1.0f, 1.0f);
        }
        else
        {
            transform.localScale = Vector3.one;
            gunArm.localScale = Vector3.one;
        }


        //rotate gun arm
        Vector2 offset = new Vector2(mousePosition.x - screenPoint.x, mousePosition.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        gunArm.rotation = Quaternion.Euler(0, 0, angle);
        /*
                if (Input.GetMouseButton(0))
                {
                    timeCount -= Time.deltaTime;
                    if (timeCount <= 0)
                    {
                        Instantiate(bullet, firePos.position, firePos.rotation);
                        timeCount = attackSpeed;
                    }
                }*/

        // isMoving
        if (moveDirection != Vector2.zero)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        // isInvisible
        if (isInvicible)
        {
            invicibleCount += Time.deltaTime;
            if (invicibleCount > invicibleTime)
            {
                isInvicible = false;
                invicibleCount = 0;
            }
        }

        //Recover armor
        hitTimeCount += Time.deltaTime;
        if (hitTimeCount > hitTime)
        {
            int armor = (int)(hitTimeCount - hitTime);
            if (armor == 1)
            {
                if (currentHealth > 0)
                    ChangeArmor(armor);
                hitTimeCount = hitTime;
            }
        }

        //Dashing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dashCoolCounter <= 0 && dashCounter <= 0)
            {
                isInvicible = true;
                gameObject.layer = 14;
                activeSpeed = dashingSpeed;
                dashCounter = dashLength;
                animator.SetTrigger("dash");
            }
        }

        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                isInvicible = false;
                gameObject.layer = 8;
                activeSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }

        //MoveBack
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (moveBackCounter <= 0 && moveBackCounter <= 0)
            {
                activeSpeed = moveBackSpeed;
                moveBackCounter = moveBackLength;
                animator.SetTrigger("movingBack");
            }
        }

        if (moveBackCounter > 0)
        {
            moveBackCounter -= Time.deltaTime;
            if (moveBackCounter <= 0)
            {
                activeSpeed = moveSpeed;
                moveBackCoolCounter = moveBackCooldown;
            }
        }

        if (moveBackCoolCounter > 0)
        {
            moveBackCoolCounter -= Time.deltaTime;
        }

        // Speed up
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (speedUpCounter <= 0 && speedUpCounter <= 0)
            {
                activeSpeed = speedUpSpeed;
                speedUpCounter = speedUpLength;
                //animator.SetTrigger("speedUp");
            }
        }

        if (speedUpCounter > 0)
        {
            speedUpCounter -= Time.deltaTime;
            if (speedUpCounter <= 0)
            {
                activeSpeed = moveSpeed;
                speedUpCoolCounter = speedUpCooldown;
            }
        }

        if (speedUpCoolCounter > 0)
        {
            speedUpCoolCounter -= Time.deltaTime;
        }

        // Pause Game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Pause Game");
            GameStateManager.Instance.PauseGame();
            pauseGame.SetActive(true);
        }

        // SwitchGun
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (availableGun.Count > 0)
            {
                currentGun++;
                if (currentGun >= availableGun.Count)
                {
                    currentGun = 0;
                }
                SwitchGun();
            }
            else
            {
                Debug.LogError("No gun available");
            }
        }

    }

    void getInvisible()
    {
        bodyRenderer.color = new Color(bodyRenderer.color.r, bodyRenderer.color.g, bodyRenderer.color.b, .5f);
    }

    public void ChangeHealth(int health)
    {
        if (health < 0)
        {
            //animator.SetTrigger("Hit");
            if (isInvicible)
                return;
            hitTimeCount = 0;
            //this.PlaySound(hurtSound);
        }
        if (health > 0)
        {
            //animator.SetTrigger("Hit");

            //this.PlaySound(hurtSound);
        }
        currentHealth = Mathf.Clamp(currentHealth + health, 0, maxHealth);
        IngameUIController.instance.ChangeMaxHealth(maxHealth);
        IngameUIController.instance.ChangeCurrentHealth(currentHealth);


    }

    public void ChangeArmor(int armor)
    {
        if (armor < 0)
        {
            //animator.SetTrigger("Hit");
            if (isInvicible)
                return;
            hitTimeCount = 0;
            //this.PlaySound(hurtSound);
        }
        currentArmor = Mathf.Clamp(currentArmor + armor, 0, maxArmor);

        IngameUIController.instance.ChangeMaxArmor(maxArmor);
        IngameUIController.instance.ChangeCurrentArmor(currentArmor);


    }
    public void getHit(int damage)
    {
        if (damage > 0)
        {
            ChangeHealth(damage);
            return;
        }
        if (currentArmor == 0)
        {
            ChangeHealth(damage);
            return;
        }
        ChangeArmor(damage);
    }

    public void changeSkin()
    {
        maxArmor = _mBody.GetComponent<SkinStat>().AmorPoint;
        activeSpeed = _mBody.GetComponent<SkinStat>().SpeedPoint;
        IngameUIController.instance.ChangeMaxArmor(maxArmor);
    }
    public void ChangeCoin(int coins)
    {
        if (coin < 0)
        {
            return;
            //animator.SetTrigger("Hit");
            //this.PlaySound(hurtSound);
        }
        this.coin += coins;
        IngameUIController.instance.ChangeCoinText(coin);
    }

    public void SwitchGun()
    {
        UIGunController.instance.gunUI.sprite = availableGun[currentGun].gunUI;
        UIGunController.instance.gunName.text = availableGun[currentGun].weaponName;
        UIGunController.instance.gunSpeed.text = "Speed: " + availableGun[currentGun].attackSpeed;
        UIGunController.instance.gunDamage.text = "Damage: " + availableGun[currentGun].bullet.GetComponent<BulletController>().damage;
        foreach (Gun thegun in availableGun)
        {
            thegun.gameObject.SetActive(false);
        }

        availableGun[currentGun].gameObject.SetActive(true);
    }

}
