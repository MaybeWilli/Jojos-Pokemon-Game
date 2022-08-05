using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Stand : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public string type;
    public float damageFactor;
    public int[] levelRequirements;
    public float level;
    public GameObject prefab;
    public Stand enemyStand;
    public float damageReductionFactor = 2;
    public float defense;
    public string[] attackNames;
    public Slider healthBar;
    protected bool shouldText = false;
    public string[] attackWords1;
    public string[] attackWords2;
    public string[] attackWords3;
    public string[] attackWords4;
    protected string[] attackWords;
    [TextArea]
    public string[] attackExplainations;
    public string currentAttackName;
    public string currentEffectName;
    public float currentAccuracy;
    public int index;
    public bool landed;
    public float accuracyFactor = 0;
    public bool isEnemy;
    public string standName;
    public string trainerName;
    [TextArea]
    public string description;
    protected float typeFactor;
    
    public abstract void Move1();
    public abstract void Move2();
    public abstract void Move3();
    public abstract void Move4();

    public abstract void Attack1();
    public abstract void Attack2();
    public abstract void Attack3();
    public abstract void Attack4();

    public void TakeDamage(float damage)
    {
        float trueDamage = damage - defense;
        if (trueDamage > 0)
        {
            health -= trueDamage;
            healthBar.value = health/maxHealth;
        }
        if (health <= 0)
        {
            healthBar.value = 0;
            Debug.Log("I'm dead lmao");
        }
    }

    public void ReduceDefense(float amount)
    {
        defense -= amount;
        if (defense < 0)
        {
            defense = 0;
        }
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
