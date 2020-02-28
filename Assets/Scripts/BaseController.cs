using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public GameManager GM;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("Spaceship"))
        {
            GM.IncrementBaseScore();
            GM.remainingSeconds = CrossSceneInformation.MAX_TIME_HARVEST;
        }
    }
}
