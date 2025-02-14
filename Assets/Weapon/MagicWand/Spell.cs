using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Spell : MonoBehaviour
{
    [SerializeField] private GameObject magicProjectilePrefab;
    [SerializeField] private float timer;
    [SerializeField] private float delay = 0f;
    public Quaternion projRotation;
    
    private void Update()
    {
        if (delay < timer)
        {
            delay += Time.deltaTime;
            return;
        }
        
        Instantiate(magicProjectilePrefab, transform.position, transform.rotation);
        delay = 0f;
    }

    private void OnDisable()
    {
        delay = 2f;
    }
}
