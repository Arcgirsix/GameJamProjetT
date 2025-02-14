using UnityEngine;

public class EntityInfo : MonoBehaviour
{
    public Entity_SO player_SO;
    public string eName;
    public float eMoveSpeed;
    public int eHP;
    public int eTeam;
    public int eDamage;
    public float ennAtckSpeed;
    public float ennDetecRange;
    public int ennDamage;

    public void Awake()
    {
        eName = player_SO.eName;
        eMoveSpeed = player_SO.eMoveSpeed;
        eHP = player_SO.eHP;
        eTeam = player_SO.eTeam;
        eDamage = player_SO.eDamage;
    }
}
