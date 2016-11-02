using UnityEngine;
using System.Collections;
using Assets.Scripts.Model;
using UnityEngine.UI;

public class ConstStatsInfoPanel : MonoBehaviour {
    public Text DodgeChanceText;
    public Text MagicResistText;
    public Text PhysicalResistText;
    public Text TotalHealthText;
    public Text TotalMovementText;

    public void ShowInfo(ConstStats stats)
    {
        DodgeChanceText.text = "Dodge chance: " + stats.DodgeChance.ToString();
        MagicResistText.text = "Magic resist: " + stats.MagicResist.ToString();
        PhysicalResistText.text = "Physical resist: " + stats.PhysicalResist.ToString();
        TotalHealthText.text = "Total health: " + stats.TotalHealth.ToString();
        TotalMovementText.text = "Total movement: " + stats.TotalMovement.ToString();
    }

    public void Reset()
    {
        DodgeChanceText.text = "Dodge chance: ";
        MagicResistText.text = "Magic resist: ";
        PhysicalResistText.text = "Physical resist: ";
        TotalHealthText.text = "Total health: ";
        TotalMovementText.text = "Total movement: ";
    }
}
