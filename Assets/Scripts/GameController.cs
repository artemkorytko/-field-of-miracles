using System;
using System.Collections.Generic;

public class GameController : IGameController
{
    private int openLettersCount;
    private char[] wordChars;
    private List<char> inputLetters;
    private int changeCount;

    public bool IsCompleted => openLettersCount == wordChars.Length -1;

    public bool IsFall => changeCount == 0;

    public char[] ShowenWord => wordChars;

    public int ChanceCount => changeCount;

    public void Init(string word)
    {
        wordChars = word.ToCharArray();
        inputLetters = new List<char>();
        openLettersCount = 0;
        changeCount = 10;
    }

    public bool CheckInputLetter(char letter)
    {
       if(!Char.IsLetter(letter) || inputLetters.Contains(letter))
        {
            return false;
        }

        inputLetters.Add(letter);
        bool isLetterExist = false;
        for (int i = 0; i < wordChars.Length; i++)
        {
            if(wordChars[i] == letter)
            {
                openLettersCount++;
                isLetterExist = true;
            }
        }
        if(!isLetterExist)
        {
            changeCount--;
        }

        return isLetterExist ? true : false;
    }
}


