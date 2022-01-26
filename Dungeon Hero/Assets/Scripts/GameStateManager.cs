using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;


public enum GameState { CUTS, MENU, MISSION, PLAY, DEATH }
public class GameStateManager : MonoBehaviour
{
    public bool _NewGame = true;
    private PlayerData data;
    public bool _loadGame = false;
    public GameState State { get; private set; }
    internal PlayerData Data { get => data; set => data = value; }

    public static GameStateManager Instance;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    
    public void SetGameState(GameState state)
    {
        Debug.Log(State);
    }

    static readonly string SAVE_FILE = "/userSaveGame.json";
    static readonly string SAVE_FOLDER = "save";

    static Vector2 a = new Vector2(-3.06f, 2.6f);
    private List<Vector2> position = new List<Vector2>(){a, new Vector2(-24.45f, 3.07f), new Vector2(6.26f, -2.55f), new Vector2(32.94f, -2.51f), new Vector2(0f,0f), new Vector2(0f,0f)};
    private int currentSavePoint = 0;
   
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()    {
        Time.timeScale = 1;
    }

    public void SaveGame(PlayerController player)
    {
        //PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        //PlayerPrefs.SetFloat("PlayerY", player.transform.position.x);
    }

    public void QuitGame(PlayerController player)
    {
        PlayerData data = new PlayerData(position[currentSavePoint], player, currentSavePoint, SceneManager.GetActiveScene().buildIndex);

        string fullPath = Path.Combine(Application.persistentDataPath, SAVE_FOLDER);
        Debug.Log("Save file");
        Debug.Log(fullPath);

        if (!Directory.Exists(fullPath))
        {
            Directory.CreateDirectory(fullPath);
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(fullPath + SAVE_FILE, json);
        }
        else
        {
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(fullPath + SAVE_FILE, json);
        }
    }
}
