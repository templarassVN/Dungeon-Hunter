using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]

    GameObject _setting;
    public GameObject LoadingScreen;
    public Slider slider;

    static readonly string SAVE_FILE = "/userSaveGame.json";
    static readonly string SAVE_FOLDER = "save";

    // Start is called before the first frame update
    void Start()
    {
        MusicManager.Instance.Map(0);
        _setting.SetActive(false);
    }

    // Update is called once per frame
    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadGame()
    {
        
    }

    public void Countinue()
    {
        StartCoroutine(LoadCountinue());
        GameStateManager.Instance._loadGame = true;
        LoadLevel(GameStateManager.Instance.Data.level);
    }
    
    public void LoadLevel(int sceneIndex){
        StartCoroutine(LoadAsyncOperation(sceneIndex));
    }

    IEnumerator LoadAsyncOperation(int sceneIndex){
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        gameObject.SetActive(false);
        LoadingScreen.SetActive(true);

        while(operation.isDone == false){
            float progress = Mathf.Clamp01(operation.progress /0.9f);
            slider.value = progress;
            yield return null;
        }
    }


    IEnumerator LoadCountinue()
    {
        string fullPath = Path.Combine(Application.persistentDataPath, SAVE_FOLDER);
        if (Directory.Exists(fullPath))
        {
            if (File.Exists(fullPath + SAVE_FILE))
            {
                string json = File.ReadAllText(fullPath + SAVE_FILE);
                Debug.Log(json);
                GameStateManager.Instance.Data =  JsonUtility.FromJson<PlayerData>(json);
            }
            yield return null;
        }
    }

    public void Option()
    {
        gameObject.SetActive(false);
        _setting.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }


}
