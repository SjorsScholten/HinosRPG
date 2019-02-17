using UnityEngine;

namespace Item {
	public class SingleItemContainer : ItemContainer {
		[SerializeField] private Item _item;
		[SerializeField] private bool _destroy = true;

		protected override void ShowMessage(string message) {
			base.ShowMessage(message + _item.Name);
		}

		public override void Interact() {
			base.Interact();
			TakeItem();
		}

		private void TakeItem() {
			if(Inventory == null) return;
			Inventory.AddItem(_item);
			if(_destroy) DestroyOnEmpty();
		}

		private void DestroyOnEmpty() {
			if (_item != null) return;
			Destroy(gameObject);
		}
	}
}
