using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    private void Awake() {
        if (FindObjectsOfType<SceneControl>().Length > 1){
            Destroy(this.gameObject);
        }
        else{
            DontDestroyOnLoad(this.gameObject);
        }
    }
    private void OnEnable() {
        //Eventos do UIController cena "Game"
        UIGameMenu.PausedGame += Pause; //bool
        UIGameMenu.RestartGame += Restart;
        UIGameMenu.QuitGame += Quit;
        UIGameMenu.OnHome += Home;

        //Eventos do UIController cena "Home"
        UIHomeButtons.OnPlayGame += PlayGame; //string
        UIHomeButtons.OnQuit += Quit;
    }
    private void OnDisable() {
        //Eventos do UIController cena "Game"
        UIGameMenu.PausedGame -= Pause;
        UIGameMenu.RestartGame -= Restart;
        UIGameMenu.QuitGame -= Quit;
        UIGameMenu.OnHome -= Home;

        //Eventos do UIController cena "Home"
        UIHomeButtons.OnPlayGame -= PlayGame;
        UIHomeButtons.OnQuit -= Quit;
    }
    public void PlayGame(string gameName){
        SceneManager.LoadScene(gameName);
    }
    private void Pause(bool pause){
        if (pause){
            Time.timeScale = 0f;
        }
        else{
            Time.timeScale = 1f;
        }
    }
    private void Restart(){
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
    private void Home(){
        SceneManager.LoadScene("Home");
    }
    private void Quit(){
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
