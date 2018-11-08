using UnityEngine;

namespace Item {
	public class SingleItemContainer : ItemContainer {
		[SerializeField] private Item _item;

		protected override void ShowMessage(string message) {
			base.ShowMessage(message + _item.Name);
		}

		public override void Interact() {
			base.Interact();
			if(Inventory == null) return;
			Inventory.AddItem(_item);
			Destroy(gameObject);
		}
	}
}
