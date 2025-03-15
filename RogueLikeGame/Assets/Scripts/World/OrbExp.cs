using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbExp : MonoBehaviour
{
    [SerializeField]
    private float experience;
    private PlayerLevel playerLevel;
    public void Started(float valueExp){
        experience = valueExp;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            playerLevel = other.GetComponent<PlayerLevel>();
            playerLevel.GetExp(experience);
            Destroy(this.gameObject);
        }
    }
}
