using UnityEngine;

public class AttackInfo : MonoBehaviour
{
    [SerializeField] private Attack_SO attack_SO;
    public int aDamage;
    public float aLifetime;
    public int aSize;
    public float aSpeed;

    private void Awake()
    {
        aDamage = attack_SO.damage;
        aLifetime = attack_SO.lifetime;
        aSize = attack_SO.size;
        aSpeed = attack_SO.speed;
    }
}
