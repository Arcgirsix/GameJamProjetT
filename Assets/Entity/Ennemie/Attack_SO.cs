using UnityEngine;

[CreateAssetMenu(fileName = "Attack_SO", menuName = "Scriptable Objects/Attack_SO")]
public class Attack_SO : ScriptableObject
{
    public int damage;
    public float lifetime;
    public int size;
    public float speed;
}
