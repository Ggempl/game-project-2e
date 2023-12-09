using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManger : MonoBehaviour
{
    public static SoundFXManger instance;

    [SerializeField] private AudioSource soundFXObject;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //spwan game object
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);
        //assign the audio clip
        audioSource.clip = audioClip;
        //asign volume
        audioSource.volume = volume;
        //play sound
        audioSource.Play();
        //get legnth of audio clip
        float clipLength = audioSource.clip.length;
        //destroy the clip after it stops playing
        Destroy(audioSource.gameObject, clipLength);
    }

}


