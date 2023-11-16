using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float velocidad = 5f;
    private float velocidadRotacion = 720f;
    private float horizontal;
    private float vertical;
    private float angulo;
    private Vector2 movimiento;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        movimiento = new Vector2(horizontal, vertical);
        movimiento.Normalize();
        transform.Translate(movimiento * (velocidad * Time.deltaTime), Space.World);

        if (movimiento != Vector2.zero)
        {
            angulo = Mathf.Atan2(movimiento.y, movimiento.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angulo), velocidadRotacion * Time.deltaTime);

            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }
}