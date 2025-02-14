using UnityEngine;

public class PlayerCollider : MonoBehaviour
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
        if (!canBeHit)
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
            AttackInfo attackInfo = collision.gameObject.GetComponent<AttackInfo>();
            if (collision.gameObject.GetComponent<AttackInfo>())
            {
                Debug.Log("bbbbbbbbbbbbbbbbbbbbbbbbbbbbb");
                eHP -= attackInfo.aDamage;
                if (eHP <= 0)
                {
                    Destroy(gameObject);
                }
                gameObject.GetComponentInParent<EntityInfo>().eHP = eHP;
            }
            canBeHit = false;
        }
    }
}
