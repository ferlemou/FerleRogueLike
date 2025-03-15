using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : MonoBehaviour
{
    [SerializeField]
    private float damage;
    private EnemyHealth enemyHealth;
    public void Started(float damageGun){
        damage = damageGun;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        switch (other.tag) {
            case "Enemy":
                enemyHealth = other.GetComponent<EnemyHealth>();
                if (enemyHealth != null){
                    enemyHealth.Damage(damage);
                }
                Destroy(this.gameObject);
            break;
        }
    }
}
