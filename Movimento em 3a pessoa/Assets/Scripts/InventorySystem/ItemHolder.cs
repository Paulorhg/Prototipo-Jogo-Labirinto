using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{

    Dictionary<int, Item> itensHolded;
    int idItem = 0;
    // Start is called before the first frame update
    void Start()
    {
        itensHolded = new Dictionary<int, Item>();
    }

    public int AddItem(Item item)
    {
        itensHolded.Add(idItem, new Item(item));
        idItem++;
        return idItem - 1;
    }

    public Item GetItem(int id)
    {
        Item item;
        itensHolded.TryGetValue(id, out item);
        
        return item;
    }

    public bool CheckItem(int id)
    {
        return itensHolded.ContainsKey(id);
    }
}
