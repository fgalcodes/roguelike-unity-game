using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerWeapon : ScriptableObject
{

    enum Weapon
    {
        Knife,
        Pistol,
        Sniper,
        flamethrower
    }

    [SerializeField] Weapon currentWeapon;

}
