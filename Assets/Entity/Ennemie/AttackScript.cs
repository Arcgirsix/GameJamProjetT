using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public bool canDestroy = false;
    float canDestroyDelay = 0f;
    public int size;
    public float lifetime;
    public int damage;
    public float speed;

    private void Start()
    {
        lifetime = gameObject.GetComponent<AttackInfo>().aLifetime;
        damage = gameObject.GetComponent<AttackInfo>().aDamage;
        size = gameObject.GetComponent<AttackInfo>().aSize;
        speed = gameObject.GetComponent<AttackInfo>().aSpeed;

        gameObject.GetComponent<CircleCollider2D>().radius = size;
    }

    private void Update()
    {
        Lifetime();
        if (canDestroy)
        {
            Destroy(gameObject);
        }
    }



    void Lifetime()
    {
        if (canDestroyDelay < lifetime)
        {
            canDestroyDelay += Time.fixedDeltaTime;
            return;
        }
        if (canDestroyDelay >= lifetime)
        {
            canDestroy = true;
        }
    }
}
