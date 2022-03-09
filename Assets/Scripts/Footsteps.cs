using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FootstepAudioHolder
{
    public string EviormentType;
    public List<AudioClip> AudioClipList;
}

[RequireComponent(typeof(AudioSource))]
public class Footsteps : MonoBehaviour
{   
    [SerializeField] PlayerController playerController;
    [Space]
    [SerializeField] List<FootstepAudioHolder> FootstepsAudios;

    AudioSource audioSource;
    float timer = 0;

    private void Start()
    {
        timer = 0;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (playerController.IsMoving())
        { 
            timer += playerController.GetCurrentSpeed() * Time.deltaTime;
            if (timer >= 1)
            {
                timer %= 1;
                audioSource.pitch = playerController.IsRunning() ? 1.1f : 1;
                audioSource.PlayOneShot(FootstepsAudios[0].AudioClipList[Mathf.FloorToInt(UnityEngine.Random.value* FootstepsAudios[0].AudioClipList.Count)]);
            }
        }
    }
}
