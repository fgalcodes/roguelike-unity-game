/*
 * Autor: Adrià Boguñá Torres
 * Date: 27/09/2023
 * Description: Aquí es fan servir les PlayerPrefs per guardar i recuperar el valor del volum de l'àudio, 
 * i s'actualitza el volum de l'AudioListener segons el valor de l'slider. 
 * A més, es verifica si l'àudio està silenciat i es mostra o amaga una imatge d'àudio silenciat en funció del valor de l'slider.
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

    // Aquest mètode es diu quan es canvia el valor de l'slider.
    public void ChangeSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("volumeAudio", sliderValue);
        AudioListener.volume = slider.value;
        CheckIsMuted();
    }

    // Verifiquem si l'àudio està silenciat i mostrem o amaguem la imatge d'àudio silenciat.
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
