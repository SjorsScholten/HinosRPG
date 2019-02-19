using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInventory : MonoBehaviour, IInventory {
    
    private readonly List<IItem> items = new List<IItem>(); 
    
    public void AddItem(IItem item) {
        items.Add(item);
    }

    public void RemoveItem(IItem item) {
        items.Remove(item);
    }

    public IItem GetItemWithId(int id) {
        var item = items.Find(x => x.Id.Equals(id));
        return item;
    }
}
