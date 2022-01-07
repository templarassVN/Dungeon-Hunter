using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIController : MonoBehaviour
{
    public static UIController Instance;

    [SerializeField]
    private GameObject _MenuCanvas;
    [SerializeField]
    private GameObject _TransitionCanvas;
    

    private void Awake()
    {
        DontDestroyOnLoad(this);

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
    void Start()
    {
       
    }

    // Update is called once per frame
    public void MenuPopUp()
    {
        _MenuCanvas.SetActive(true);
    }

    public void Play()
    {
        _MenuCanvas.SetActive(false);
    }

    

    

    
}
