using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemieCollisionDetector : MonoBehaviour
{
    private int wTeam = 0;
    private int eTeam = 0;
    private int eHP;

    private void Awake()
    {
        gameObject.GetComponentInParent<EntityInfo>().eHP = eHP;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponentInParent<EntityInfo>().eHP = eHP;
        EntityInfo entityInfo = collision.gameObject.GetComponent<EntityInfo>();
        WeaponInfo weaponInfo = collision.gameObject.GetComponent<WeaponInfo>();
        if (collision.gameObject.GetComponent<WeaponInfo>())
        {
            int wTeam = weaponInfo.wTeam;

            if (collision != null && (eTeam != 1 || wTeam != 1))
            {
                eHP -= weaponInfo.wDamage;
                gameObject.GetComponentInParent<EntityInfo>().eHP = eHP;
                if (gameObject.GetComponentInParent<EntityInfo>().eHP <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
        else if (collision.gameObject.GetComponent<EntityInfo>())
        {
            int eTeam = entityInfo.eTeam;

            if (collision != null && (eTeam != 1 || wTeam != 1))
            {
                entityInfo.eHP = entityInfo.eHP - weaponInfo.wDamage;
                gameObject.GetComponentInParent<EntityInfo>().eHP = entityInfo.eHP;
                if (entityInfo.eHP < 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
