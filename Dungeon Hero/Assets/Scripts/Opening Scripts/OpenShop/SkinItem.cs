using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinItem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject _PressE;

    /// <summary>
    /// Variable
    /// </summary>
    bool _inbuyZone = false;
    [SerializeField]
    int _cost = 100;
    [SerializeField]
    GameObject _playerSkin;
    [SerializeField]
    GameObject _currSkin;
    void Start()
    {
        _playerSkin = GameObject.Find("Body");
    }

    // Update is called once per frame
    void Update()
    {
        if (_inbuyZone)
        {
            if (Input.GetKeyDown("e"))
            {
                Exchange();
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
            _PressE.SetActive(true);
            _inbuyZone = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider != null && collision.collider.name == "Player")
        {
            _PressE.SetActive(false);
            _inbuyZone = false;
        }
    }
}
