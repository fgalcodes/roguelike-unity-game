using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiMovement2 : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;

    private Healthbar healthBar;

    public BloodEffect bloodEffect;
    public float bloodDuration = 60f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar = GetComponentInChildren<Healthbar>();
        if (healthBar != null)
        {
            healthBar.UpdateHealthbar(maxHealth, currentHealth, currentHealth);
        }
    }

    private void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    public void TomarDaño(float daño)
    {
        currentHealth -= daño;

        if (currentHealth <= 0)
        {
            DestroyEnemy();
        }

        if (healthBar != null)
        {
            healthBar.UpdateHealthbar(maxHealth, currentHealth, currentHealth + daño);
        }
    }
    void DestroyEnemy()
    {

        if (bloodEffect != null)
        {
            bloodEffect.ShowBloodEffect(transform.position, bloodDuration);
        }

        Destroy(gameObject);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        // Obtener el componente PlayerMovement (o el que corresponda)
    //        PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement>();

    //        if (playerMovement != null)
    //        {
    //            // Llamar al método TomarDaño del jugador o hacer cualquier otra acción
    //            playerMovement.TomarDaño(daño); // O cualquier método para hacer daño al jugador
    //        }

    //        DestroyEnemy(); // Destruir al enemigo cuando colisiona con el jugador
    //    }
    //}
}