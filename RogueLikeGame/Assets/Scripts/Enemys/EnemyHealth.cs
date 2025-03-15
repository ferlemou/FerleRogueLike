using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float health;

    public void Started(float spawnLife){
        health = spawnLife;
    }
    public void Damage(float damage){
        health = health - damage;
        if (health <= 0){
            Die();
        }
    }
    private void Die(){
        Destroy(this.gameObject);
    }
}
