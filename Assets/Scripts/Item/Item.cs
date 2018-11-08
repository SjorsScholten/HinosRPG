using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Item {
    [CreateAssetMenu(fileName = "default item", menuName = "Items/DefaultItem")]
    public class Item : ScriptableObject {
        public int ID;
        public string Name;

        public virtual string GetDiscription() {
            return "";
        }
    }
}