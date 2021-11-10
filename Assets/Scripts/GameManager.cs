using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private const string text_path = "word_rus";

    private string[] allWords;

    private GameState gameState;

    private UiController uiController;

    public IGameController gameController { get; private set; }

    public GameState GameState
    {
        get
        {
            return gameState;
        }
        set
        {
            if (gameState == value) return;

            gameState = value;

            switch (gameState)
            {
                case GameState.Menu:
                    OnMenuState();
                    break;
                case GameState.Game:
                    OnGameState();
                    break;
                case GameState.Win:
                    OnWinState();
                    break;
                case GameState.Fall:
                    OnFallState();
                    break;
                default:
                    Debug.LogError("Wrong state");
                    break;
            }
        }
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        var file = Resources.Load<TextAsset>(text_path);
        var text = file.text;

        allWords = text.Split('\n');
        uiController = FindObjectOfType<UiController>();
    }

    private void Start()
    {
        GameState = GameState.Menu;
    }

    private void OnMenuState()
    {
        uiController.OnMenuState();
    }

    private void OnGameState()
    {
        gameController = new GameController();
        gameController.Init(allWords[Random.Range(0, allWords.Length)]);
        uiController.OnGameState();
    }

    private void OnWinState()
    {
        uiController.OnWinState();
    }

    private void OnFallState()
    {
        uiController.OnFallState();
    }

    public void ChangeGameState(GameState state)
    {
        GameState = state;
    }

}
