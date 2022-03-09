using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] float Speed;
    Transform target;

    void Start()
    {        
        target = Camera.main.transform;
        AudioSource audio = GetComponent<AudioSource>();
        audio.time = Random.value * audio.clip.length;
    }
    
    void Update()
    {
        transform.LookAt(target.position);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        transform.position += transform.forward * Speed * Time.deltaTime;
    }
}
