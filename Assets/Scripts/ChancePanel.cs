using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChancePanel : MonoBehaviour
{

    public void UpdateChanceText()
    {
        var gameController = GameManager.Instance.GetGameController();
        GetComponent<TextMeshProUGUI>().text = $"Chance: {gameController.ChanceCount}";
    }

}
