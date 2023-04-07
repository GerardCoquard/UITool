using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAudio : MonoBehaviour
{
    AudioSource audioSource;
    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update() {
        if(!audioSource.isPlaying && Time.timeScale != 0)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Delete(AudioSource audioSource)
    {
        while(audioSource.isPlaying || Time.timeScale == 0)
        {
            yield return null;
        }
        Destroy(audioSource.gameObject);
    }
}
