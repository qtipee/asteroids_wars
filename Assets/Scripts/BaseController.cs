using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public GameManager GM;


    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Test");

        if (other.gameObject == GameObject.FindGameObjectWithTag("Spaceship"))
        {
            GM.IncrementBaseScore();
        }
    }
}
