using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialog : MonoBehaviour
{
    [SerializeField]
    string[] _Sentences;
    [SerializeField]
    float _text_speed = 0.1f;
    [SerializeField]
    Text _textDisplay;
    

    /// <summary>
    /// Variable
    /// </summary>
    
    [SerializeField]
    int index = 0;
    [SerializeField]
    bool _isTyping = false;
    IEnumerator _typingCoroutine;
    // Start is called before the first frame update
    private void Awake()
    {
        index = 0;
        _typingCoroutine = DisplayTextByChar();
    }
    void OnEnable()
    {
        _isTyping = true;
        StartCoroutine(_typingCoroutine);
    }

    private void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            Debug.Log(_textDisplay.text);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!_isTyping)
                {
                    _isTyping = true;
                    NextSentence();
                }
                else
                {
                    StopCoroutine(_typingCoroutine);
                    _isTyping = false;
                    _textDisplay.text = _Sentences[index];
                }
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                index = 0;
                gameObject.SetActive(false);
                GameStateManager.Instance.SetGameState(GameState.PLAY);
            }
            
        }
    }

    IEnumerator DisplayTextByChar()
    {
        for (int i = 0; i < _Sentences[index].Length; i++)
        {
            
            //Wait a certain amount of time, then continue with the for loop
            yield return new WaitForSeconds(_text_speed);
            _textDisplay.text = _Sentences[index].Substring(0, i + 1);
            if (i == _Sentences[index].Length - 1)
                _isTyping = false;
        }
    }

    public void NextSentence()
    {
        index += 1;
        if (index >= _Sentences.Length)
        {
            gameObject.SetActive(false);
            GameStateManager.Instance.SetGameState(GameState.PLAY);
        }
        else
        {
            _textDisplay.text = "";
            StartCoroutine(_typingCoroutine);
        }
    }

}

