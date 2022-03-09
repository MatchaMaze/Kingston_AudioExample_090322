using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoorOpener : MonoBehaviour, InteractiveObject
{ 
    bool closed = true;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Activate()
    {
        if (closed)
        {
            closed = false;
            StartCoroutine(OpenDoor());
        }
    }

    IEnumerator OpenDoor()
    {        
        float t = 0;
        audioSource.Play();

        foreach (EnemyMovement em in FindObjectsOfType<EnemyMovement>(true))
        {
            em.gameObject.SetActive(true);
        }

        while (t < 3)
        {            
            yield return new WaitForSeconds(0.01f);
            t += 0.01f;
            transform.rotation = Quaternion.Euler(Mathf.Lerp(0, -110, t / 3f) * Vector3.up);
        }
    }

}
