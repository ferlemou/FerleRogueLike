using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHomeButtons : MonoBehaviour
{
    public static event Action<string> OnPlayGame;
    public static event Action OnQuit;
    [SerializeField]
    private string nameGame;

    public void PlayGame(){
        OnPlayGame?.Invoke(nameGame);
    }
    public void Quit(){
        OnQuit?.Invoke();
    }
}
