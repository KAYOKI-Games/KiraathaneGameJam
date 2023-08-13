using Unity.VisualScripting;
using UnityEngine;

public class exit : MonoBehaviour
{
    public GameObject gameWinObject;
    public float delayTime = 5.0f;
    private bool isPlayerNearby = false;
    private bool interaction = false;
    public Collision collisionx;

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                interaction = true;
            }
            else
            {
                interaction = false;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision == collisionx)
        {
            Invoke("ActivateGameWinObject", delayTime);
        }
        
    }

    private void ActivateGameWinObject()
    {
        gameWinObject.SetActive(true);
    }
}