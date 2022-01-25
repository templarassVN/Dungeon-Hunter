using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] bool activable;
    [SerializeField] float _time_gap;
    [SerializeField] bool _isActive = false;
    float _curr_t = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(!activable)
            _isActive = true;
            
       
        GetComponent<Animator>().SetBool("Active", true);
        
    }

    // Update is called once per frame
    void Update()
    {
        _curr_t += Time.deltaTime;
        if(_curr_t >= _time_gap)
        {
            _curr_t -= _time_gap;
            SwapState();
        }
    }

    void SwapState()
    {
        _isActive = !_isActive;
        GetComponent<Animator>().SetBool("Active", _isActive);
    }

    public bool isActive {
        get { return _isActive; }
        set { _isActive = value; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isActive)
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (playerController != null)
            {
                PlayerController.instance.getHit(-1);
            }
        } 
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isActive)
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (playerController != null)
            {
                PlayerController.instance.getHit(-1);
            }
        }
    }

}
