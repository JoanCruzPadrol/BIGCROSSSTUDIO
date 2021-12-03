using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCharacter_attack : MonoBehaviour
{
    private Animator anim;

    public float attackTime;

    public float startTimeAttack;

    public Transform attackPos;

    public float attackRange;

    public int damage;


    public LayerMask nearEnemies;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();

        if (Input.GetKey(KeyCode.Space))
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, attackRange, nearEnemies)
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Enemy>().health -= damage;
            }
        }
        else
        {
            attackTime -= Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, attackRange, nearEnemies);
            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
            }
            attackTime = startTimeAttack;
        }
        else
        {
            attackTime -= Time.deltaTime;
        }
    }
}
