using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    private MenuPanel menuPanel;
    private GamePanel gamePanel;
    private FallPanel fallPanel;
    private WinPanel winPanel;

    private BasePanel currentPanel;

    private void Awake()
    {
        menuPanel = FindObjectOfType<MenuPanel>(true);
        gamePanel = FindObjectOfType<GamePanel>(true);
        fallPanel = FindObjectOfType<FallPanel>(true);
        winPanel = FindObjectOfType<WinPanel>(true);
        currentPanel = null;
    }

    public void OnMenuState()
    {
        currentPanel?.Close();
        menuPanel.Open();
        currentPanel = menuPanel;
    }

    public void OnGameState()
    {
        currentPanel?.Close();
        gamePanel.Open();
        currentPanel = gamePanel;
    }

    public void OnWinState()
    {
        currentPanel?.Close();
        winPanel.Open();
        currentPanel = winPanel;
    }

    public void OnFallState()
    {
        currentPanel?.Close();
        fallPanel.Open();
        currentPanel = fallPanel;
    }
}
