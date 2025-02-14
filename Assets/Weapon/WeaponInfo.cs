using System;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponInfo : MonoBehaviour
{
    [SerializeField] private Weapon_SO weapon_SO;
    public int wDamage;
    public float wAtckSpeed;
    public float wSize;
    public float wRange;
    public int wTeam;

    private void Awake()
    {
        wDamage = weapon_SO.damage;
        wAtckSpeed = weapon_SO.atckSpeed;
        wSize = weapon_SO.size;
        wRange = weapon_SO.range;
        wTeam = weapon_SO.team;
    }
}
