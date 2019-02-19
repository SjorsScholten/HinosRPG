public interface IInventory {
    void AddItem(IItem item);
    void RemoveItem(IItem item);
    IItem GetItemWithId(int id);
}