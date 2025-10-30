using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunAmo : Shooting
{
    public int magsize ;            
    public float reloadTime = 1.5f;      
    public Shooting shooting;
    public AudioSource reloadSound;
    public UnityEvent loadedAmoChange;
    private int _LoadedAmo;
    private bool isReloading = false;
    private float reloadTimer = 0f;

    public int LoadedAmo
    {
        get => _LoadedAmo;
        set
        {
            _LoadedAmo = value;
            loadedAmoChange?.Invoke();

            if (_LoadedAmo <= 0 && !isReloading)
            {
                StartReload();
            }
        }
    }

    private void Start()
    {
        _LoadedAmo = magsize;
        loadedAmoChange?.Invoke();
    }

    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.R) && !isReloading && LoadedAmo < magsize)
        {
            StartReload();
        }

       
        if (isReloading)
        {
            reloadTimer += Time.deltaTime;
            if (reloadTimer >= reloadTime)
            {
                FinishReload();
            }
        }
    }

  
    public void SingleFireAmmoCouter()
    {
        if (!isReloading && _LoadedAmo > 0)
        {
            LoadedAmo--;
        }
    }

    
    private void StartReload()
    {
        isReloading = true;
        reloadTimer = 0f;
        LockShooting();

        
        if (reloadSound != null)
            reloadSound.Play();
    }

   
    private void FinishReload()
    {
        isReloading = false;
        _LoadedAmo = magsize;       
        loadedAmoChange?.Invoke();
        UnlockShooting();
    }

    private void LockShooting()
    {
        if (shooting != null)
            shooting.enabled = false;
    }

    private void UnlockShooting()
    {
        if (shooting != null)
            shooting.enabled = true;
    }

    public void OnSeclected()
    {
        UpdateShootingLock();
    }

    public void UpdateShootingLock()
    {
        if (shooting != null)
            shooting.enabled = _LoadedAmo > 0 && !isReloading;
    }
}
