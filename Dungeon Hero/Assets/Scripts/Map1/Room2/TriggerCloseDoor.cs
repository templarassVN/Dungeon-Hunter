using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCloseDoor : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject _Door;
    void Start()
    {
        _Door.SetActive(false);
    }

    // Update is called once per frame
    

    private void OnTriggerExit2D(Collider2D collision)
    {
        _Door.SetActive(true);
        Destroy(gameObject);
    }
}
