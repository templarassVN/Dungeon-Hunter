using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICoinController : MonoBehaviour
{
    [SerializeField]
    Text _text_amount;

    public static UICoinController Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
            
    }

    public void ChangeText(int num)
    {
        _text_amount.text = num.ToString();
    }
}
