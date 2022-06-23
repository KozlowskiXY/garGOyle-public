using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Controls Behaviour of Text in Canvas
public class TextControl : MonoBehaviour
{
    
    [SerializeField]
    private GameObject canvas;
    
    // Don't display text until being told so
    void Start()
    {
        DisableText();
    }

    
    void DisableText()
    {
        canvas.GetComponent<Text>().enabled = false;
    }
}
