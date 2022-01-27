using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EffectManager : MonoBehaviour
{
    [SerializeField]
    AudioClip[] _sound;
    public AudioClip _selectedAudioClip;
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

    public void PlaySFX(int n)
    {
        _main.PlayOneShot(_sound[n]);
    }

    
    public void HighlightButton()
    {
        _main.clip = _sound[0];
        _main.Play();
    }

    public void SelectedButton(){
        _main.clip = _selectedAudioClip;
        _main.Play();
    }

}
