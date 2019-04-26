﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
	
	// Update is called once per frame

	void Update ()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetMouseButtonDown(0)){
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position,attackRange);
                for (int i = 0; i < enemiesToDamage.Length; i++) {
                   //enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
                }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
	}
    private void OnDrawGizmosSelected()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
