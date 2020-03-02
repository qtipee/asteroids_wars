using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playCrashSound : MonoBehaviour
{

    private AudioSource audioSourceCrash;
    public AudioClip crashSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSourceCrash = gameObject.AddComponent<AudioSource>();
        audioSourceCrash.clip = crashSound;

        audioSourceCrash.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
