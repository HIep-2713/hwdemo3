using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AmoTextBider : MonoBehaviour
{
    public Text LoadedAmoText;
    public GunAmo gunAmo;
    void Start()
    {
        gunAmo.loadedAmoChange.AddListener(UpdateGunAmo);
        UpdateGunAmo();
    }

    void UpdateGunAmo()
    {
        LoadedAmoText.text = gunAmo.LoadedAmo.ToString();
    }
}
