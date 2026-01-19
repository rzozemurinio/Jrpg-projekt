using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleExit : MonoBehaviour
{
    public string worldMapSceneName = "WorldMap";

    public void ExitBattle()
    {
       
        // zapamiêtujemy pokonanego wroga PRZED zmian¹ sceny
        if (!string.IsNullOrEmpty(BattleData.currentEnemyID))
        {
            BattleData.defeatedEnemies.Add(BattleData.currentEnemyID);
            BattleData.currentEnemyID = null;
        }

        SceneManager.LoadScene(worldMapSceneName);
    }
}
