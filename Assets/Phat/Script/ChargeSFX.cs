using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeSFX : MonoBehaviour
{
    public AudioSource audioSource;
    public float fromSecond, toSecond;
    public bool loop;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(!loop)
        {
            Debug.Log("a");
            PlaySoundInterval(fromSecond, toSecond);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(loop)
        {
            if (!audioSource.isPlaying)
            {
                Debug.Log("b");
                PlaySoundInterval(fromSecond, toSecond);
            }
        }             
    }
    void PlaySoundInterval(float fromSeconds, float toSeconds)
    {
        audioSource.time = fromSeconds;
        audioSource.Play();
        audioSource.SetScheduledEndTime(AudioSettings.dspTime + (toSeconds - fromSeconds));
    }
}
