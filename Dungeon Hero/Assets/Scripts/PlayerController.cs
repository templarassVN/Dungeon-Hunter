using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Component
    /// </summary>
    private Vector2 moveDirection;
    private Rigidbody2D rigidBody;
    public Transform gunArm;
    private Camera camera;
    public GameObject bullet;
    public Transform firePos;

    [SerializeField]
    private SpriteRenderer _mSpriteRender;

    /// <summary>
    /// Variable
    /// </summary> 
    public float moveSpeed;
    public float attackSpeed;
    private float timeCount = 0;
    [SerializeField]
    int _money = 100;
    public static PlayerController instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        camera = Camera.main;
        _mSpriteRender.GetComponent<SpriteRenderer>();
        UICoinController.Instance.ChangeText(_money);
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        moveDirection.Normalize();
        //transform.position += new Vector3(moveDirection.x * Time.deltaTime *moveSpeed, moveDirection.y * Time.deltaTime * moveSpeed, 0f);

        rigidBody.velocity = moveDirection * moveSpeed;

        Vector3 mousePosition = Input.mousePosition;
        Vector3 screenPoint = camera.WorldToScreenPoint(transform.localPosition);

        if(mousePosition.x < screenPoint.x){
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            gunArm.localScale = new Vector3(-1.0f, -1.0f, 1.0f);
        }else{
            transform.localScale = Vector3.one;
            gunArm.localScale = Vector3.one;
        }
        

        //rotate gun arm
        Vector2 offset = new Vector2(mousePosition.x - screenPoint.x, mousePosition.y - screenPoint.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        gunArm.rotation = Quaternion.Euler(0,0,angle);

        if (Input.GetMouseButtonDown(0)){
            //Instantiate(bullet, firePos.position, firePos.rotation);
        }

        if (Input.GetMouseButton(0)){
            timeCount -= Time.deltaTime;
            if (timeCount <=0) {
                Instantiate(bullet, firePos.position, firePos.rotation);
                timeCount = attackSpeed;
            }
        }
    }

    

    public int Money
    {
        get { return _money; }
        set { _money = value; }
    }

    public void ChangeMoney(int amount)
    {
        if (_money + amount < 0)
            return;
        _money += amount;
        UICoinController.Instance.ChangeText(_money);
    }

    public void ChangeSpeed(float amount)
    {
        moveSpeed += amount;
    }
}
