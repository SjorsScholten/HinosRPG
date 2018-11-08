using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Item {
    public class ItemToolTip : MonoBehaviour {
        [SerializeField] private Text _itemNameText;
        [SerializeField] private Text _itemTypeText;
        [SerializeField] private Text _itemDescriptionText;
        
        private void Awake() {
            gameObject.SetActive(false);
        }

        public void ShowToolTip(Item item) {
            //_itemNameText.text = item.name;
            //_itemTypeText.text = item.GetType();
            _itemDescriptionText.text = item.GetDiscription();
            
            gameObject.SetActive(true);
        }

        public void HideToolTip() {
            gameObject.SetActive(false);
        }
    }
}