/*
 * Autor: Adrià Boguñá Torres
 * Date: 26/09/2023
 * Description: L'script permet a l'usuari ajustar el nivell de brillantor mitjançant un slider.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shine : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image panelShine;

    // Configurem l'estat inicial del control de brillantor.
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("shine", 0.5f); // Obtenim el valor desat a PlayerPrefs o fem servir 0.5f si no existeix.
        panelShine.color = new Color(panelShine.color.r, panelShine.color.g, panelShine.color.b, slider.value); // Configurem el color del panell de brillantor amb el valor de l'slider.
    }

    // Aquest mètode es diu quan es canvia el valor de l'slider.
    public void ChangeSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("shine", sliderValue); // Desem el valor a PlayerPrefs per a futures sessions.
        panelShine.color = new Color(panelShine.color.r, panelShine.color.g, panelShine.color.b, slider.value);
    }
}
