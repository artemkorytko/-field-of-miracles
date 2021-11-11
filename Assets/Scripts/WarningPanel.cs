using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WarningPanel : MonoBehaviour
{
    private TextMeshProUGUI text;
    private int time = 3;
    private Coroutine coroutine;
    private void Awake()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        text.text = string.Empty;
    }

    public void SetText(string text)
    {
        if(coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }

        coroutine = StartCoroutine(TextCor(text));
    }

    private IEnumerator TextCor(string text)
    {
        this.text.text = text;
        yield return new WaitForSeconds(time);
        this.text.text = string.Empty;
    }

}
