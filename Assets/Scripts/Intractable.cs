using UnityEngine;
using UnityEngine.UI;

namespace Item {
    public class Intractable : MonoBehaviour {
        public float _radius = 3;
        public GameObject MessageBox;
        public Text MessageBoxText;

        protected virtual void Update() {
            if (Input.GetKey(KeyCode.F)) {
                Interact();
            }
        }

        protected virtual void OnTriggerEnter(Collider other) {
            
        }

        protected virtual void OnTriggerExit(Collider other) {
            
        }

        public virtual void Interact() {
            Debug.Log("interacting with, " + gameObject.name, this);
        }
    }
}