using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}
public class Enemy : MonoBehaviour
{
    private float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public EnemyState currentState;
    public FloatValue maxHealth;

    private void Awake()
    {
        health = maxHealth.initialValue;
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }


    public void Knock(Rigidbody2D myRigidBody, float knockTime, float damage)
    {
        StartCoroutine(KnockCoroutine(myRigidBody, knockTime));
        TakeDamage(damage);
    }
    private IEnumerator KnockCoroutine(Rigidbody2D myRigidBody, float knockTime)
    {
        if (myRigidBody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidBody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidBody.velocity = Vector2.zero;
        }
        

    }
}
