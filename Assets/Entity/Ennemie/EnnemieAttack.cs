using UnityEngine;

public class EnnemieAttack : MonoBehaviour
{
    public bool canAttackB;
    [SerializeField] private GameObject attackPrefab;

    private void Update()
    {
        if (canAttackB)
        {
            GameObject go = Instantiate(attackPrefab);
        }
    }
}
