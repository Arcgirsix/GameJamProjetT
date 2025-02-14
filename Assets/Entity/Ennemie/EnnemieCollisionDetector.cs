using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemieCollisionDetector : MonoBehaviour
{
    private int eHP;
    [SerializeField] private float timer;
    [SerializeField] private float delay;
    [SerializeField] private bool canBeHit;

    private void Awake()
    {
         eHP = gameObject.GetComponentInParent<EntityInfo>().eHP;
    }

    private void Update()
    {
        if (canBeHit == false)
        {
            if (delay < timer)
            {
                delay += Time.fixedDeltaTime;
                return;
            }
            canBeHit = true;
            delay = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (canBeHit)
        {
            eHP = gameObject.GetComponentInParent<EntityInfo>().eHP;

            if (collision.gameObject.GetComponent<WeaponInfo>())
            {
                WeaponInfo weaponInfo = collision.gameObject.GetComponent<WeaponInfo>();
                int wTeam = weaponInfo.wTeam;

                if (collision != null && (wTeam == 1))
                {
                    canBeHit = false;
                    eHP -= weaponInfo.wDamage;
                    if (eHP <= 0)
                    {
                        Destroy(gameObject);
                    }
                    gameObject.GetComponentInParent<EntityInfo>().eHP = eHP;
                    return;
                }
            }
            else if (collision.gameObject.GetComponent<EntityInfo>())
            {
                EntityInfo entityInfo = collision.gameObject.GetComponent<EntityInfo>();
                int eTeam = entityInfo.eTeam;

                if (collision != null && (eTeam == 1))
                {
                    canBeHit = false;
                    eHP -= entityInfo.eDamage;
                    if (eHP <= 0)
                    {
                        Destroy(gameObject);
                    }
                    gameObject.GetComponentInParent<EntityInfo>().eHP = eHP;
                    return;
                }
            }

            else if (collision.gameObject.GetComponent<MagicProjectil>())
            {
                MagicProjectil magicProjectil = collision.gameObject.GetComponent<MagicProjectil>();
                if (collision != null)
                {
                    canBeHit = false;
                    eHP -= magicProjectil.mDamage;
                    if (eHP <= 0)
                    {
                        Destroy(gameObject);
                    }
                    gameObject.GetComponentInParent<EntityInfo>().eHP = eHP;
                    return;
                }
            }
        }
        
    }
}
