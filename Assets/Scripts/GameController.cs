using System;
using System.Collections.Generic;

public class GameController : IGameController
{
    private int openLettersCount;
    private char[] wordChars;
    private char[] openChars;
    private List<char> inputLetters;

    public bool IsCompleted => openLettersCount == wordChars.Length;

    public char[] ShowenWord => wordChars;

    public void Init(string word)
    {
        wordChars = word.ToCharArray();
        inputLetters = new List<char>();
        openLettersCount = 0;
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
                openChars[i] = letter;
                isLetterExist = true;
            }
        }

        return isLetterExist ? true : false;
    }
}


