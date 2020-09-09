using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Storage : MonoBehaviour
{

    public Item[] itens = new Item[18];
    [Tooltip("Se o item for do tipo Potion, colocar a quantidade")]
    public int[] amountPotion = new int[18];
    public GameObject storage;
    public GameObject itemIconPrefab;
    Animator _anim;

    bool _open;
    bool _near;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (_near == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _open = !_open;
                _anim.SetBool("open", _open);

                
                if (_open)
                {
                    OpenChest();
                }
                
                else
                {

                    CloseChest();
                }

                storage.SetActive(_open);
                transform.GetChild(2).GetChild(0).gameObject.SetActive(!_open);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.GetChild(2).GetChild(0).gameObject.SetActive(true);

            _near = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.GetChild(2).GetChild(0).gameObject.SetActive(false);

            _near = false;

            //Se o personagem se afastar o bau se fecha
            if (_open)
            {
                _open = !_open;
                _anim.SetBool("open", _open);
                storage.SetActive(_open);

                CloseChest();
            }
        }

    }


    private void OpenChest()
    {
        //Quando abre o bau, cria os icones e coloca como filho nos slots
        for (int i = 0; i < itens.Length; i++)
        {
            if (itens[i] != null)
            {
                GameObject itemIcon = Instantiate(itemIconPrefab, storage.transform.GetChild(0).GetChild(i).transform);
                itemIcon.GetComponent<ItemIcon>().Inicializado(itens[i]);

                if (itens[i].type.Equals("Potion"))
                {
                    itemIcon.GetComponent<ItemIcon>().JuntarPotion(amountPotion[i] - 1);
                }
            }
        }
    }

    private void CloseChest()
    {
        //Quando fecha o bau, copia o estado dos itens e depois destroi os icones
        for (int i = 0; i < itens.Length; i++)
        {

            if (storage.transform.GetChild(0).GetChild(i).childCount != 0)
            {
                itens[i] = storage.transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<ItemIcon>().item;

                if (storage.transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<ItemIcon>().item.type.Equals("Potion"))
                    amountPotion[i] = storage.transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<ItemIcon>().amount;

                Destroy(storage.transform.GetChild(0).GetChild(i).GetChild(0).gameObject);
            }

            else
                itens[i] = null;
        }
    }
}
