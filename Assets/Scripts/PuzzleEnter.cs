using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleEnter : MonoBehaviour
{
    private bool enterAllowed;
    private string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "GATO")
        {
            sceneToLoad = "Puzzle";
            enterAllowed = true;
        }
        else if (collision.gameObject.name == "ENEMIGO")
        {
            sceneToLoad = "Battle";
            enterAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "GATO" ||
            collision.gameObject.name == "ENEMIGO")
        {
            enterAllowed = false;
        }
    }

    private void Update()
    {
        if (enterAllowed && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}


