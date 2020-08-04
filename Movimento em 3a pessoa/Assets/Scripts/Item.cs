using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //id para identificar o prefab do item
    public int id;
    //id para identificar qual é esse itens dentre todos os itens do jogo
    //public int allItensId;
    public string type;
    public int value;
    public Sprite sprite;
    
    
    public bool pickedUp;
    private bool near;

    private new Collider collider;
    private GameObject inventory;
    

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory");
        if(inventory == null)
        {
            Debug.Log("Não achou o inventory");
        }
        collider = gameObject.GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        if (!pickedUp)
        {
            collider.enabled = true;
        }
        else
        {
            collider.enabled = false;
        }

        if(near)
        {
           if (Input.GetKeyDown(KeyCode.E))
           {
                inventory.GetComponent<Inventory>().PegarItem(this);
                pickedUp = true;
           }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.GetChild(0).gameObject.SetActive(true);

            near = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.GetChild(0).gameObject.SetActive(false);

            near = false;
        }
        
    }

}
