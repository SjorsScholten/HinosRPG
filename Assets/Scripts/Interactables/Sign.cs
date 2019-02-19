using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour, IInteractable {

    [SerializeField]
    private SimpleDialogue dialogue;

    public void Interact() {
        FindObjectOfType<DialogueController>().OpenDialogue(dialogue);
    }
}
