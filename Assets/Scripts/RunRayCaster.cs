using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunRayCaster : MonoBehaviour
{
    public GameObject HitMarkerPrefad;
    public Camera animingCamera;
    public LayerMask LayerMask;
    public int damage;
    public void PerformRaycastting()
    {
        Ray animingRay = new Ray(animingCamera.transform.position,animingCamera.transform.forward);
        if (Physics.Raycast(animingRay, out RaycastHit hitInfo, 1000f, LayerMask))
        {
            //Quaternion effectRotaion = Quaternion.LookRotation(hitInfo.normal);
           // Instantiate(HitMarkerPrefad,hitInfo.point,effectRotaion);
           ShowHitEffect(hitInfo);
            DeliverDamage(hitInfo);
        }
    }
    void DeliverDamage(RaycastHit hitInfo)
    {
        Debug.Log("Hit: " + hitInfo.collider.name);
        Health health = hitInfo.collider.GetComponentInParent<Health>();
        if (health != null)
        {
            Debug.Log("health name: " + health.name);
            health.TakeDamage(damage);
        }
        else
        {
            Debug.Log("ko trung muc tieu!");
        }
    }
   private void ShowHitEffect(RaycastHit hitInfo)
    {
        HitSurFace hitSurFace = hitInfo.collider.GetComponent<HitSurFace>();
        if(hitSurFace != null)
        {
            GameObject effectPrefad = HitPrefadManager.Instance.GetEffectPrefad(hitSurFace.SurFaceType);
            if (effectPrefad != null)
            {
                Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
                Instantiate(effectPrefad,hitInfo.point,effectRotation);
            }
        }

    }
}
