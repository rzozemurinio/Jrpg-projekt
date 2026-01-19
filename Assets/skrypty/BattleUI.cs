using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    public BattleManager battleManager;

    public Button attackButton;
    public Button nextTurnButton;
    public TextMeshProUGUI battleLogText;

    private GameObject currentPlayer;

    void Start()
    {
        ShowAttackButton(false);
        ShowNextTurnButton(false);
    }

    // ======================
    // BUTTONS
    // ======================
    public void OnAttackButton()
    {
        battleManager.PlayerAttack();
    }

    public void OnNextTurnButton()
    {
        battleManager.OnNextTurnButton();
    }

    // ======================
    // UI CONTROL
    // ======================
    public void ShowAttackButton(bool show)
    {
        attackButton.gameObject.SetActive(show);
    }

    public void ShowNextTurnButton(bool show)
    {
        nextTurnButton.gameObject.SetActive(show);
    }

    public void SetCurrentPlayer(GameObject player)
    {
        currentPlayer = player;
    }

    // ======================
    // LOG
    // ======================
    public void LogAttack(string attacker, string target, int damage, bool killed)
    {
        string msg = attacker + " atakuje " + target +
                     ", zadaj¹c " + damage + " obra¿eñ";

        if (killed)
            msg += ", zabijaj¹c go";

        battleLogText.text = msg;
    }

    public void LogMessage(string message)
    {
        battleLogText.text = message;
    }
}