using UnityEngine;

public class EnemyClickable : MonoBehaviour
{
    private BattleManager battleManager;

    void Start()
    {
        battleManager = FindObjectOfType<BattleManager>();
    }

    void OnMouseDown()
    {
        if (battleManager == null)
            return;

        battleManager.OnEnemySelected(gameObject);
    }
}