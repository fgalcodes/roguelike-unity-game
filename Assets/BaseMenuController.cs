using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMenuController : MonoBehaviour
{
    protected GameObject menuUI;

    protected virtual void Start()
    {
        // Puedes inicializar variables comunes aqu�
        menuUI = null;
    }

    protected virtual void Update()
    {
        // Puedes agregar l�gica com�n de actualizaci�n aqu�
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ToggleMenu(1);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        ToggleMenu();
    }

    protected virtual void ToggleMenu(int a = 0)
    {
        if (a == 1)
        {
            menuUI.SetActive(true);
        }
        else
        {
            menuUI.SetActive(false);
        }
    }
}
