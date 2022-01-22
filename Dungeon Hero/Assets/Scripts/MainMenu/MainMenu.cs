using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject _setting;
    // Start is called before the first frame update
    void Start()
    {
        MusicManager.Instance.Map(0);
        _setting.SetActive(false); 
    }

    // Update is called once per frame
    public void NewGame()
    {
        
    }

    public void LoadGame()
    {

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
