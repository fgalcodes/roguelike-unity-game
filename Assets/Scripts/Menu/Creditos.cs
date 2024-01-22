/*
 * Autor: Adri� Bogu�� Torres
 * Date: 27/09/2023
 * Description: mostrar els cr�dits en el joc i tornar al men� principal despr�s dun temps determinat o quan es prem la tecla Esc.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    
    void Start()
    {
        Invoke("WaitToEnd", 20); // Espera 20 segons i despr�s crida al m�tode WaitToEnd.
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
        
    }

    // Aquest m�tode carrega l'escena "Menu" i s'utilitza per tornar al men� principal despr�s de l'espera definida.
    public void WaitToEnd()
    {
        SceneManager.LoadScene("Menu");
    }
}
