using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HitSurFaceType
{
    Drit =0,
    Blood = 1,
}
[System.Serializable]
public class hitEffectMapper
{
    public HitSurFaceType hitSurFace;
    public GameObject effectPrefad;
}
public class HitPrefadManager:MonoBehaviour
{
    public hitEffectMapper[] effectMap;
}