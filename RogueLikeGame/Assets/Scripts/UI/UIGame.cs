using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGame : MonoBehaviour
{
    [SerializeField]
    private TMP_Text uiHealth, uiDeaths, uiLevel, uiExp;
    private int deaths;
    private void OnEnable() {
        PlayerHealth.OnPlayerDamaged += ShowHealth;
        EnemyHealth.MonsterDeath += ShowDeaths;
        PlayerLevel.OnLevelUp += ShowLevelUp;
        PlayerLevel.ExpUp += ShowExp;
    }
    private void OnDisable() {
        PlayerHealth.OnPlayerDamaged -= ShowHealth;
        EnemyHealth.MonsterDeath -= ShowDeaths;
        PlayerLevel.OnLevelUp -= ShowLevelUp;
        PlayerLevel.ExpUp -= ShowExp;
    }
    private void Start() {
        ShowDeaths();
    }
    private void ShowHealth(float health){
        uiHealth.text = "Health: " + health.ToString();
    }
    private void ShowDeaths(){
        deaths++;
        uiDeaths.text = "Deaths: " + deaths.ToString();
    }
    private void ShowLevelUp(int level){
        uiLevel.text = "Level: " + level.ToString();
    }
    private void ShowExp(float exp){
        uiExp.text = "Exp: " + exp.ToString();
    }
}