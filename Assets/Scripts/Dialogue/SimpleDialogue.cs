using System;
using UnityEngine;

[Serializable]
public class SimpleDialogue : IDialogue {
    
    [SerializeField]
    [TextArea(3,10)]
    private string[] sentences;

    public string[] Sentences => sentences;
}