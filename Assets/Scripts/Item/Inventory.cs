using System.Collections.Generic;
using UnityEngine;

namespace Item {
    public class Inventory : MonoBehaviour {

        private readonly List<Item> _items = new List<Item>();
        private int _capacity;

        public void AddItem(Item item) {
            if(IsFull) return;
            
            _items.Add(item);
        }

        public void RemoveItem() {
            
        }

        private bool IsFull {
            get { return _items.Count >= _capacity; }
        }
    }
}
