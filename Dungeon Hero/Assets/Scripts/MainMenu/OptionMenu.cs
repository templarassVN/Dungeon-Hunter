using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{

    [SerializeField]
    GameObject _main;
    // Start is called before the first frame update

    // Update is called once per frame
    public void ChangeSound()
    {

    }

    public void MuteSound()
    {

    }

    public void ChangeMusic()
    {

    }

    public void MuteMusic()
    {

    }

    public void BacktoMain()
    {
        gameObject.SetActive(false);
        _main.SetActive(true);
    }
}
