using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeyPurchase : MonoBehaviour, IPointerDownHandler
{
    public int precio;  // Precio de la llave
    public GameObject playerUsableItem;  // Objeto de llave que se a�adir� al inventario
    private GameObject player;  // Referencia al objeto del jugador

    void Start()
    {
        // Buscar el jugador por su etiqueta. Aseg�rate de que tu jugador tenga la etiqueta "Player".
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("No se encontr� el objeto del jugador. Aseg�rate de que el jugador tiene la etiqueta 'Player'.");
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (player == null)
        {
            Debug.LogError("Objeto del jugador no asignado.");
            return;
        }

        GameObject PanelInventoryPlayer = GameObject.Find("PanelInventoryPlayer");
        bool inventarioLleno = true;

        // Verificar si hay al menos un espacio vac�o en el inventario
        for (int a = 0; a < 5; a++)
        {
            if (PanelInventoryPlayer.transform.GetChild(a).childCount < 1)
            {
                inventarioLleno = false;
                break;
            }
        }

        // Si hay espacios disponibles, a�adir la llave al inventario
        if (!inventarioLleno)
        {
            for (int a = 0; a < 5; a++)
            {
                if (PanelInventoryPlayer.transform.GetChild(a).childCount < 1)
                {
                    GameObject objetoComprado = Instantiate(playerUsableItem, new Vector2(0, 0), transform.rotation);
                    objetoComprado.transform.SetParent(PanelInventoryPlayer.transform.GetChild(a).gameObject.transform, false);
                    break;
                }
            }
        }
    }
}
