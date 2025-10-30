using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumMuzzel : MonoBehaviour
{
    public Transform Muzzel;
    public float duration;
    // Start is called before the first frame update
    void Start()
    {
        HideMuzzle();
    }
public void ShowMuzzle()
    {
        Muzzel.gameObject.SetActive(true);
        float angle = Random.Range(0, 360f);
        Muzzel.localEulerAngles = new Vector3 (angle, 0, 0);
        CancelInvoke();
        Invoke(nameof(HideMuzzle), duration);
    }
    void HideMuzzle()
    {
        Muzzel.gameObject.SetActive (false);
    }
}
