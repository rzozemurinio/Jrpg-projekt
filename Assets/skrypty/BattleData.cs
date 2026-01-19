using System.Collections.Generic;

public static class BattleData
{
    // wróg aktualnej walki
    public static string currentEnemyID;

    // lista wszystkich pokonanych wrogów
    public static HashSet<string> defeatedEnemies = new HashSet<string>();
}
