using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotCover : MonoBehaviour
{

    Inventory2 inv;
    RectTransform rT;

    // Use this for initialization
    void Start()
    {
        inv = transform.parent.parent.parent.parent.GetComponent<Inventory2>();
        rT = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {

        rT.sizeDelta = new Vector3(inv.slotSize, inv.slotSize, 0);
    }
}
