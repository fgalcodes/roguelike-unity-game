using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float _timer;
    private GameObject _player;

    [SerializeField] private float bulletRange = 14;

    public Transform target;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("Find");
        _player = GameObject.FindGameObjectWithTag("Player");
        Instantiate(bullet);
    }

    // Update is called once per frame
    void Update()
    {
        // Determine which direction to rotate towards
        Vector3 targetDirection = target.position - transform.position;

        // The step size is equal to speed times frame time.
        float singleStep = speed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);


        float distance = Vector2.Distance(transform.position, _player.transform.position);

        // Debug.Log(distance);

        if (distance < bulletRange)
        {
            _timer += Time.deltaTime;

            if (_timer > 2)
            {
                _timer = 0;
                //Shoot();
            }
        }
    }
    void Shoot()
    {
        Debug.Log(("shoot"));
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
