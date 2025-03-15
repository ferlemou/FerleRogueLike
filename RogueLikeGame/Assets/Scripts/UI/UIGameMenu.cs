using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject uiPause, uiDie;
    private bool paused;

    public static event Action<bool> PausedGame;
    public static event Action RestartGame;
    public static event Action QuitGame;
    public static event Action OnHome;

    private void OnEnable() {
        PlayerHealth.OnPlayerDeath += PlayerDie;
    }
    private void OnDisable() {
        PlayerHealth.OnPlayerDeath -= PlayerDie;
    }
    private void Start() {
        uiPause = GameObject.Find("Canvas/UIPause");
        uiDie = GameObject.Find("Canvas/UIDie");
        paused = false;
        uiPause.SetActive(paused);
        uiDie.SetActive(false);
        PausedGame?.Invoke(paused);
    }
    private void PlayerDie(){
        uiDie.SetActive(true);
    }
    public void Pause(){
        paused = !paused;
        uiPause.SetActive(paused);
        PausedGame?.Invoke(paused);
    }
    public void Restart(){
        RestartGame?.Invoke();
    }
    public void Home(){
        OnHome?.Invoke();
    }
    public void Quit(){
        QuitGame?.Invoke();
    }
}
