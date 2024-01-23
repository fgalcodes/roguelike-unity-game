/*
 * Autor: Adrià Boguñá Torres
 * Date: 25/09/2023
 * Description: controla els botons d'un menú.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] AnimatorFunctions animatorFunctions;
    [SerializeField] int thisIndex;

    [SerializeField] GameObject StartMenu;
    [SerializeField] GameObject OptionMenu;

    // Es verifica si aquest botó està seleccionat segons l'índex actual del controlador de botons de menú.
    void Update()
    {
        if (menuButtonController.index == thisIndex)
        {
            animator.SetBool("selected", true);
            if (Input.GetAxis("Submit") == 1)
            {
                animator.SetBool("pressed", true);
                HandleButtonPress();
            }
            else if (animator.GetBool("pressed"))
            {
                animator.SetBool("pressed", false);
                animatorFunctions.disableOnce = true;
            }
        }
        else
        {
            animator.SetBool("selected", false);
        }
    }


    // Verifica l'índex del botó actual i, en funció del valor, realitza l'acció corresponent.
    public void HandleButtonPress()
    {
        if (thisIndex == 0) // Botó "START"
        {
            StartMenu.SetActive(false);
            SceneManager.LoadScene("Level1");
            Debug.Log("Cargando Level1...");
        }
        else if (thisIndex == 1) // Botó "Credits"
        {
            Creditos();
        }
        else if (thisIndex == 2) // Botó "Opcions"
        {
            StartMenu.SetActive(false);
            OptionMenu.SetActive(true);
        }
        else if (thisIndex == 3) // Botó "QUIT"
        {
            Debug.Log("Saliendo del juego");
            Application.Quit();
        }
    }

    // Permet carregar una escena específica ("Credits") quan es prem el botó "Crèdits".
    public void Creditos()
    {
        SceneManager.LoadScene("Credits");
    }
}

