using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeItem : MonoBehaviour
{
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
    
    void Start()
    {
        _price.text = _cost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (_inbuyZone)
        {
            if (Input.GetKeyDown("e"))
            {
                if (PlayerController.instance.Coin >= _cost)
                {
                    PlayerController.instance.ChangeCoin(-_cost);
                    PlayerController.instance.MaxHealth += 1;
                    PlayerController.instance.ChangeHealth(0) ;
                }
            }
        }

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider != null && collision.collider.name == "Player")
        {
            _offer.SetActive(true);
            _inbuyZone = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider != null && collision.collider.name == "Player")
        {
            _offer.SetActive(false);
            _inbuyZone = false;
        }
    }
}
