using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField]
    private float attackDamage;
    private PlayerHealth playerHealth;
    private void Start() {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null){
            playerHealth = player.GetComponent<PlayerHealth>();
        }
    }
    private void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")){
            playerHealth.Damage(attackDamage);
        }
    }
}
