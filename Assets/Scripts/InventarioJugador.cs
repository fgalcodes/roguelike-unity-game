using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class InventarioJugador : MonoBehaviour
{
    GameObject PanelInventoryPlayer;
    KeyInventory playerKeys;

    public TMP_Text numberKeyText;

    void Start()
    {
        PanelInventoryPlayer = GameObject.Find("PanelInventoryPlayer");
        playerKeys = GetComponent<KeyInventory>();
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

        Transform slot = PanelInventoryPlayer.transform.GetChild(indiceRanura);

        if (slot.childCount > 0)
        {
            GameObject objeto = slot.GetChild(0).gameObject;

            string nombrePrefab = objeto.name.Replace("(Clone)", "").Trim();

            if (nombrePrefab == "Potion")
            {
                GameObject player = GameObject.Find("Player");
                player.GetComponent<GolpePersonaje>().AumentarVida(10);

                Destroy(objeto);
            }
            else if (nombrePrefab == "key")
            {
                UnityEngine.Debug.Log("¡Se detectó una llave!");

                playerKeys = GameObject.Find("Player").GetComponent<KeyInventory>();
                playerKeys.playerKeys.keys++;
                playerKeys.UpdateKeyText();
                Destroy(objeto);
            }
        }
    }
}