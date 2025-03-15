using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float health;
    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private float cooldownDamage;
    private float canDamage;

    private Color colorNormal = Color.white;
    private Color colorDamage = Color.red;

    private SpriteRenderer spriteRenderer;
    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Damage(float damage){
        if (Time.time > canDamage){
            StartCoroutine(ColorDamage());
            health = health - damage;
            canDamage = Time.time + cooldownDamage;
        }
    }
    IEnumerator ColorDamage(){
        spriteRenderer.color = colorDamage;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = colorNormal;
    }
}
