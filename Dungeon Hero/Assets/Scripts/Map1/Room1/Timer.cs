using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    int Duration;
    int _remainDur;
    [SerializeField]
    Text display;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetandRun()
    {
        _remainDur = Duration;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while(_remainDur > 0)
        {
            UpdateUI_display(_remainDur);
            _remainDur--;
            yield return new WaitForSeconds(1f);
        }
    }

    

    void UpdateUI_display(int second)
    {
        display.text = string.Format("{0:D2}:{1:D2}", second / 60, second % 60);
    }
}
