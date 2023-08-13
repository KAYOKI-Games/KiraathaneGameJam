using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reflectiveObject : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("ToggleObject", 0.1f, 0.7f);
    }


    private void ToggleObject()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }


}
