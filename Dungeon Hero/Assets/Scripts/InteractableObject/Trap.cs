using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] bool activable;
    [SerializeField] float _time_gap;
    [SerializeField] bool _isActive;
    [SerializeField] float _curr_t = 0;
    float _time_hit = 1f;
    float _curr_time_hit = 0;
    bool _iscd = false;
    // Start is called before the first frame update
    private void OnEnable()
    {
        if (!activable)
            _isActive = true;

        GetComponent<Animator>().SetBool("Active", _isActive);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _curr_t += Time.deltaTime;
        if(activable)
            if(_curr_t >= _time_gap)
            {
                _curr_t -= _time_gap;
                SwapState();
            }
        if(_iscd)
        {
            _curr_time_hit += Time.deltaTime;
            if(_curr_time_hit >= 1)
            {
                _iscd = false;
                _curr_time_hit = 0;
            }
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

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isActive)
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (playerController != null)
            {
                Debug.Log("a");
                if (!_iscd)
                {
                    PlayerController.instance.getHit(-1);
                    _iscd = true;
                }
            }
        }
    }

}
