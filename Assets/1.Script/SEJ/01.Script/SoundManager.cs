using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundMN;
    private void Awake()
    {
        soundMN = this;

    }
    AudioSource sound;
    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        sound.playOnAwake = false;

        if (DB.instance.Volume == 0)
        {
            Debug.Log("DB.instance.Volume == " + DB.instance.Volume);
            StopSound();
        }
        else
        {
            Debug.Log("DB.instance.Volume:" + DB.instance.Volume);
            PlaySound();
        }

    }
    public void PlaySound()
    {
        sound.Play();
    }
    public void StopSound()
    {
        sound.Stop();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
