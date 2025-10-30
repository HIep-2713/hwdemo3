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
    public HitSurFaceType surface;
    public GameObject effectPrefad;
}
public class HitPrefadManager:Singleton<HitPrefadManager>
{
    public hitEffectMapper[] effectMap;
    public GameObject GetEffectPrefad(HitSurFaceType hitSurFace)
    {
        hitEffectMapper mapper = System.Array.Find(effectMap,x=>x.surface == hitSurFace);
        return mapper?.effectPrefad;
    }
}