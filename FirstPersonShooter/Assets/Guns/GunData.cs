using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun Data", menuName = "Gun Data")]

public class GunData : ScriptableObject
{
    public float range = 1000f;
    public int ammo_per_clip = 12;
    public bool automatic = false;
}
