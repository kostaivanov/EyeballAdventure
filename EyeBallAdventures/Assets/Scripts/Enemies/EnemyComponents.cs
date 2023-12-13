using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal abstract class EnemyComponents : MonoBehaviour
{
    internal Rigidbody2D enemyRigidBody;
    internal Collider2D enemyCollider;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        enemyCollider = GetComponent<Collider2D>();
    }
}
