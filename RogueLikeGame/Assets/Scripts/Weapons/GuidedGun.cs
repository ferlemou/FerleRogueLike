using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedGun : MonoBehaviour, IGun
{

    [Header("Atributos da Arma")]
    [SerializeField, Tooltip("intervalo entre disparos")]
    private float cooldownAttack;
    private float canAttack;
    [SerializeField, Tooltip("raio para detectar inimigo")]
    private float attackRadius;
    private float anguloDeg, anguloRad;
    
    [Header("Atributos do disparo")]
    [SerializeField, Tooltip("Dano do disparo")]
    private float damage;
    public float Damage => damage;
    [SerializeField, Tooltip("Dano do disparo")]
    private float projSpeed;
    public float ProjSpeed => projSpeed;

    [Header("Dependências")]
    [SerializeField]
    private GameObject projectilePrefab;
    public GameObject ProjectilePrefab => projectilePrefab;

    [SerializeField]
    private GameObject hand;
    public GameObject player;
    public LayerMask enemyLayer;
    private Vector3 enemyPosition;
    private Quaternion shotRotation;
    
    
    private void Start(){
        hand = GameObject.Find("Player/Hand");
        StartCoroutine(TrackEnemy());
    }
    IEnumerator TrackEnemy(){
        while(1 == 1){
            Collider2D collider = Physics2D.OverlapCircle(player.transform.position, attackRadius, enemyLayer);

            if(collider != null){
                enemyPosition = collider.transform.position;
                Attack();
                RotationGun();
            }
            yield return new WaitForSeconds(cooldownAttack);
        }
    }
    private void Attack(){
        if (Time.time > canAttack){
            enemyPosition = (enemyPosition - (Vector3)transform.position).normalized;
            anguloRad = Mathf.Atan2(enemyPosition.y, enemyPosition.x);
            anguloDeg = Mathf.Rad2Deg * anguloRad;
            shotRotation = Quaternion.Euler(0f, 0f, anguloDeg);
            GameObject projInstantiated = Instantiate(projectilePrefab, transform.position, shotRotation);
            ProjectileAttack projAttack = projInstantiated.GetComponent<ProjectileAttack>();
            ProjectileMove projectileMove = projInstantiated.GetComponent<ProjectileMove>();
            if (projAttack != null && projectileMove != null){
                projAttack.Started(damage);
                projectileMove.Started(projSpeed);
            }
            canAttack = Time.time + cooldownAttack;
        }
    }
    private void RotationGun(){
        float angle = Mathf.Atan2(enemyPosition.y, enemyPosition.x) * Mathf.Rad2Deg;
        hand.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(player.transform.position, attackRadius);
    }
}
