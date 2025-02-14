using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponGestion : MonoBehaviour
{
    [SerializeField] private  Weapon_SO weapon_SO;

    public float moveSpeed = 5f; // Vitesse de déplacement de l'empty object
    public Transform player; // Le personnage à suivre
    public float maxDistance = 5f; // Distance maximale entre l'empty object et le personnage
    private float weaponRotation;
    public float minDistance = 5f;
    public int wWeaponType;
    public bool isSword = false;
    public bool isMagicWand = false;
    InputAction shoot;
    Quaternion lastRota;

    private Camera cam;

    private void Awake()
    {
        moveSpeed = weapon_SO.atckSpeed;
        maxDistance = weapon_SO.range;
        cam = Camera.main; // Récupère la caméra principale
        shoot = InputSystem.actions.FindAction("RMB");
    }

    private void Start()
    {
        wWeaponType = gameObject.GetComponentInChildren<WeaponInfo>().wWeaponType;
        if (wWeaponType == 0)
        {
            isSword = true;
        }

        if (wWeaponType == 1)
        {
            isMagicWand = true;
        }
    }

    void Update()
    {
       
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition); // Convertit la position de la souris en coordonnées du monde
        mousePosition.z = 0f; // Assure-toi que l'empty object reste sur le même plan Z
        Vector2 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        mousePosition.z = 0f; // Assure-toi que l'empty object reste sur le même plan Z


        // Calcule la distance entre l'empty object et le personnage
        float distanceToPlayer = Vector3.Distance(mousePosition, player.position);
        // Si la distance est supérieure à la distance maximale, ajuste la position de l'empty object
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


        // Déplace l'empty object vers la position de la souris
        transform.position = Vector3.MoveTowards(transform.position, mousePosition, moveSpeed * Time.fixedDeltaTime);
        if (transform.position == Input.mousePosition)
        {
            transform.rotation = lastRota;
            return;
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        lastRota = Quaternion.Euler(new Vector3(0, 0, angle));

        if (isMagicWand && shoot.ReadValue<float>() != 1f)
        {
            gameObject.GetComponent<Spell>().enabled = false;
            return;
        }

        if (isMagicWand)
        {
            gameObject.GetComponent<Spell>().enabled = true;
            gameObject.GetComponent<Spell>().projRotation = Quaternion.Euler(new Vector3(0, 0, angle)); ;
        }


        //Debug.Log(shoot.ReadValue<float>());


    }
}
