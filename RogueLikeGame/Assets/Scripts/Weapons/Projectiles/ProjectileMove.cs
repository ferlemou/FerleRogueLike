using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : SelfDestructible
{
    [SerializeField]
    private float speed;
    public void Started(float speedGun){
        speed = speedGun;
    }
    private void Start() {
        StartSelfDestruct(15f);
    }
    private void FixedUpdate() {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
