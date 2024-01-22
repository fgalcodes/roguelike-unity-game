/*
 * Autor: Adri� Bogu�� Torres
 * Date: 27/09/2023
 * Description: controla la qualitat de la imatge.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Utilitza la biblioteca TextMeshPro (TMP) per gestionar un men� desplegable.

public class ImageQuality : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public int quality;

    // Es carrega el nivell de qualitat emmagatzemat a PlayerPrefs (anteriorment guardat per l'usuari).
    void Start()
    {
        quality = PlayerPrefs.GetInt("numberOfQuality", 3);
        dropdown.value = quality;
        AdjustQuality();
    }

    // Es crida quan lusuari canvia el nivell de qualitat des del men� desplegable.
    public void AdjustQuality()
    {
        QualitySettings.SetQualityLevel(dropdown.value); // Ajusta la qualitat de la imatge segons el valor seleccionat al men� desplegable.
        PlayerPrefs.SetInt("numberOfQuality", dropdown.value); // Desa aquest valor a PlayerPrefs per recordar l'elecci� de l'usuari.
        quality = dropdown.value;
    }
}
