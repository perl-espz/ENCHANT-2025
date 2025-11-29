using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("OpenGameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("El juego se está cerrando..."); // Solo se verá en el editor
    }
}
