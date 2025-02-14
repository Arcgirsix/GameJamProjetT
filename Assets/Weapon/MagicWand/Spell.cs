using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Spell : MonoBehaviour
{
    [SerializeField] private GameObject magicProjectilePrefab;
    public Quaternion projRotation;
    
    private void OnEnable()
    {
        Instantiate(magicProjectilePrefab, transform.position, transform.rotation);
    }
}
