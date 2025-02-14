using UnityEngine;

[CreateAssetMenu(fileName = "Weapon_SO", menuName = "Scriptable Objects/Weapon_SO")]
public class Weapon_SO : ScriptableObject
{
    public int damage;
    public float atckSpeed;
    public float size;
    public float range;
    public int team;
    public int weaponType;
}
