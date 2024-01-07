using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottonMenuGameOver : MonoBehaviour
{
    // M�todo para reiniciar el nivel
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reiniciar el nivel actual
    }

    // M�todo para volver al men� principal
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu"); // Cargar la escena del men� principal
    }

    // M�todo para salir del juego
    public void ExitGame()
    {
        UnityEngine.Application.Quit();
    }
}
