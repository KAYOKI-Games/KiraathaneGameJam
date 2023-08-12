using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TMP_Text dialogText;
    [SerializeField]
    private string[] cumleler;

    [SerializeField] private float yazmaHizi;

    IEnumerator Yaz()
    {
        foreach (string cumle in cumleler)
        {
            foreach (char harf in cumle)
            {
                dialogText.text += harf;
                yield return new WaitForSeconds(yazmaHizi);
            }
            yield return new WaitForSeconds(1f);
            dialogText.text = "";
        }
        gameObject.SetActive(false);
    }

   
    void Start()
    {
        StartCoroutine(Yaz());
    }
    
}
