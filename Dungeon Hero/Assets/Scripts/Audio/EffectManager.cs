using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField]
    AudioClip[] _sound;
    AudioSource _main;
    public static EffectManager Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        _main = GetComponent<AudioSource>();
    }

    public void HighlightButton()
    {
        _main.clip = _sound[0];
        _main.Play();
    }
}
