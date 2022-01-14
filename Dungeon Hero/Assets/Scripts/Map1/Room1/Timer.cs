using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    int Duration;
    [SerializeField]
    GameObject _text;
    int _remainDur;
    [SerializeField]
    Text display ;
    // Start is called before the first frame update
    void Start()
    {
        _text.SetActive(false);
        display = _text.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetandRun()
    {
        _remainDur = Duration;
        _text.SetActive(true);
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

    public int Timeleft
    {
        get { return _remainDur; }
    }

    

    void UpdateUI_display(int second)
    {
        display.text = string.Format("{0:D2}:{1:D2}", second / 60, second % 60);
    }
}
