using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkLightMissionPoint : MonoBehaviour
{
    [SerializeField]
    GameObject _UI_PressF;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider != null && collision.collider.tag == "Player")
        {
            _UI_PressF.SetActive(true);
            if (Input.GetKeyDown("f"))
            {

            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider != null && collision.collider.tag == "Player")
        {
            _UI_PressF.SetActive(false);
        }
    }
}
