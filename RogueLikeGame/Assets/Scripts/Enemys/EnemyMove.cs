using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Vector3 direction;
    private Vector2 moviment;
    private Transform target;
    private Rigidbody2D rig;
    
    private void Start() {
        rig = GetComponent<Rigidbody2D>();
        GameObject playerTarget = GameObject.FindWithTag("Player");
        if(playerTarget != null) {
            target = playerTarget.transform;
        }
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach(GameObject wall in walls) {
            if (wall.GetComponent<BoxCollider2D>() != null) {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), wall.GetComponent<BoxCollider2D>(), true);
            }
        }
    }
    private void FixedUpdate() {
        Follow();
    }
    void Follow() {
        if(target != null) {
            direction = target.position - transform.position;
            direction.Normalize();
            moviment = new Vector2 (direction.x, direction.y) * speed * Time.deltaTime;
            rig.MovePosition(rig.position + moviment);
        }
    }
}
