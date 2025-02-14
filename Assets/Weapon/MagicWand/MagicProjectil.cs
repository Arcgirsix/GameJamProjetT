using UnityEngine;

public class MagicProjectil : MonoBehaviour
{
    public float projectileSpeed = 10f; // Vitesse du projectile
    public float explosionRadius = 5f; // Rayon de l'explosion
    public float explosionForce = 10f; // Force de l'explosion
    public int mDamage;
    [SerializeField] private CircleCollider2D mCollider;

    [SerializeField] private float delay;
    [SerializeField] private float timer = 0.2f;
    public bool hasHitTheSecondTower = false;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * projectileSpeed; // D�place le projectile selon la direction de l'objet
    }

    private void Update()
    {
        if (hasHitTheSecondTower)
        {
            if (delay < timer)
            {
                delay += Time.fixedDeltaTime;
                return;
            }
            Destroy(gameObject); // D�truit le projectile
        }
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Si le projectile touche un ennemi
        if (collision.gameObject.GetComponent<WeaponInfo>())
        {
            mCollider.radius = explosionRadius;
            hasHitTheSecondTower = true;
        }
        if (collision.gameObject.GetComponent<EntityInfo>())
        {
            EntityInfo entityInfo = collision.gameObject.GetComponent<EntityInfo>();

            if (entityInfo.eTeam == 1)
            {
                return;
            }
            mCollider.radius = explosionRadius;
            hasHitTheSecondTower = true;
        }
        
    }

    void Explode(Vector2 explosionPosition)
    {
        // D�tecte tous les objets dans un rayon d'explosion
        Collider2D[] colliders = Physics2D.OverlapCircleAll(explosionPosition, explosionRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                // Applique une force d'explosion aux ennemis proches
                Rigidbody2D enemyRb = collider.GetComponent<Rigidbody2D>();
                if (enemyRb != null)
                {
                    Vector2 explosionDirection = collider.transform.position - new Vector3(explosionPosition.x, explosionPosition.y, 0f);
                    enemyRb.AddForce(explosionDirection.normalized * explosionForce, ForceMode2D.Impulse);
                }
            }
        }
    }
}
