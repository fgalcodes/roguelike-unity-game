using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottonMenuGameOver : MonoBehaviour
{
    // Método para reiniciar el nivel
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Método para volver al menú principal
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // Método para salir del juego
    public void ExitGame()
    {
        UnityEngine.Application.Quit();
    }
}
