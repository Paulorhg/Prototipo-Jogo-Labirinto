﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    
    public int id;
    public string type;
    public float value;
    public GameObject prefab;
    public Sprite sprite;
    public bool pickedUp;

    //Se o item for potion colocar se é de vida ou de mana
    [Header("Se o tipo não for Potion deixar em branco")]
    public string typePotion;

    private bool near;

    private new Collider collider;
    private GameObject inventory;

    public Item() { }

    public Item(Item item)
    {
        this.id = item.id;
        this.type = item.type;
        this.value = item.value;
        this.prefab = item.prefab;
        this.sprite = item.sprite;
        this.pickedUp = true;


        if (item.type.Equals("Potion"))
            this.typePotion = item.typePotion;
    }
    
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory");

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
            transform.GetChild(0).gameObject.SetActive(false);
            near = false;
        }

        if (near)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inventory.GetComponent<Inventory>().PegarItem(this);
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
