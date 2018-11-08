using UnityEngine;
using UnityEngine.UI;

namespace Item {
	public class ItemContainer : Intractable {
		protected Inventory Inventory;

		protected override void OnTriggerEnter(Collider other) {
			base.OnTriggerEnter(other);
			Inventory = other.GetComponent<Inventory>();
			ShowMessage("Press F to interact with, ");
		}

		protected override void OnTriggerExit(Collider other) {
			base.OnTriggerExit(other);
			HideMessage();
		}

		protected virtual void ShowMessage(string message) {
			MessageBoxText.text = message;
			MessageBox.SetActive(true);
		}

		protected virtual void HideMessage() {
			MessageBox.SetActive(false);
		}
		
	}
}
