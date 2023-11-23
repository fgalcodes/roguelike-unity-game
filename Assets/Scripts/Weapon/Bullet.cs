using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float velocidad;
    [SerializeField] private float da�o;


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
                other.GetComponent<EnemiMovement>().TomarDa�o(da�o);
                gameObject.SetActive(false);
                //Destroy(gameObject);
                break;
            case "Wall":
                gameObject.SetActive(false);
                //Destroy(gameObject);
                break;

        }
    }
}
