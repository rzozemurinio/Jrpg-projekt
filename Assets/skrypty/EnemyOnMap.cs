using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyOnMap : MonoBehaviour
{
    public string enemyID;
    public string battleSceneName = "BattleScene";

    private bool isDefeated = false;
    private Collider2D col;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    private void Start()
    {
        // jeœli wróg ju¿ by³ pokonany — usuñ go NATYCHMIAST
        if (BattleData.defeatedEnemies.Contains(enemyID))
        {
            isDefeated = true;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDefeated)
            return;

        if (!other.CompareTag("Player"))
            return;

        //  BLOKUJEMY KOLEJNE TRIGGERY
        isDefeated = true;
        col.enabled = false;

        BattleData.currentEnemyID = enemyID;
        SceneManager.LoadScene(battleSceneName);
    }
}
