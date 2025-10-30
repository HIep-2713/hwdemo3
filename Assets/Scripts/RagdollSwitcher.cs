using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollSwitcher : MonoBehaviour
{
    public Animator ani;
    public Rigidbody[] rb;
    [ContextMenu("Retrieve Rigibodies")]
    private void RetrieveRigibodies()
    {
        rb = GetComponentsInChildren<Rigidbody>();
    }
    [ContextMenu("Clear Ragdoll")]
    private void ClearRagdoll()
    {
        CharacterJoint[] joints = GetComponentsInChildren<CharacterJoint>();
        for (int i = 0; i < joints.Length; i++)
        {
            DestroyImmediate(joints[i]);
        }
        Rigidbody[] rb = GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < rb.Length; i++)
        {
            DestroyImmediate(rb[i]);
        }
        Collider[] colls = GetComponentsInChildren<Collider>();
        for (int i = 0; i < colls.Length; i++)
        {
            DestroyImmediate(colls[i]);
        }
    }
    [ContextMenu("Enable Ragdoll")]
    public void EnableRagdoll()
    {
       SetRagdoll(true);
    }
    [ContextMenu("Disnable Ragdoll")]
    public void DisableRagdoll()
    {
        SetRagdoll(false);
    }
    private void SetRagdoll(bool ragdollEnable)
    {
        ani.enabled = !ragdollEnable;
        for (int i = 0;i < rb.Length;i++)
        {
            rb[i].isKinematic = !ragdollEnable;
        }
    }
    [ContextMenu("Add hitSurFace")]
    public void AddhitSurFace()
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (Collider col in colliders)
        {
            if (col.gameObject.GetComponent<HitSurFace>() == null)
            {
                var hitSurFace = col.gameObject.AddComponent<HitSurFace>();
                hitSurFace.SurFaceType = HitSurFaceType.Blood;
            }
        }
    }

}
