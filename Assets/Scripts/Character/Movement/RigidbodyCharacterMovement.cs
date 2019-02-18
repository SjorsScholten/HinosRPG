using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyCharacterMovement : MonoBehaviour, ICharacterMovement {
    private Rigidbody rb;
    
    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction, float speed) {
        rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
    }
}
