using UnityEngine;

[CreateAssetMenu (fileName = "PlayerAttackConfig", menuName = "ScriptableObjects/PlayerAttackConfig")]
public class PlayerAttackConfig : ScriptableObject
{

    public float Range;
    public float Speed;
    public int Damage;


    public float BulletSpeed;
}
