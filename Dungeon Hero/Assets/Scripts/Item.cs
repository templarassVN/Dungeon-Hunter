using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject temp = collision.gameObject;
        Debug.Log(temp.tag);
        if (temp.tag == "Player")
        {
            LoadScene_0();
            Destroy(this);
        }
    }

    
    void LoadScene_0()
    {
        SceneManager.LoadScene(0);
    }

    IEnumerator Loadlevel()
    {
        Debug.Log("got to coroutine");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }
}
