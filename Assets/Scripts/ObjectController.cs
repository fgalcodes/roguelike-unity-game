using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectController : MonoBehaviour, IPointerDownHandler
{
    public int precio = 2;
    int cantidad = 1;
    public GameObject playerUsableItem;
    GameObject player;
    
    void Start()
    {
        player = GameObject.Find("Player");
    }

    
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        int monedasDisponibles = player.GetComponent<GoldController>().coins;
        if (monedasDisponibles >= precio)
        {
            monedasDisponibles -= precio;
            player.GetComponent<GoldController>().coins = monedasDisponibles;

            GameObject PanelInventoryPlayer = GameObject.Find("PanelInventoryPlayer");

            for (int a = 0; a<5; a++)
            {
                if (PanelInventoryPlayer.transform.GetChild(a).childCount < 1)
                {
                    GameObject objetoComprado = Instantiate(playerUsableItem, new Vector2(0, 0), transform.rotation);
                    objetoComprado.transform.SetParent(PanelInventoryPlayer.transform.GetChild(a).gameObject.transform, false);
                    player.GetComponent<GoldController>().RefreshUI();
                    break;
                }
            }
        }
    }
}