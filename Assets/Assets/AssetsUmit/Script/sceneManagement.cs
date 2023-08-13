using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;
using Vector3 = UnityEngine.Vector3;

public class sceneManagement : MonoBehaviour

{
    [SerializeField] private GameObject cutOut;
    [SerializeField] private GameObject player;
    private Boolean isDone = false;
    private Boolean isFinish = false;

    // Update is called once per frame
    void Update()
    {
        if (CollectGolds.isCollected && !isDone)
        {
            isDone = true;
            StartCoroutine(handleCutOut());
        }

               
    }

    IEnumerator handleCutOut()
    {
        cutOut.SetActive(true);
        Vector3 setLocalScale = new Vector3(player.transform.localScale.x * -1, player.transform.localScale.y,
            player.transform.localScale.z);
        player.transform.localScale = setLocalScale;
        player.GetComponent<Animator>().enabled=false;
        player.GetComponent<PlayerController>().enabled = false;
        yield return new WaitForSeconds(17f);
        setLocalScale.x = setLocalScale.x * -1;
        player.transform.localScale = setLocalScale;
        player.GetComponent<PlayerController>().enabled = true;;
        player.GetComponent<Animator>().enabled = true;
    }
}
