using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameController 
{
    void Init(string word);
    bool CheckInputLetter(char letter);
    bool IsCompleted { get; }
    char[] ShowenWord { get; }
}
