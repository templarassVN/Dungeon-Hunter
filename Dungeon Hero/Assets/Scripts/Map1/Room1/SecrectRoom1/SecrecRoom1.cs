using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SecrecRoom1 : MonoBehaviour
{
    [SerializeField]
    bool _isFinished = false;
    [SerializeField]
    GameObject Door;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<BoxCollider2D>().enabled = false;
        Door.SetActive(true);
    }

    public bool IsFinished
    {
        get { return _isFinished; }
        set { _isFinished = value; }
    }

    public void StartBreakInto()
    {
        GetComponent<PlayableDirector>().Play();
    }


}
