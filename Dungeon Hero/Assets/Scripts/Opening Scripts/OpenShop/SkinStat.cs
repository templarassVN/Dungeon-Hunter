using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinStat : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float _speed;
    [SerializeField]
    int _armor = 1;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public float SpeedPoint
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public int AmorPoint
    {
        get { return _armor; }
        set { _armor = value; }
    }

    public Sprite ChangeSprite(Sprite other)
    {
        var temp = GetComponent<SpriteRenderer>().sprite;
        GetComponent<SpriteRenderer>().sprite = other;
        return temp;
    }
}
