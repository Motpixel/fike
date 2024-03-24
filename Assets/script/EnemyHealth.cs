using System;
using System.Collections;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    public Animator animator;

    public PlayerProgress playerProgress;


    

    private void Start()
    {
        playerProgress = FindObjectOfType<PlayerProgress>();
    }

    public bool IsAlive()
    {
        return value > 0;
    }

   
    public void DealDamage(float damage)
    {
        playerProgress.AddExperience(damage);
        value -= damage; 
        
        if (value <= 0)
        {
            EnemyDeath();          
        }
        else
        {
            animator.SetTrigger("Hit");
        } 
        
    }

    private void EnemyDeath()
    {
        animator.SetTrigger("Death");
        StartCoroutine(Despawn());
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }
    private IEnumerator Despawn()
    {
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1 || animator.IsInTransition(0))
            yield return null;

        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
