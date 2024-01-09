using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScrollerAxis : MonoBehaviour
{
    [SerializeField] private RawImage _img;
    [SerializeField] private float _scrollSpeed;
    [SerializeField] private float _damping;

    private Vector2 _currentDirection = Vector2.zero;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // Get horizontal input axis
        float verticalInput = Input.GetAxis("Vertical"); // Get vertical input axis

        Vector2 direction = new Vector2(horizontalInput, verticalInput).normalized; // Create direction vector from input

        if (direction.magnitude > 0.1f)
        {
            _currentDirection = direction; // Update current direction if new input is given
        }

        _img.uvRect = new Rect(_img.uvRect.position + (_currentDirection * _damping) * _scrollSpeed * Time.deltaTime, _img.uvRect.size);
    }


}
