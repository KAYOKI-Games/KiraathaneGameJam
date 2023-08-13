using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGolds : MonoBehaviour
{
    // Start is called before the first frame update
   private AudioSource collectCoins;
   internal static Boolean isCollected = false;

   private void Start()
   {
       collectCoins = GameObject.Find("collectCoins").GetComponent<AudioSource>();
   }

   private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isCollected = true;
            collectCoins.Play();
            Destroy(gameObject);
        }
    }
}
