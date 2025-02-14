using UnityEngine;

public class WeaponGestion : MonoBehaviour
{
    [SerializeField] private  Weapon_SO weapon_SO;

    public float moveSpeed = 5f; // Vitesse de d�placement de l'empty object
    public Transform player; // Le personnage � suivre
    public float maxDistance = 5f; // Distance maximale entre l'empty object et le personnage
    private float weaponRotation;
    public float minDistance = 5f;


    private Camera cam;

    private void Awake()
    {
        moveSpeed = weapon_SO.atckSpeed;
        maxDistance = weapon_SO.range;
        cam = Camera.main; // R�cup�re la cam�ra principale
    }

    void Update()
    {
       
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition); // Convertit la position de la souris en coordonn�es du monde
        mousePosition.z = 0f; // Assure-toi que l'empty object reste sur le m�me plan Z
        Vector2 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        mousePosition.z = 0f; // Assure-toi que l'empty object reste sur le m�me plan Z


        // Calcule la distance entre l'empty object et le personnage
        float distanceToPlayer = Vector3.Distance(mousePosition, player.position);
        // Si la distance est sup�rieure � la distance maximale, ajuste la position de l'empty object
        if (distanceToPlayer > maxDistance)
        {
            Vector3 directionToPlayer = (mousePosition - player.position).normalized;
            mousePosition = player.position + directionToPlayer * maxDistance;
            
        }
        if (distanceToPlayer < minDistance)
        {
            Vector3 directionToPlayer = (mousePosition - player.position).normalized;
            mousePosition = player.position + directionToPlayer * minDistance;
        }



        // D�place l'empty object vers la position de la souris
        transform.position = Vector3.MoveTowards(transform.position, mousePosition, moveSpeed* Time.deltaTime);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));


    }
}
