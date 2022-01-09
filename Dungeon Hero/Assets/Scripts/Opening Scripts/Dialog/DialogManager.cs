using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField]
    string[] _Sentences;
    [SerializeField]
    float _text_speed = 1;
    [SerializeField]
    Text _textDisplay;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        StartCoroutine(DisplayTextByChar(index));
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                NextSentence();
        }
    }

    IEnumerator DisplayTextByChar(int n)
    {
        foreach(char letter in _Sentences[n].ToCharArray())
        {
            _textDisplay.text += letter;
            yield return new WaitForSeconds(_text_speed);
        }
    }

    public void NextSentence()
    {
        index += 1;
        if (index >= _Sentences.Length)
        {
            gameObject.SetActive(false);
        }
        _textDisplay.text = "";
        
        StartCoroutine(DisplayTextByChar(index));
    }
}
