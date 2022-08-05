using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldExperience : Stand
{
    public override void Move1() //Painful Punch
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Painful Punch!";
        }
        else
        {
            currentAttackName = standName+" used Painful Punch!";
        }
        typeFactor = 1f;
        if (isEnemy)
        {
            currentEffectName = "Ouch! You experience great pain, comparable to watching Morbius 3 times in a row!";
        }
        else
        {
            currentEffectName = "Ouch! Your opponent feels great pain, comparable to reading the entirety of Kanojo, Okarishimasu 3 times in one sitting!";
        }
        
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

    public override void Move2() //Razor Wind
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Razor Wind!";
        }
        else
        {
            currentAttackName = standName+" used Razor Wind!";
        }
        typeFactor = 1f;
        //whackNum = Random.Range(0, 4);
        currentEffectName = "Gold Experience! Muda muda muda!!";
        if (enemyStand.type == "Water" || enemyStand.type == "Ground" || enemyStand.type == "Rock")
        {
            currentEffectName = "It was very effective!";
            typeFactor = 1.25f;
        }
        else if (enemyStand.type == "Fire" || enemyStand.type == "Grass" || enemyStand.type == "Poison" || enemyStand.type == "Flying" || enemyStand.type == "Bug" || enemyStand.type == "Dragon")
        {
            currentEffectName = "It was not very effective...";
            typeFactor = 0.8f;
        }
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

    public override void Move3() //Spare Parts
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Spare Parts!";
        }
        else
        {
            currentAttackName = standName+" used Spare Parts!";
        }
        typeFactor = 1f;
        //whackNum = Random.Range(0, 4);
        currentEffectName = "Unlimited limb works: Infinite creation of body parts!!";
        
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

    public override void Move4() //Revert to zero
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" tries to use Revert to Zero!";
        }
        else
        {
            currentAttackName = standName+" tries to use Revert to Zero!";
        }
        typeFactor = 1f;
        currentEffectName = "It's succesfully evolved to "+standName+" Requiem! Kore ga requiem da!";
        
        currentAccuracy = 30;
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
        enemyStand.TakeDamage((7+damageFactor+(level/2))*(2/damageReductionFactor)*typeFactor * Random.Range(0.85f, 1f));
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
        enemyStand.TakeDamage((100+damageFactor+(level/2))*(2/damageReductionFactor)*typeFactor * Random.Range(0.85f, 1f));
    }
}
