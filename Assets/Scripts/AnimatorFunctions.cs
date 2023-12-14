/*
 * Autor: Adrià Boguñá Torres
 * Date: 27/09/2023
 * Description: controla les funcions de l'animador en el context d'un menú.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFunctions : MonoBehaviour
{
	[SerializeField] MenuButtonController menuButtonController;
	public bool disableOnce;

	// Mètode per reproduir un so en resposta a una animació.
	void PlaySound(AudioClip whichSound){
		if(!disableOnce){
			menuButtonController.audioSource.PlayOneShot (whichSound); // Reprodueix el so a través de l'AudioSource al controlador de botons del menú.
		}
		else{
			disableOnce = false;
		}
	}
}	
