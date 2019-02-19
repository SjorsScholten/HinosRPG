using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

[CreateAssetMenu(menuName = "items", fileName = "simple item")]
public class SimpleItem : ScriptableObject, IItem {
    
    [SerializeField] 
    private int id = -1;

    [SerializeField]
    private new string name = "default simple object";

    public int Id => id;
    public string Name => name;
}
