using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinItem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject _PressE;
    [SerializeField]
    GameObject _offer;
    [SerializeField]
    Text _price;

    /// <summary>
    /// Variable
    /// </summary>
    bool _inbuyZone = false;
    bool _isBought = false;
    [SerializeField]
    int _cost = 100;
    [SerializeField]
    GameObject _playerSkin;
    [SerializeField]
    GameObject _currSkin;
    void Start()
    {
        _playerSkin = GameObject.Find("Body");
        _price.text = _cost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (_inbuyZone)
        {
            if (Input.GetKeyDown("e"))
            {
                if(_isBought)
                    Exchange();
                else
                {
                    if (PlayerController.instance.Coin >= _cost)
                    {
                        PlayerController.instance.ChangeCoin(-_cost);
                        _isBought = true;
                        _offer.SetActive(false);
                        _PressE.SetActive(true);
                    }
                }
            }
        }
    }

    void Exchange()
    {
        SkinStat _player_skin_stat = _playerSkin.GetComponent<SkinStat>();
        SpriteRenderer _player_skin = _playerSkin.GetComponent<SpriteRenderer>();
        SkinStat _curr_skin_stat = _currSkin.GetComponent<SkinStat>();
        SpriteRenderer _curr_skin = _currSkin.GetComponent<SpriteRenderer>();
        var temp = _player_skin_stat.AmorPoint;
        _player_skin_stat.AmorPoint = _curr_skin_stat.AmorPoint;
        _curr_skin_stat.AmorPoint = temp;
        var temp1 = _player_skin_stat.SpeedPoint;
        _player_skin_stat.SpeedPoint = _curr_skin_stat.SpeedPoint;
        _curr_skin_stat.SpeedPoint = temp1;

        Debug.Log(_curr_skin.sprite);
        Debug.Log(_player_skin.sprite);
        Sprite _player_old = _player_skin_stat.ChangeSprite(_curr_skin.sprite);
        
        _curr_skin_stat.ChangeSprite(_player_old);
        PlayerController.instance.changeSkin(); 
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider != null && collision.collider.name== "Player")
        {
            if (_isBought)
            {
                _PressE.SetActive(true);
            } else
            {
                _offer.SetActive(true);
            }
            _inbuyZone = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider != null && collision.collider.name == "Player")
        {
            _PressE.SetActive(false);
            _offer.SetActive(false);
            _inbuyZone = false;
        }
    }

   
}
