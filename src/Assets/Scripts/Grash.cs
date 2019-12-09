using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grash : Enemy
{
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    private Rigidbody2D myRigidBody;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        target = GameObject.FindWithTag("Player").transform;
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle 
                || currentState == EnemyState.walk
                && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                
                myRigidBody.MovePosition(temp);
                ChangeState(EnemyState.walk);
                anim.SetBool("idle", false);
            }
            
            
        }
        else
        {
            anim.SetBool("idle", true);
        }

    }

    private void changeAnim(Vector2 direction)
    {
        direction = direction.normalized;
        anim.SetFloat("moveX", direction.x);
        anim.SetFloat("moveY", direction.y);
    }
    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
            currentState = newState;
    }
}
