using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    AudioMixer _mainmixer;
    [SerializeField]
    AudioClip[] _sound;
    AudioSource _main;
    public static MusicManager Instance;
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

    public void Map(int n)
    {
        _main.clip = _sound[n];
        _main.Play();
    }

    public void ChangeVolume(float amount)
    {
        _mainmixer.SetFloat("music", amount);
    }

    public void MuteVolume()
    {
        _mainmixer.SetFloat("music", -60f);
    }
}
