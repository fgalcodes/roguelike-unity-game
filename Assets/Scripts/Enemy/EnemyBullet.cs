using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody2D _rb;
    private float _timer;

    [SerializeField] private float force = 5;
    [SerializeField] private int bulletDamage = 10;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = _player.transform.position - transform.position;
        _rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);

    }

    // Update is called once per frame
    // void Update()
    // {
    //     _timer += Time.deltaTime;
    //
    //     if (_timer > 10)
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Bullet"))
        {
            GolpePersonaje playerScript = other.GetComponent<GolpePersonaje>();
            if (playerScript != null)
            {
                // Aplicar daño al jugador
                playerScript.TomarDaño(bulletDamage);
            }
            Destroy(gameObject);
        }
    }
}
