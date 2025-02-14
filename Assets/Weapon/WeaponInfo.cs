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
    public int wWeaponType;
    public bool isSword = false;
    public bool isMagicWand = false;

    private void Awake()
    {
        wDamage = weapon_SO.damage;
        wAtckSpeed = weapon_SO.atckSpeed;
        wSize = weapon_SO.size;
        wRange = weapon_SO.range;
        wTeam = weapon_SO.team;
        wWeaponType = weapon_SO.weaponType;
    }

    private void Start()
    {
        if (wDamage == 0)
        {
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        }
    }
}
