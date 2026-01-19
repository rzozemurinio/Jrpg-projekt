using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public BattleUI battleUI;

    public List<GameObject> partyMembers;
    public List<GameObject> enemies;

    private Queue<GameObject> turnQueue = new Queue<GameObject>();
    private GameObject currentUnit;

    private bool waitingForNextTurn = false;
    private bool battleEnded = false;
    private bool isSelectingTarget = false;

    void Start()
    {
        StartBattle();
    }

    void StartBattle()
    {
        battleEnded = false;
        waitingForNextTurn = false;
        isSelectingTarget = false;

        turnQueue.Clear();

        List<GameObject> allUnits = new List<GameObject>();
        allUnits.AddRange(partyMembers);
        allUnits.AddRange(enemies);

        // losowa kolejność tur
        for (int i = 0; i < allUnits.Count; i++)
        {
            int r = Random.Range(i, allUnits.Count);
            (allUnits[i], allUnits[r]) = (allUnits[r], allUnits[i]);
        }

        foreach (var u in allUnits)
            turnQueue.Enqueue(u);

        battleUI.ShowAttackButton(false);
        battleUI.ShowNextTurnButton(true);
        battleUI.LogMessage("Walka się zaczęła!");

        waitingForNextTurn = true;
    }

    // ======================
    // NEXT TURN
    // ======================
    public void OnNextTurnButton()
    {
        if (battleEnded)
            return;

        if (!waitingForNextTurn)
            return;

        waitingForNextTurn = false;
        battleUI.ShowNextTurnButton(false);

        NextTurn();
    }

    void NextTurn()
    {
        if (battleEnded)
            return;

        if (turnQueue.Count == 0)
        {
            StartBattle();
            return;
        }

        currentUnit = turnQueue.Dequeue();

        if (currentUnit == null)
        {
            waitingForNextTurn = true;
            battleUI.ShowNextTurnButton(true);
            return;
        }

        if (enemies.Contains(currentUnit))
            EnemyTurn();
        else
            PlayerTurn();
    }

    // ======================
    // PLAYER
    // ======================
    void PlayerTurn()
    {
        isSelectingTarget = false;

        battleUI.SetCurrentPlayer(currentUnit);
        battleUI.ShowAttackButton(true);
        battleUI.LogMessage($"{currentUnit.name} ma turę");
    }

    public void PlayerAttack()
    {
        if (battleEnded)
            return;

        if (enemies.Count == 0)
            return;

        isSelectingTarget = true;
        battleUI.ShowAttackButton(false);
        battleUI.LogMessage("Wybierz przeciwnika do ataku");
    }

    public void OnEnemySelected(GameObject target)
    {
        if (!isSelectingTarget)
            return;

        if (!enemies.Contains(target))
            return;

        isSelectingTarget = false;

        battleUI.LogAttack(
            currentUnit.name,
            target.name,
            1,
            true
        );

        enemies.Remove(target);
        Destroy(target);

        CheckBattleEnd();

        if (!battleEnded)
            EndTurn();
    }

    // ======================
    // ENEMY
    // ======================
    void EnemyTurn()
    {
        if (partyMembers.Count == 0)
            return;

        GameObject target = partyMembers[Random.Range(0, partyMembers.Count)];

        battleUI.LogAttack(
            currentUnit.name,
            target.name,
            1,
            false
        );

        EndTurn();
    }

    // ======================
    // TURN END
    // ======================
    void EndTurn()  
    {
        turnQueue.Enqueue(currentUnit);
        waitingForNextTurn = true;

        battleUI.ShowAttackButton(false);
        battleUI.ShowNextTurnButton(true);
    }

    // ======================
    // END BATTLE
    // ======================
    void CheckBattleEnd()
    {
        if (enemies.Count == 0 && !battleEnded)
        {
            battleEnded = true;

            battleUI.ShowAttackButton(false);
            battleUI.ShowNextTurnButton(false);
            battleUI.LogMessage("Wszyscy przeciwnicy zostali pokonani!");
        }
    }
}