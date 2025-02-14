using UnityEngine;

public class MagicProjectil : MonoBehaviour
{
    public float projectileSpeed = 10f; // Vitesse du projectile
    public float explosionRadius = 5f; // Rayon de l'explosion
    public float explosionForce = 10f; // Force de l'explosion
    public int mDamage;
    [SerializeField] private CircleCollider2D mCollider;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * projectileSpeed; // D�place le projectile selon la direction de l'objet
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si le projectile touche un ennemi
        if (collision.gameObject.GetComponent<EntityInfo>().eTeam != 1)
        {
            Explode(collision.transform.position); // D�clenche l'explosion � la position de la collision
            Destroy(gameObject); // D�truit le projectile
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
