using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : BasePanel
{
    private ChancePanel chancePanel;
    private GameButton gameButton;
    private WordPanel wordPanel;
    private TMP_InputField inputField;
    private WarningPanel warningPanel;
    private Drum drum;
    private Slider slider;

    private IGameController gameController;
    private char saveLetter;

    private void Awake()
    {
        gameButton = GetComponentInChildren<GameButton>(true);
        wordPanel = GetComponentInChildren<WordPanel>(true);
        inputField = GetComponentInChildren<TMP_InputField>(true);
        warningPanel = GetComponentInChildren<WarningPanel>(true);
        drum = GetComponentInChildren<Drum>(true);
        slider = GetComponentInChildren<Slider>(true);
        chancePanel = GetComponentInChildren<ChancePanel>(true);
    }

    private void Start()
    {
        inputField.onEndEdit.AddListener(OnInputEnd);
    }

    private void OnDestroy()
    {
        inputField.onEndEdit.RemoveListener(OnInputEnd);
    }

    private void OnInputEnd(string text)
    {
        if(text.Length > 1)
        {
            warningPanel.SetText("Must be only one letter");
            inputField.text = string.Empty;
        }
        else
        {
            saveLetter = text[0];
            gameButton.OnButtonClick = CheckLetter;
        }
    }

    private void CheckLetter()
    {
       if( gameController.CheckInputLetter(saveLetter))
        {
            wordPanel.OpenLetter(saveLetter);
        }
        else
        {
            chancePanel.UpdateChanceText();
            warningPanel.SetText("Wrong letter was input");
        }
        inputField.text = string.Empty;
        CheckForGameEnd();
    }

    private void CheckForGameEnd()
    {
       if(gameController.IsCompleted)
        {
            GameManager.Instance.ChangeGameState(GameState.Win);
        }
       else if(gameController.IsFall)
        {
            GameManager.Instance.ChangeGameState(GameState.Fall);
        }
    }

    public override void Open()
    {
        base.Open();
        gameController = GameManager.Instance.GetGameController();
        SetupGame();
    }

    private void SetupGame()
    {
        chancePanel.UpdateChanceText();
        wordPanel.Setup(gameController.ShowenWord);
    }
}
