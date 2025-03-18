using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Prefab Inimigos para spawnar")]
    [SerializeField]
    private GameObject RedMonster;

    bool Spawning;
    [SerializeField, Tooltip("intervalo entre spawn's")]
    private float SpawnRate;
    [SerializeField, Tooltip("distancia do player")]

    private int Levelplayer;
    [SerializeField, Tooltip("")]
    private int limitX, limitY;
    private int directionSpawn, ValueRandom;
    private float enemyLife;
    private float enemyExp;

    private Transform center;
    private Vector3 SpawnPosition;
    private void OnEnable() {
        PlayerHealth.OnPlayerDeath += PlayerDeath;
    }
    private void OnDisable() {
        PlayerHealth.OnPlayerDeath -= PlayerDeath;
    }
    private void PlayerDeath(){
        Spawning = false;
    }
    void Start()
    {
        Spawning = true; //true
        GameObject camera = GameObject.FindWithTag("MainCamera");
        if (camera != null)
        {
            center = camera.transform;
        }
        StartCoroutine(SpawnEnimies());
    }
    IEnumerator SpawnEnimies()
    {
        while (Spawning == true)
        {
            directionSpawn = UnityEngine.Random.Range (0, 4);
            SpawnPosition = new Vector3 (0,0,0);
            switch (directionSpawn){
                case 0: 
                //NORTE
                ValueRandom = UnityEngine.Random.Range (-limitX, limitX);
                SpawnPosition = new Vector3 (center.position.x + ValueRandom, center.position.y + limitY, 0);
                break;
                case 1:
                //SUL 
                ValueRandom = UnityEngine.Random.Range (-limitX, limitX);
                SpawnPosition = new Vector3 (center.position.x + ValueRandom, center.position.y -limitY, 0);
                break;
                case 2:
                //LESTE
                ValueRandom = UnityEngine.Random.Range (-limitY, limitY);
                SpawnPosition = new Vector3 (center.position.x + limitX, center.position.y + ValueRandom, 0);
                break;
                case 3:
                //OESTE
                ValueRandom = UnityEngine.Random.Range (-limitY, limitY);
                SpawnPosition = new Vector3 (center.position.x - limitX, center.position.y + ValueRandom, 0);
                break;
                default:
                Debug.Log("Não escolheu posição. directionSpawn= "+ directionSpawn );
                break;
            }
            GameObject EnemyInstan = Instantiate (RedMonster, SpawnPosition, Quaternion.identity);
            EnemyHealth enemyHealth = EnemyInstan.GetComponent<EnemyHealth>();
            if (enemyHealth != null) {
                enemyLife = 10f;
                enemyExp = 15f;
                enemyHealth.Started(enemyLife, enemyExp);
            }

            yield return new WaitForSeconds(SpawnRate);
        }
    }
}
