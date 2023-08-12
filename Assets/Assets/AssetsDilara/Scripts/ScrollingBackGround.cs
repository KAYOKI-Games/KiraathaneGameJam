using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackGround : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] private float minX, maxX;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        var position = transform.position;
        Vector3 transformPosition = position;

        transformPosition.x = Mathf.Clamp(transformPosition.x + (speed ), minX, maxX);

        position = Vector3.Lerp(transform.position, transformPosition, 2f);
        transform.position = position;

        // Check if max limits are reached, then reset position
        if (transform.position.x >= maxX)
        {
            transform.position = initialPosition;
        }
    }

}
