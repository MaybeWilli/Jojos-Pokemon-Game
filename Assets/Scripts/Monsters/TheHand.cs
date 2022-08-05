using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheHand : Stand
{
    public override void Move1() //Whack
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Whack!";
        }
        else
        {
            currentAttackName = standName+" used Whack!";
        }
        currentEffectName = "It somehow managed not to erase anything, though.";
        
        currentAccuracy = 80;
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

    public override void Move2() //Erasure
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Erasure!";
        }
        else
        {
            currentAttackName = standName+" used Erasure!";
        }
        currentEffectName = "Truck-kun very jealous.";
        typeFactor = 1f;
        if (enemyStand.type == "Fighting" || enemyStand.type == "Poison")
        {
            currentEffectName = "Truck-kun very jealous of its effectiveness.";
            typeFactor = 1.25f;
        }
        else if (enemyStand.type == "Psychic")
        {
            currentEffectName = "Truck-kun very jealous, though it was not very effective.";
            typeFactor = 0.8f;
        }
        currentAccuracy = 40;
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

    public override void Move3() //Eat Pearl Jam food
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Eat Food!";
        }
        else
        {
            currentAttackName = standName+" used Eat Food!";
        }
        currentEffectName = "Wow, that must be some pretty magical food!";
        currentAccuracy = 80+accuracyFactor;
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

    public override void Move4() //Explosion
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Explosion!";
        }
        else
        {
            currentAttackName = standName+" used Explosion!";
        }
        typeFactor = 1f;
        currentEffectName = "Okuyasu, nooooo!";
        
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

    public override void Attack1()
    {
        enemyStand.TakeDamage((8+damageFactor+(level/2))*(2/damageReductionFactor) * Random.Range(0.85f, 1f));
    }

    public override void Attack2()
    {
        enemyStand.TakeDamage((12+damageFactor+(level/2))*(2/damageReductionFactor) * typeFactor * Random.Range(0.85f, 1f));
    }

    public override void Attack3()
    {
        health += 10;
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    public override void Attack4()
    {
        TakeDamage(maxHealth/2);
        enemyStand.TakeDamage((21+damageFactor+(level/2))*(2/damageReductionFactor) * Random.Range(0.85f, 1f));
    }
}
