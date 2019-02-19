using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour {
    
    [SerializeField]
    private Text sentenceField;

    [SerializeField]
    private Animator animator;

    private readonly Queue<string> sentences = new Queue<string>();

    public void OpenDialogue(IDialogue dialogue) {
        
        sentences.Clear();
        foreach (string sentence in dialogue.Sentences) {
            sentences.Enqueue(sentence);
        }
        
        animator.SetBool("IsOpen", true);
        NextSentence();
    }

    public void NextSentence() {
        
        if (sentences.Peek() == null) {
            EndDialogue();
            return;
        }
        
        var sentence = sentences.Dequeue();
        sentenceField.text = sentence;
    }

    public void EndDialogue() {
        animator.SetBool("IsOpen", false);
    }
}