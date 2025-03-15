using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField]
    private float expTotal;
    [SerializeField]
    private float expToUp;
    [SerializeField]
    private int level;

    public static event Action<int> LevelUp;
    public static event Action<float> ExpUp;
    private void Start() {
        ExpUp?.Invoke(expTotal);
        LevelUp?.Invoke(level);
    }
    public void GetExp(float value){
        expTotal = expTotal + value;
        ExpUp?.Invoke(expTotal);
        if (expTotal >= expToUp){
            expToUp = expToUp + (50f * level);
            level++;
            LevelUp?.Invoke(level);
        }
    }
}
