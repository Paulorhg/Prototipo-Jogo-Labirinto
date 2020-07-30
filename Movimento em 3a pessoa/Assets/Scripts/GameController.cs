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
