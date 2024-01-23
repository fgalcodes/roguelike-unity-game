using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float _timer;
    private GameObject _player;

    [SerializeField] private float bulletRange = 14;


    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(_player.transform);
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, _player.transform.position);

        // Debug.Log(distance);

        if (distance < bulletRange)
        {
            RotateTowards();
            _timer += Time.deltaTime;

            if (_timer > 2)
            {
                _timer = 0;
                Shoot();
            }
        }
    }

    private void RotateTowards()
    {
        var playerPos = _player.transform.position;
        var position = transform.position;

        float angle = Mathf.Atan2(playerPos.y - position.y, playerPos.x - position.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);

        transform.rotation = targetRotation;
    }

    void Shoot()
    {
        Debug.Log(("shoot"));
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
