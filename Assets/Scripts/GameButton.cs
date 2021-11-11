using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameButton : MonoBehaviour
{
    public Action OnButtonClick;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }


    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(OnClick);
    }

    private void OnClick()
    {
        OnButtonClick();
    }
}
