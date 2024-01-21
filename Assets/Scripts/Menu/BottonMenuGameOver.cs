using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottonMenuGameOver : MonoBehaviour
{
    // Método para reiniciar el nivel
    public void RestartLevel()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Método para volver al menú principal
    public void BackToMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }

    // Método para salir del juego
    public void ExitGame()
    {
        UnityEngine.Application.Quit();
    }
}
