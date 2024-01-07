using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventarioJugador : MonoBehaviour
{
    GameObject PanelInventoryPlayer;

    void Start()
    {
        PanelInventoryPlayer = GameObject.Find("PanelInventoryPlayer");
    }

    void Update()
    {
        // Diccionario para mapear teclas a índices
        Dictionary<KeyCode, int> teclasAIndices = new Dictionary<KeyCode, int>
        {
            { KeyCode.Alpha1, 0 },
            { KeyCode.Alpha2, 1 },
            { KeyCode.Alpha3, 2 },
            { KeyCode.Alpha4, 3 },
            { KeyCode.Alpha5, 4 }
        };

        // Verifica si se presiona alguna tecla numérica del 1 al 5
        foreach (var kvp in teclasAIndices)
        {
            if (Input.GetKeyDown(kvp.Key))
            {
                UsarObjeto(kvp.Value);
                break;
            }
        }
    }


    void UsarObjeto(int indiceRanura)
    {

        Transform slot = PanelInventoryPlayer.transform.GetChild(indiceRanura); // Obtener el slot del inventario

        if (slot.childCount > 0) // Verificar si hay un objeto en el slot
        {
            GameObject objeto = slot.GetChild(0).gameObject; // Obtener el primer objeto del slot

            string nombrePrefab = objeto.name.Replace("(Clone)", "").Trim(); // Obtener el nombre del prefab y eliminar "(Clone)"

            if (nombrePrefab == "Potion") // Comprobar si el nombre del prefab es "Potion"
            {
                GameObject player = GameObject.Find("Player");
                player.GetComponent<GolpePersonaje>().AumentarVida(10); // Aumentar la vida del jugador

                Destroy(objeto); // Destruir el objeto del inventario
            }
        }
    }
}