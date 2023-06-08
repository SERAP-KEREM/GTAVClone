using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCutScenePlayer : MonoBehaviour
{
    public GameObject cutScenePlayer;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag=="Bus")
        {
            cutScenePlayer.SetActive(true);
        }
    }
}
