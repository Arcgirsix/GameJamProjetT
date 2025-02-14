using UnityEngine;

public class Cameragestion : MonoBehaviour
{

    public float moveSpeed = 5f; // Vitesse de déplacement de l'empty object
    public Transform player; // Le personnage à suivre
    public float maxDistance = 5f; // Distance maximale entre l'empty object et le personnage

    private Camera cam;

    void Start()
    {
        cam = Camera.main; // Récupère la caméra principale
    }

    void Update()
    {
       
            Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition); // Convertit la position de la souris en coordonnées du monde
            mousePosition.z = 0f; // Assure-toi que l'empty object reste sur le même plan Z

        mousePosition.z = 0f; // Assure-toi que l'empty object reste sur le même plan Z


        // Calcule la distance entre l'empty object et le personnage
        float distanceToPlayer = Vector3.Distance(mousePosition, player.position);
        // Si la distance est supérieure à la distance maximale, ajuste la position de l'empty object
        if (distanceToPlayer > maxDistance)
        {
            Vector3 directionToPlayer = (mousePosition - player.position).normalized;
            mousePosition = player.position + directionToPlayer * maxDistance;
        }

    
  
           // Déplace l'empty object vers la position de la souris
           transform.position = Vector3.MoveTowards(transform.position, mousePosition, moveSpeed* Time.deltaTime);
  

    }
}
