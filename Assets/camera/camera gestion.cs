using UnityEngine;

public class Cameragestion : MonoBehaviour
{

    public float moveSpeed = 5f; // Vitesse de d�placement de l'empty object
    public Transform player; // Le personnage � suivre
    public float maxDistance = 5f; // Distance maximale entre l'empty object et le personnage

    private Camera cam;

    void Start()
    {
        cam = Camera.main; // R�cup�re la cam�ra principale
    }

    void Update()
    {
       
            Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition); // Convertit la position de la souris en coordonn�es du monde
            mousePosition.z = 0f; // Assure-toi que l'empty object reste sur le m�me plan Z

        mousePosition.z = 0f; // Assure-toi que l'empty object reste sur le m�me plan Z


        // Calcule la distance entre l'empty object et le personnage
        float distanceToPlayer = Vector3.Distance(mousePosition, player.position);
        // Si la distance est sup�rieure � la distance maximale, ajuste la position de l'empty object
        if (distanceToPlayer > maxDistance)
        {
            Vector3 directionToPlayer = (mousePosition - player.position).normalized;
            mousePosition = player.position + directionToPlayer * maxDistance;
        }

    
  
           // D�place l'empty object vers la position de la souris
           transform.position = Vector3.MoveTowards(transform.position, mousePosition, moveSpeed* Time.deltaTime);
  

    }
}
