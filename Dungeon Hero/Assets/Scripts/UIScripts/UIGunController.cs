using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGunController : MonoBehaviour
{
    public Image gunUI;
    public Text gunName;
    public Text gunSpeed;
    public Text gunDamage;

    public static UIGunController instance;

    void Awake() {
        instance = this;   
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("run");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeGunUI(Sprite spriteGunUI) {
        gunUI.sprite = spriteGunUI;
    }
}
