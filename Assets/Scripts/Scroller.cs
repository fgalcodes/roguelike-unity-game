using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage _img;
    [SerializeField] private float _x, _y;

    private GameObject _player;


    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame

    void Update()
    {
        if (_player != null)
        {
            Vector3 direction = _player.transform.position; // Calculate direction vector

            // Normalize the direction vector to get a unit vector pointing in the same direction
            direction.Normalize();

            _x = direction.x; // Assign x component of direction to _x
            _y = direction.y; // Assign y component of direction to _y
        }

        _img.uvRect = new Rect(_img.uvRect.position + new Vector2(_x, _y) * Time.deltaTime, _img.uvRect.size);
    }

}
