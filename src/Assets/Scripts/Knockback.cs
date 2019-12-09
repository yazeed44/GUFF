using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("breakable") && this.gameObject.CompareTag("Player"))
        {
            other.GetComponent<pot>().Smash();
        }

        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();   
            if (hit != null)
            {
                Vector2 diff = hit.transform.position - transform.position;
                diff = diff.normalized * thrust;
                hit.AddForce(diff, ForceMode2D.Impulse);

                if (other.gameObject.CompareTag("Enemy") && other.isTrigger)
                {
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    hit.GetComponent<Enemy>().Knock(hit, knockTime, damage);
                }
                    
                if (other.gameObject.CompareTag("Player"))
                {
                    if (other.GetComponent<PlayerMovement>().currentState != PlayerState.stagger)
                    {
                        hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                        hit.GetComponent<PlayerMovement>().Knock(knockTime, damage);
                    }
                    
                }
                
                
            }
        }

    }

   
}
