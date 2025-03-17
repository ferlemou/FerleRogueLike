using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckCards : MonoBehaviour, IGun
{
    [SerializeField, Tooltip("Dano do disparo")]
    private float damage;
    public float Damage => damage;

    [SerializeField, Tooltip("Dano do disparo")]
    private float projSpeed;
    public float ProjSpeed => projSpeed;
    
    [SerializeField]
    private GameObject projectilePrefab;
    public GameObject ProjectilePrefab => projectilePrefab;
}
