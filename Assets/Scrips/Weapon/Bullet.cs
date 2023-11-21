using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float velocidad;
    [SerializeField] private float da�o;

    private void Update()
    {
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.name);
        if (other.CompareTag("Enemigo"))
        {
            other.GetComponent<EnemiMovement>().TomarDa�o(da�o);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
