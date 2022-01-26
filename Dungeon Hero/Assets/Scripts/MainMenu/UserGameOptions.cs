using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class UserGameOptions
{
    /*
    public int quality;
    public int width;
    public int height;*/
    public float music = 0;
    public float sound = 0;
    public float all = 0;
    //public bool fullscreen = true;
    public bool muteAll = true;
    public bool muteMusic = true;
    public bool muteSound = true;
    UserGameOptions()
    {
    }
    static readonly string SETTINGS_FILE = "/userSettings.json";
    static readonly string SETTINGS_FOLDER = "userSettings";

    public static void onSaveSettings(UserGameOptions options)
    {
        string fullPath = Path.Combine(Application.persistentDataPath, SETTINGS_FOLDER);
        Debug.Log("Save file");
        Debug.Log(fullPath);

        if (!Directory.Exists(fullPath))
        {
            Debug.Log("Tao file");
            Directory.CreateDirectory(fullPath);
            string json = JsonUtility.ToJson(options);
            File.WriteAllText(fullPath + SETTINGS_FILE, json);
        }
        else
        {
            string json = JsonUtility.ToJson(options);
            File.WriteAllText(fullPath + SETTINGS_FILE, json);
        }
    }

    public static UserGameOptions onLoadSettings()
    {
        string fullPath = Path.Combine(Application.persistentDataPath, SETTINGS_FOLDER);

        if (Directory.Exists(fullPath))
        {
            if (File.Exists(fullPath + SETTINGS_FILE))
            {
                string json = File.ReadAllText(fullPath + SETTINGS_FILE);
                return JsonUtility.FromJson<UserGameOptions>(json);
            }
            else
            {
                return new UserGameOptions();
            }
        }
        else
        {
            return new UserGameOptions();
        }
    }
}
