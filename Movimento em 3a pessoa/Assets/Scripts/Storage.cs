using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{

    public Item[] itens;
    public GameObject storage;
    bool near;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if(near == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            transform.GetChild(2).GetChild(1).gameObject.SetActive(true);

            near = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.GetChild(2).GetChild(1).gameObject.SetActive(false);

            near = false;
        }

    }
}
