using UnityEngine;

[CreateAssetMenu(fileName = "Entity_SO", menuName = "Scriptable Objects/Entity_SO")]
public class Entity_SO : ScriptableObject
{
    public string eName;
    public float eMoveSpeed;
    public int eHP;
    public int eTeam;
    public int eDamage;
}
