using UnityEngine;

public class EnnemieMovement : MonoBehaviour
{
    public Transform player; // Le joueur
    [SerializeField] private E_Ennemie_SO ennemie_SO;
    [SerializeField] private Rigidbody2D ennemieRB;
    public float moveSpeed = 2f; // Vitesse de d�placement de l'ennemi
    public float stoppingDistance = 0.5f; // Distance � laquelle l'ennemi s'arr�te du joueur
    public bool canAttackB;

    private void Awake()
    {
        moveSpeed = ennemie_SO.eMoveSpeed;
        stoppingDistance = ennemie_SO.ennStoppingDistance;
    }

    private void Update()
    {
        // V�rifier si le joueur existe
        if (player != null)
        {
            // Calculer la direction vers le joueur
            Vector3 direction = (player.position - transform.position).normalized;

            // D�placer l'ennemi vers le joueur
            if (Vector3.Distance(transform.position, player.position) <= stoppingDistance)
            {
                ennemieRB.linearVelocity = Vector2.zero;
                canAttackB = true;
                gameObject.GetComponent<EnnemieAttack>().canAttackB = canAttackB;
                return;
            }
            // V�rifier si l'ennemi est assez loin du joueur pour se d�placer
            if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
            {
                ennemieRB.linearVelocity = transform.TransformDirection(direction * moveSpeed * Time.deltaTime);
                canAttackB = false;
                gameObject.GetComponent<EnnemieAttack>().canAttackB = canAttackB;
            }
        }
    }
}

