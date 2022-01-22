using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUIController : MonoBehaviour
{
    public static IngameUIController instance;
    public Slider healthSlider;
    public Text healthText;
    
    public Slider armorSlider;
    public Text armorText;

    public Text coinText;
    void Awake(){
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ChangeMaxHealth(int amount)
    {
        healthSlider.maxValue = amount;
    }

    public void ChangeCurrentHealth(int amount)
    {
        healthSlider.value = amount;
    }

    public void ChangeHealthText()
    {
        healthText.text = healthSlider.value.ToString() + '/' + healthSlider.maxValue.ToString();
    }

    public void ChangeMaxArmor(int amount)
    {
        armorSlider.maxValue = amount;
        ChangeArmorText();
    }

    public void ChangeCurrentArmor(int amount)
    {
        armorSlider.value = amount;
        ChangeArmorText();
    }

    public void ChangeArmorText()
    {
        armorText.text = armorSlider.value.ToString() + '/' + armorSlider.maxValue.ToString();
    }

    public void ChangeCoinText(int amount)
    {
        coinText.text = amount.ToString();
    }
}
