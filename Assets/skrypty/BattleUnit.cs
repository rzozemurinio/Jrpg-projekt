using UnityEngine;

public class BattleUnit : MonoBehaviour
{
    public string unitName;
    public bool isPlayer;

    public int maxHP = 3;
    public int currentHP;

    void Awake()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;
        if (currentHP <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}