using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeItem : MonoBehaviour
{
    [SerializeField]
    GameObject imageGun;

    // Start is called before the first frame update
    [SerializeField]
    GameObject _offer;
    [SerializeField]
    Text _price;
    /// <summary>
    /// Variabl
    /// </summary>
    bool _inbuyZone = false;

    [SerializeField]
    int _cost = 100;

    [SerializeField]
    Gun itemToBuy;

    bool isBuy = false;

    [SerializeField]
    bool isHealth = true;

    void Start()
    {
        _price.text = _cost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (_inbuyZone && !isBuy)
        {
            if (Input.GetKeyDown("e"))
            {
                if (PlayerController.instance.Coin >= _cost)
                {
                    PlayerController.instance.ChangeCoin(-_cost);
                    if (isHealth)
                    {
                        PlayerController.instance.MaxHealth++;
                        PlayerController.instance.CurrentHealth++;
                        PlayerController.instance.ChangeHealth(0);
                    }
                    else
                    {
                        PlayerController.instance.availableGun.Add(itemToBuy);
                        PlayerController.instance.CurrentGun++;
                        PlayerController.instance.SwitchGun();
                        imageGun.SetActive(false);
                        _offer.SetActive(false);
                        isBuy = true;
                    }
                }
            }
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isBuy)
        {
            if (collision.collider != null && collision.collider.name == "Player")
            {
                _offer.SetActive(true);
                _inbuyZone = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!isBuy)
        {
            if (collision.collider != null && collision.collider.name == "Player")
            {
                _offer.SetActive(false);
                _inbuyZone = false;
            }
        }
    }
}
