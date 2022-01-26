using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class OptionMenu : MonoBehaviour
{

    [SerializeField]
    GameObject _main;
    public AudioMixer audioMixer;
    private float music;
    private float sound;
    private float all;
    static readonly string SETTINGS_FILE = "settings.json";
    float horizontal, vertical;
    public TMP_Dropdown resolutionDropdown;
    private int selectedResolution;
    //public List<Resolution> resolutions = new List<Resolution>(Screen.resolutions);
    public TMP_Text resolutionsText;
    private int currentResolutionIndex;
    Resolution[] resolutions;
    private bool isfullscreen = true;
    private UserGameOptions userOptions;
    public Toggle musicToggle;
    public Toggle soundToggle;
    public Toggle allToggle;
    public Slider musicSlider;
    public Slider soundSlider;
    public Slider allSlider;


    // Start is called before the first frame update
    public void Start()
    {
        userOptions = UserGameOptions.onLoadSettings();
        //Slider
        ChangeSound(userOptions.sound);
        soundSlider.value = userOptions.sound;
        ChangeMusic(userOptions.music);
        musicSlider.value = userOptions.music;
        ChagneAll(userOptions.all);
        allSlider.value = userOptions.all;

        //Toggle
        MuteSound(userOptions.muteSound);
        soundToggle.isOn = userOptions.muteSound;
        MuteMusic(userOptions.muteMusic);
        musicToggle.isOn = userOptions.muteMusic;
        MuteAll(userOptions.muteAll);
        allToggle.isOn = userOptions.muteAll;

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void Fullscreen(bool value)
    {
        //Debug.Log(value );
        isfullscreen = value;
        Screen.fullScreen = isfullscreen;
        Debug.Log(Screen.fullScreen);
        //Debug.Log(currentResolutionIndex + " " + resolutions[currentResolutionIndex].ToString());
        Resolution resolution = resolutions[currentResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, value);

    }

    public void SetResolution(int resolutionIndex)
    {
        currentResolutionIndex = resolutionIndex;
        Debug.Log(resolutionIndex + " " + resolutions[resolutionIndex].ToString());
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    private IEnumerator WaitForScreenChange(int resolutionIndex)
    {
        Debug.Log(resolutionIndex + " " + resolutions[resolutionIndex].ToString());

        Resolution resolution = resolutions[resolutionIndex];


        yield return new WaitForEndOfFrame();
        yield return new WaitForEndOfFrame();
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }


    // Sound Settings --------------------------------
    public void ChangeSound(float volume)
    {
        audioMixer.SetFloat("sound", volume);
        sound = volume;
        userOptions.sound = volume;
    }

    public void MuteSound(bool value)
    {
        userOptions.muteSound = value;
        if (!value)
        {
            audioMixer.SetFloat("sound", -80);
        }
        else
        {
            audioMixer.SetFloat("sound", sound);
        }
    }

    public void ChangeMusic(float volume)
    {
        audioMixer.SetFloat("music", volume);
        music = volume;
        userOptions.music = volume;
    }

    public void MuteMusic(bool value)
    {
        userOptions.muteMusic = value;
        if (!value)
        {
            audioMixer.SetFloat("music", -80);

        }
        else
        {
            audioMixer.SetFloat("music", music);
        }
    }

    public void ChagneAll(float volume)
    {
        audioMixer.SetFloat("all", volume);
        all = volume;
        userOptions.all = volume;
    }

    public void MuteAll(bool value)
    {
        userOptions.muteAll = value;
        if (!value)
        {
            audioMixer.SetFloat("all", -80);

        }
        else
        {
            audioMixer.SetFloat("all", all);
        }
    }


    public void BacktoMain()
    {
        gameObject.SetActive(false);
        _main.SetActive(true);
        UserGameOptions.onSaveSettings(userOptions);
    }


}
