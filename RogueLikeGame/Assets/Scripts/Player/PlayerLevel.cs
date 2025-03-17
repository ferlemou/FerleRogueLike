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

    public static event Action<int> OnLevelUp;
    public static event Action<float> ExpUp;
    private void Start() {
        ExpUp?.Invoke(expTotal);
        OnLevelUp?.Invoke(level);
    }
    public void GetExp(float value){
        expTotal = expTotal + value;
        ExpUp?.Invoke(expTotal);
        if (expTotal >= expToUp){
            expToUp = expToUp + (50f * level);
            level++;
            OnLevelUp?.Invoke(level);
        }
    }
}
