using UnityEngine;

public class EnnemieAttack : MonoBehaviour
{
    public bool canAttackB;
    [SerializeField] private GameObject attackPrefab;
    public Transform player;
    [SerializeField] private float delay;
    [SerializeField] private float timer = 2f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if (delay < timer)
        {
            delay += Time.fixedDeltaTime;
            return;
        }
        if (canAttackB)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Instantiate(attackPrefab, (transform.position + new Vector3(1f,0f,0f)), Quaternion.Euler(new Vector3(0, 0, angle)));
        }
        delay = 0f;
    }
}
