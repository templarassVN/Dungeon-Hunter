using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShieldController : MonoBehaviour
{
    [SerializeField] GameObject _shield_effect;
    [SerializeField] Image _cd;
    [SerializeField] float _time_cd;
    float _cur_cd = 0;
    [SerializeField] float _time_active_effect;
    
    // Start is called before the first frame update
    void Start()
    {
        _cd.fillAmount = 0;
        
        _shield_effect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f"))
        {
            if (_cur_cd == 0f)
            {
                StartCoroutine(ShieldEffect());
                _cur_cd = _time_cd;
            }
        }
        
    }

    private void FixedUpdate()
    {
        _cur_cd = Mathf.Max(0,_cur_cd - Time.fixedDeltaTime);
        _cd.fillAmount = _cur_cd / _time_cd;
        
    }

    IEnumerator ShieldEffect()
    {
        _shield_effect.SetActive(true);
        yield return new WaitForSeconds(_time_active_effect);
        _shield_effect.SetActive(false);
    }

}
