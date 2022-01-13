using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int maxHealth;
    public int maxArmor;
    public int currentHealth;
    public int currentArmor;
    void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        IngameUIController.instance.healthSlider.maxValue = maxHealth;
        IngameUIController.instance.healthSlider.value = currentHealth;
        IngameUIController.instance.armorText.text = currentHealth.ToString() + '/' + maxHealth.ToString();

        IngameUIController.instance.armorSlider.maxValue = maxArmor;
        IngameUIController.instance.armorSlider.value = currentArmor;
        IngameUIController.instance.armorText.text = currentArmor.ToString() + '/' + maxArmor.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(){
        currentHealth --;
        if (currentHealth <= 0){
            PlayerController.instance.gameObject.SetActive(false);
        }
    }
}
