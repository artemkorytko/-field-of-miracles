using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameController 
{
    void Init(string word);
    bool CheckInputLetter(char letter);
    bool IsCompleted { get; }
    bool IsFall { get; }
    char[] ShowenWord { get; }

    int ChanceCount { get; }
}
