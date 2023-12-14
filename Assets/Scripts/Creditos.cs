/*
 * Autor: Adrià Boguñá Torres
 * Date: 27/09/2023
 * Description: mostrar els crèdits en el joc i tornar al menú principal després dun temps determinat o quan es prem la tecla Esc.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    
    void Start()
    {
        Invoke("WaitToEnd", 20); // Espera 20 segons i després crida al mètode WaitToEnd.
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
        
    }

    // Aquest mètode carrega l'escena "Menu" i s'utilitza per tornar al menú principal després de l'espera definida.
    public void WaitToEnd()
    {
        SceneManager.LoadScene("Menu");
    }
}
