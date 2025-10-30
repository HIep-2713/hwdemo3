using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RotateByMouse : MonoBehaviour
{
    public float angleOverDistance;
    public Transform cameraHoder;
    public float maxPitch;
    public float minPitch;
    private float pitch;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        UpdateYaw();
        UpdatePitch();
    }
    private void UpdateYaw()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float deltaYaw = mouseX * angleOverDistance;
        transform.Rotate(0, deltaYaw, 0);
    }
    private void UpdatePitch()
    {
        float mouseY = Input.GetAxis("Mouse Y");
        float deltaPitch = -mouseY * angleOverDistance;
        pitch = Mathf.Clamp(pitch+deltaPitch,minPitch,maxPitch);
        cameraHoder.localEulerAngles = new Vector3(pitch,0,0);
    }
}
