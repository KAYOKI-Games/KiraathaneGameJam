using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurakCameraControl : MonoBehaviour
{
    public Transform player;

    [SerializeField] private float minY,maxY;
    [SerializeField] private float minX,maxX;
    // Update is called once per frame

    void Update ()
    {
        Vector3 playerPosition = player.transform.position;
        var position = transform.position;
        Vector3 transformPosition = position;

        transformPosition.x = Mathf.Clamp(playerPosition.x,minX,maxX);
        transformPosition.y = Mathf.Clamp(playerPosition.y,minY,maxY);

        position = Vector3.Lerp(position,transformPosition,2f);
        transform.position = position;
    }
}
