/*
 * Autor: Adri� Bogu�� Torres
 * Date: 20/09/2023
 * Description: permet al jugador sortir del joc quan es diu al m�tode Quit().
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
        Debug.Log("You've just exit");
    }
}
