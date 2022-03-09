using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioEnviormentChanger : MonoBehaviour
{
    [SerializeField] AudioMixerSnapshot outsideAudioEnviorment;
    [SerializeField] AudioMixerSnapshot insideAudioEnviorment;


    private void OnTriggerEnter(Collider other)
    {        
        insideAudioEnviorment.TransitionTo(1);
    }

    private void OnTriggerExit(Collider other)
    {
        outsideAudioEnviorment.TransitionTo(1);
    }


}
