using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    public List<Sprite> InvItems;
    public List<Transform> ItemSlots;
    // Start is called before the first frame update
    void Start()
    {
        InvItems = new List<Sprite>();
        ItemSlots = new List<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
