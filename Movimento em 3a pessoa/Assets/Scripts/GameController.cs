using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    [SerializeField]
    HealthBar health;

    [SerializeField]
    Image gameOver;

    [SerializeField]
    GameObject inventory;
    [SerializeField]
    GameObject character;
    [SerializeField]
    GameObject storage;
    [SerializeField]
    GameObject camera3Person;
    [SerializeField]
    ThirdPersonMovement movement;
 

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(health.GetHealth() <= 0)
        {
            StartCoroutine("Death");
        }

        if(inventory.activeSelf || character.activeSelf || storage.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            camera3Person.SetActive(false);
            movement.enabled = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            camera3Person.SetActive(true);
            movement.enabled = true;
        }
    }

    public void ReloadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }


    IEnumerator Death()
    {
        yield return new WaitForSeconds(2.7f);
        gameOver.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}
