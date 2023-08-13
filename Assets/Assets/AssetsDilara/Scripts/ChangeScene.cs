using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private GameObject text;
    private Animator doorAnim;
    [SerializeField] private GameObject door;
    void Start()
    {
        doorAnim = door.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            doorAnim.SetBool("openDoor",true);
            text.SetActive(true);
            if (Input.GetKey(KeyCode.E)) SceneManager.LoadScene("MenuScene");;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            text.SetActive(false);
        
        
    }
    
}
