/*
 * Autor: Adrià Boguñá Torres
 * Date: 24/09/2023
 * Description: controla la navegació entre opcions de menú utilitzant una entrada vertical.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonController : MonoBehaviour {

	
	public int index; // Es fa servir per rastrejar l'índex actual de l'opció de menú seleccionada.
	[SerializeField] bool keyDown;
	[SerializeField] int maxIndex;
	public AudioSource audioSource;

	void Start () 
	{
		audioSource = GetComponent<AudioSource>();
	}

	/// <summary>
	/// es verifica si s'està pressionant una entrada vertical (a dalt oa baix). 
    /// Si es detecta una entrada, el codi s'assegura que no es processin múltiples entrades alhora (usant keyDown). 
    /// Després, depenent de si l'entrada és cap amunt o cap avall, s'ajusta l'índex de l'opció de menú seleccionada. 
    /// Si s'assoleix el valor màxim d'índex, es reinicia a 0 i viceversa.
	/// </summary>
	void Update () 
	{
		if(Input.GetAxis ("Vertical") != 0){
			if(!keyDown){
				if (Input.GetAxis ("Vertical") < 0) {
					if(index < maxIndex){
						index++;
					}else{
						index = 0;
					}
				} else if(Input.GetAxis ("Vertical") > 0){
					if(index > 0){
						index --; 
					}else{
						index = maxIndex;
					}
				}
				keyDown = true;
			}
		}else{
			keyDown = false;
		}
	}

}
