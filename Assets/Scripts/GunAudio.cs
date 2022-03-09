using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GunAudio : MonoBehaviour
{    
    [SerializeField] private AudioClip ShootingSound;
    [SerializeField] private AudioClip ReloadSound;
    [Space]
    [SerializeField] [Range(0,1)] private float PitchOffset;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayReloadClip()
    {
        audioSource.pitch = 1;
        audioSource.PlayOneShot(ReloadSound);
    }

    public void PlayShootingClip()
    {
        audioSource.pitch = 1 + Random.Range(-PitchOffset, PitchOffset);
        audioSource.PlayOneShot(ShootingSound);
    }
}
