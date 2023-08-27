using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXList : MonoBehaviour
{
    public List<AudioClip> clip;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void SFXPlayer(int clipIndex)
    {         
        audioSource.PlayOneShot(clip[clipIndex]);
        Debug.Log("One Shot");
    }

    public void SFXPlayer(int clipIndex,bool loop)
    {
        if (!audioSource.isPlaying)
        {
            Debug.Log("play");
            audioSource.PlayOneShot(clip[clipIndex]);
        }
    }
}
