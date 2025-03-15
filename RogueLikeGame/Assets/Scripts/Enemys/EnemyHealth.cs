using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float health;
    [SerializeField]
    private float experience;
    [SerializeField]
    private GameObject orbXpPrefab;

    public static event Action MonsterDeath;
    public void Started(float spawnLife, float exp){
        health = spawnLife;
        experience = exp;
    }
    public void Damage(float damage){
        health = health - damage;
        if (health <= 0){
            Die();
        }
    }
    private void Die(){
        GameObject orbXpInstant = Instantiate(orbXpPrefab, transform.position, Quaternion.identity);
        OrbExp orbExp= orbXpInstant.GetComponent<OrbExp>();
        if (orbExp != null){
            orbExp.Started(experience);
        }
        MonsterDeath?.Invoke();
        Destroy(this.gameObject);
    }
}
