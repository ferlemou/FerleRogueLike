using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbExp : SelfDestructible
{
    [SerializeField]
    private float experience;
    private PlayerLevel playerLevel;
    public void Started(float valueExp){
        experience = valueExp;
    }
    private void Start() {
        StartSelfDestruct(30f);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            playerLevel = other.GetComponent<PlayerLevel>();
            playerLevel.GetExp(experience);
            Destroy(this.gameObject);
        }
    }
}
