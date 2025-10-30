using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    public GameObject[] guns; 
    
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i)
                ||Input.GetKeyDown(KeyCode.Keypad1 + i))
            {
                SetActiveGun(i);
            }
        }
    }
    void SetActiveGun(int gunIndex)
    {
        for(int i = 0;i < guns.Length;i++)
        {
            bool isAcrice = (i == gunIndex); 
            guns[i].SetActive(isAcrice);
            if (isAcrice)
            {
                guns[i].SendMessage("OnGunSelected",SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
