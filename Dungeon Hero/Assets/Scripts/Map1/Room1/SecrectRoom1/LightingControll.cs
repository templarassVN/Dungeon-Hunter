using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingControll : MonoBehaviour
{
    Animator _mAnimator;

    [SerializeField]
    float _timegap = 3f;
    // Start is called before the first frame update
    void Start()
    {
        _mAnimator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
