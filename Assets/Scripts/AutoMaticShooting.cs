using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Events;

public class AutoMaticShooting : Shooting
{
    public Animator ani;
    public int rpm;
    //public GameObject hitMarkerPrefad;
    //public Camera cam;
    //public LayerMask layerMask;
    public AudioSource FireSound;
   private float interval;
    private float lastshoot;
    public UnityEvent onShoot;
    public RunRayCaster rayCaster;
    // Start is called before the first frame update
    void Start()
    {
        interval = 60 / rpm;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Updatefiring();
        }
    }
    void Updatefiring()
    {
        if (Time.time - lastshoot >= interval)
        {
            Shoot();
            lastshoot = Time.time;
        }
    }
    void Shoot()
    {
        ani.Play("Shoot", layer: -1, normalizedTime: 0);

        if (FireSound != null)
            FireSound.Play();
        if (rayCaster != null)
            rayCaster.PerformRaycastting();

        onShoot.Invoke();
    }

}
