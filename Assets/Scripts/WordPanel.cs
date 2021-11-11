using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordPanel : MonoBehaviour
{
    [SerializeField] private GameObject letterPrefab;
    private Letter[] letters;
    public void Setup(char[] showenWord)
    {
        Transform child = transform.GetChild(0);
        int count = showenWord.Length;
        letters = new Letter[count -1];
        for (int i = 0; i < count - 1; i++)
        {
            letters[i] = Instantiate(letterPrefab, child).GetComponent<Letter>().Setup(showenWord[i]);
            Debug.Log(showenWord[i]);
        }
    }

    public void OpenLetter(char letter)
    {
        for (int i = 0; i < letters.Length; i++)
        {
            letters[i].Check(letter);
        }
    }
}
