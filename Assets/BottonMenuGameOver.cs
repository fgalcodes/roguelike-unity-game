using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottonMenuGameOver : MonoBehaviour
{
    // Método para reiniciar el nivel
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reiniciar el nivel actual
    }

    // Método para volver al menú principal
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu"); // Cargar la escena del menú principal
    }

    // Método para salir del juego
    public void ExitGame()
    {
        UnityEngine.Application.Quit();
    }
}
