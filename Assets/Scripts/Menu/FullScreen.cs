/*
 * Autor: Adrià Boguñá Torres
 * Date: 27/09/2023
 * Description: sutilitza per controlar la configuració de pantalla completa i les resolucions.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FullScreen : MonoBehaviour
{
    public Toggle toggle;

    public TMP_Dropdown resolucionesDropDown;
    Resolution[] resoluciones;

    // Verifiqueu si el joc s'està executant en pantalla completa o no i ajusta l'estat de l'interruptor (Toggle) en conseqüència.
    void Start()
    {
        if (Screen.fullScreen) { toggle.isOn = true; }
        else { toggle.isOn = false; }

        CheckResolution();
    }

    // Permet activar o desactivar el mode de pantalla completa.
    public void ActiveFullScreen(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }

    // Sencarrega de obtenir la llista de resolucions disponibles i configurar un menú desplegable (Dropdown) amb aquestes opcions.
    public void CheckResolution()
    {
        resoluciones = Screen.resolutions;
        resolucionesDropDown.ClearOptions();
        List<string> opciones = new List<string>();
        int resolutionActuality = 0;

        for (int i = 0; i < resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
            opciones.Add(opcion);

            if (Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width &&
                resoluciones[i].height == Screen.currentResolution.height)
            {
                resolutionActuality = i;
            }
        }
        resolucionesDropDown.AddOptions(opciones);
        resolucionesDropDown.value = resolutionActuality;
        resolucionesDropDown.RefreshShownValue();

        resolucionesDropDown.value = PlayerPrefs.GetInt("numberResolution", 0);
    }

    // Es crida quan es canvia la selecció al menú desplegable de resolucions.
    public void ChangeResolution(int indiceResolution)
    {
        PlayerPrefs.SetInt("numberResolution", resolucionesDropDown.value);

        Resolution resolucion = resoluciones[indiceResolution];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }
}
