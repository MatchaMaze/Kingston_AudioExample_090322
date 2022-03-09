using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private int MagazineSize;
    [SerializeField] private float FireRate;
    [SerializeField] private float ReloadTime;
    [Space]
    [SerializeField] private GunAudio gunAudio;

    int currentAmmo;
    float fireTimer;

    void Start()
    {
        currentAmmo = MagazineSize;
        fireTimer = FireRate;
    }

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (Input.GetMouseButton(0) && FireRate <= fireTimer && currentAmmo > 0)
        {             
            gunAudio.PlayShootingClip();
            fireTimer = 0;
            currentAmmo--;
        }

        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < MagazineSize)
        {
            gunAudio.PlayReloadClip();
            currentAmmo = MagazineSize;
            fireTimer = FireRate - ReloadTime;
        }
    }
}
