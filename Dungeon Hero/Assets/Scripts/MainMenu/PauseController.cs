using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject player;

    [SerializeField]
    GameObject option;

    private void Start() {
        option.SetActive(false);
        gameObject.SetActive(false);
    }
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

    public void Option() {
        gameObject.SetActive(false);
        option.SetActive(true);
    }

    public void Quit()
    {
        //GameStateManager.Instance.SaveGame(player.GetComponent<PlayerController>());
        Destroy(player);
        Destroy(IngameUIController.instance.gameObject);
        Destroy(GameStateManager.Instance.gameObject);
        ResumeGame();
        SceneManager.LoadScene(0);
    }

}
