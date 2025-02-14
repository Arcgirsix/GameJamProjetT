using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private int eHP;

    private void Awake()
    {
        gameObject.GetComponentInParent<EntityInfo>().eHP = eHP;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("aaaaaaaaaaaaaaaaaaaaa");
        gameObject.GetComponentInParent<EntityInfo>().eHP = eHP;
        AttackInfo attackInfo = collision.gameObject.GetComponent<AttackInfo>();
        Debug.Log("ccccccccccccccccccccccccccccccccccccc");
        if (collision.gameObject.GetComponent<AttackInfo>())
        {
            Debug.Log("bbbbbbbbbbbbbbbbbbbbbbbbbbbbb");
            eHP -= attackInfo.aDamage;
            gameObject.GetComponentInParent<EntityInfo>().eHP = eHP;
            if (eHP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
