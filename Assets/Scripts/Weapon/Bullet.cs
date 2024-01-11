using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float velocidad;
    [SerializeField] private float daño;


    private void Update()
    {
        transform.Translate(Vector3.up * (velocidad * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.name);
        switch (other.tag)
        {
            case "Enemigo":
                other.GetComponent<EnemiMovement>().TomarDaño(daño);
                gameObject.SetActive(false);
                //Destroy(gameObject);
                break;
            case "Tower":
                other.GetComponent<TowerHealth>().TomarDaño(daño);
                gameObject.SetActive(false);
                //Destroy(gameObject);
                break;
            case "Wall":
                gameObject.SetActive(false);
                Debug.Log("trigger");
                //Destroy(gameObject);
                break;

        }
    }
    // escoger por trigger o collision
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Hey");
        gameObject.SetActive(false);
    }
}
