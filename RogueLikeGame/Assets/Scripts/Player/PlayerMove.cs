using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField, Tooltip("Velocidade de movimentação")]
    private float speed;
    private Rigidbody2D rig;
    private VariableJoystick variableJoystick;
    private GameObject joystick;

    private void Start() {
        rig = GetComponent<Rigidbody2D>();
        joystick = GameObject.Find("Canvas/Variable Joystick");
        if (joystick != null) {
            variableJoystick = joystick.GetComponent<VariableJoystick>();
        }
    }
    private void FixedUpdate(){
        Moviment();
    }
    private void Moviment(){
        rig.velocity = new Vector2(variableJoystick.Horizontal * speed, variableJoystick.Vertical * speed);
    }
}
