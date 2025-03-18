using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    bool spawning;
    [SerializeField, Tooltip("intervalo entre spawn's")]
    private float cooldown;
    private Transform center;
    [SerializeField, Tooltip("")]
    private int limitX, limitY;
    private int enemyIndex, enemyMaxIndex;
    public List<Enemys> enemys = new List<Enemys>();
    [System.Serializable]
    public class Enemys{
        public GameObject enemyPrefab;
        public int enemyLevel;
        public float enemyLife;
        public float enemyExp;
    }

    private void OnEnable() {
        PlayerHealth.OnPlayerDeath += PlayerDeath;
        PlayerLevel.OnLevelUp += LevelUp;
    }
    private void OnDisable() {
        PlayerHealth.OnPlayerDeath -= PlayerDeath;
        PlayerLevel.OnLevelUp -= LevelUp;
    }
    private void PlayerDeath(){
        spawning = false;
    }
    private void LevelUp(int pLevel){
        Enemys enemyFound = enemys.Find(e => e.enemyLevel == pLevel);
        if (enemyFound != null){
            enemyMaxIndex++;
        }
    }
    private void Start() {
        spawning = true; //true
        cooldown = 1;
        GameObject camera = GameObject.FindWithTag("MainCamera");
        if (camera != null)
        {
            center = camera.transform;
        }
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy(){
        while (spawning){
            enemyIndex = Random.Range(0, enemyMaxIndex + 1);
            Enemys enemySelect = enemys[enemyIndex];
            Vector3 SpawnPosition = GetPosition();
            GameObject EnemyInstan = Instantiate (enemySelect.enemyPrefab, SpawnPosition, Quaternion.identity);
            EnemyHealth enemyHealth = EnemyInstan.GetComponent<EnemyHealth>();
            if (enemyHealth != null){
                enemyHealth.Started(enemySelect.enemyLife, enemySelect.enemyExp);
            }
            yield return new WaitForSeconds(cooldown);
        }
    }
    public Vector3 GetPosition(){
        int directionSpawn, ValueRandom;
        directionSpawn = UnityEngine.Random.Range (0, 4);
        Vector3 rPosition = new Vector3 (0,0,0);
        switch (directionSpawn){
            case 0: 
            //NORTE
                ValueRandom = UnityEngine.Random.Range (-limitX, limitX);
                rPosition = new Vector3 (center.position.x + ValueRandom, center.position.y + limitY, 0);
                break;
            case 1:
            //SUL 
                ValueRandom = UnityEngine.Random.Range (-limitX, limitX);                
                rPosition = new Vector3 (center.position.x + ValueRandom, center.position.y -limitY, 0);
                break;
            case 2:
            //LESTE
                ValueRandom = UnityEngine.Random.Range (-limitY, limitY);
                rPosition = new Vector3 (center.position.x + limitX, center.position.y + ValueRandom, 0);
                break;
            case 3:
            //OESTE
                ValueRandom = UnityEngine.Random.Range (-limitY, limitY);
                rPosition = new Vector3 (center.position.x - limitX, center.position.y + ValueRandom, 0);
                break;
            default:
                Debug.Log("Não escolheu posição. directionSpawn= "+ directionSpawn );
                break;
        }
        return rPosition;
    }
}
