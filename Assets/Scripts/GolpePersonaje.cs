using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GolpePersonaje : MonoBehaviour
{
    [SerializeField] int vidas;
    [SerializeField] Slider sliderVidas;

    void Start()
    {
        sliderVidas.maxValue = vidas;
        sliderVidas.value = sliderVidas.maxValue;
    }

    void OnCollisionEnter2D(Collision2D otro)
    {
        if (otro.gameObject.CompareTag("Enemigo"))
        {
            vidas--;
            sliderVidas.value = vidas;

            if (vidas <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
