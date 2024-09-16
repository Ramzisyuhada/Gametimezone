using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class WeaponViewModel 
{
    Animator animator;
    EnemyView enemy;
    public void Shoot(RaycastHit hit )
    {

        if (hit.transform.CompareTag("Enemy"))
        {
            EnemyView enemy = hit.transform.GetComponent<EnemyView>();

            enemy.PlaySoundDamage();
           
            animator = enemy.GetComponent<Animator>();
            enemy.enemy.Health -= 20;

            animator.SetTrigger("Hit");
            animator.SetInteger("Die", enemy.enemy.Health);
        }
    }

    
}
