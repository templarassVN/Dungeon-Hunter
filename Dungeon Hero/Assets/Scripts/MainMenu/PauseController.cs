using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject player;
    public void PauseGame()
    {
        GameStateManager.Instance.PauseGame();
    }

    public void ResumeGame()
    {
        GameStateManager.Instance.ResumeGame();
        this.gameObject.SetActive(false);
    }
    
    public void SaveGame(){
        GameStateManager.Instance.SaveGame(player.GetComponent<PlayerController>());
    }

    public void Quit()
    {
        //GameStateManager.Instance.SaveGame(player.GetComponent<PlayerController>());
        SceneManager.LoadScene(0);
    }

}
