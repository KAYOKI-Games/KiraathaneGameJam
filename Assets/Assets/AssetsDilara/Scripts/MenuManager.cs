using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private GameObject SoundOnButton;
    [SerializeField] private GameObject SoundOffButton;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        source.clip = backgroundMusic;
        source.Play();
        
    }

    public void SoundOn()
    {
        source.mute = false;
        SoundOnButton.SetActive(true);
        SoundOffButton.SetActive(false);
        
    }
    
    public void SoundOff()
    {
        source.mute = true;
        SoundOnButton.SetActive(false);
        SoundOffButton.SetActive(true);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("FirstScene");
    }
    
}
