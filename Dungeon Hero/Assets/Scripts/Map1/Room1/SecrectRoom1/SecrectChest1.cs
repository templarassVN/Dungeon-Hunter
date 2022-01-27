using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecrectChest1 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _prize;
    
    bool _isopen = false;

    [SerializeField]
    SecrecRoom1 secrecRoom1;
    void Start()
    {
        _prize.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider != null && collision.collider.name == "Player")
        {
            _isopen = true;
            GetComponent<Animator>().SetTrigger("Open");
            _prize.SetActive(true);
            secrecRoom1.IsFinished = true;
        }
    }

    public bool IsOpen
    {
        get { return _isopen; }
        set { _isopen = value; }
    }
}
