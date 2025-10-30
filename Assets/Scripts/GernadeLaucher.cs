using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GernadeLaucher : Shooting
{
   private const int LeftButtonMouse = 0;
    public GameObject bulletPrefad;
    public Transform firingPos;
    public float bulletSpeed;
    public AudioSource ShootingSound;
    public Animator ani;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(LeftButtonMouse))
        {
            AddProjectile();
        }
    }
    private void ShootBullet()
    {
        ani.SetTrigger("Shoot");
    }
    public void PlaySoundFire()
    {
        ShootingSound.Play();
    }
    public void AddProjectile()
    {
     GameObject bullet = Instantiate(bulletPrefad,firingPos.position,firingPos.rotation);
        bullet.GetComponent<Rigidbody>().velocity = firingPos.forward * bulletSpeed;
    }
}
