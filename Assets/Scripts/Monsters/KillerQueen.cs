using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerQueen : Stand
{
    public override void Move1() //Bomb transumation
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Bomb Transmutation!";
        }
        else
        {
            currentAttackName = standName+" used Bomb Transmutation!";
        }
        typeFactor = 1f;
        currentEffectName = "Killer Queen! (Click sound)";
        if (enemyStand.type == "Grass" || enemyStand.type == "Ice" || enemyStand.type == "Bug")
        {
            currentEffectName = "Killer Queen! (Click sound) And it was very effective!";
            typeFactor = 1.25f;
        }
        else if (enemyStand.type == "Water" || enemyStand.type == "Fire" || enemyStand.type == "Rock")
        {
            currentEffectName = "Killer Queen! (Click sound) It wasn't very effective, though...";
            typeFactor = 0.8f;
        }
        currentAccuracy = 80;
        if (Random.Range(0, 100) < currentAccuracy)
        {
            landed = true;
            index = 0;
            if (enemyStand.damageReductionFactor < 8)
            {
                enemyStand.damageReductionFactor += 1;
            }
        }
        else
        {
            landed = false;
        }
    }

    public override void Move2() //Look at hands
    {
        shouldText = true;
        currentAttackName = standName+" used Look at Hands!";
        currentEffectName = "Yoshikage Kira: (gives Mona Lisa speech). (Killer Queen's attack and evasion rose)";
        currentAccuracy = 80+accuracyFactor;
        if (Random.Range(0, 100) < currentAccuracy)
        {
            landed = true;
            index = 0;
            damageFactor += 2;
            enemyStand.accuracyFactor -= 5;
        }
        else
        {
            landed = false;
        }
    }

    public override void Move3() //Sheer Heart Attack
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Sheer Heart Attack!";
        }
        else
        {
            currentAttackName = standName+" used Sheer Heart Attack!";
        }
        currentEffectName = "Sudden Cardiac Arrest posses no vulnerabilities!";
        currentAccuracy = 100;
        if (Random.Range(0, 100) < currentAccuracy)
        {
            landed = true;
            index = 0;
        }
        else
        {
            landed = false;
        }
    }

    public override void Move4() //Bites the dust
    {
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Bites the Dust!";
        }
        else
        {
            currentAttackName = standName+" used Bites the Dust!";
        }
        typeFactor = 1f;
        currentEffectName = "Another one bites the dust!";
        
        currentAccuracy = 60+accuracyFactor;
        if (Random.Range(0, 100) < currentAccuracy)
        {
            landed = true;
            index = 0;
        }
        else
        {
            landed = false;
        }
    }

    public override void Attack1()
    {
        enemyStand.TakeDamage((8+damageFactor+(level/2))*(2/damageReductionFactor) * typeFactor * Random.Range(0.85f, 1f));
    }

    public override void Attack2()
    {
        
    }

    public override void Attack3()
    {
        enemyStand.TakeDamage((15+damageFactor+(level/2))*(2/damageReductionFactor) * Random.Range(0.85f, 1f));
    }

    public override void Attack4()
    {
        health += 20;
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
        healthBar.value = health/maxHealth;
    }
}
