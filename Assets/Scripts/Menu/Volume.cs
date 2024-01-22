/*
 * Autor: Adri� Bogu�� Torres
 * Date: 27/09/2023
 * Description: Aqu� es fan servir les PlayerPrefs per guardar i recuperar el valor del volum de l'�udio, 
 * i s'actualitza el volum de l'AudioListener segons el valor de l'slider. 
 * A m�s, es verifica si l'�udio est� silenciat i es mostra o amaga una imatge d'�udio silenciat en funci� del valor de l'slider.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image imageMuted;

    // Configurem l'estat inicial del control de volum.
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumeAudio", 0.5f);
        AudioListener.volume = slider.value;
        CheckIsMuted();
    }

    // Aquest m�tode es diu quan es canvia el valor de l'slider.
    public void ChangeSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("volumeAudio", sliderValue);
        AudioListener.volume = slider.value;
        CheckIsMuted();
    }

    // Verifiquem si l'�udio est� silenciat i mostrem o amaguem la imatge d'�udio silenciat.
    public void CheckIsMuted()
    {
        if (sliderValue == 0)
        {
            imageMuted.enabled = true;
        }
        else
        {
            imageMuted.enabled = false;
        }
    }
}
