using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Enemy/EnemyData")]
[System.Serializable]
public class EnemyData : ScriptableObject 
{
    public float hp;
    public float damageToPlayer;
    public float moveSpeed;
    
    public EnemyData(float hp, float damageToPlayer, float moveSpeed)
    {
        this.hp = hp;
        this.damageToPlayer = damageToPlayer;
        this.moveSpeed = moveSpeed;
    }
}
