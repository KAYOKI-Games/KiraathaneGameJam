using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosenHouse : MonoBehaviour
{
    [SerializeField] private GameObject choosenHouse;
    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("ToggleChoosenHouse", 0.1f, 0.7f); // Her 1 saniyede bir ToggleChoosenHouse çağrılacak.
    }

    void ToggleChoosenHouse()
    {
        choosenHouse.SetActive(!choosenHouse.activeSelf);
    }
}
