using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverChariot : Stand
{
    public override void Move1() //Slash (normal damage)
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Slash!";
        }
        else
        {
            currentAttackName = standName+" used Slash!";
        }
        currentEffectName = "It was very painful!";
        
        
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

    public override void Move2() //Take off armour (increase evasion)
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" took off its armour!";
            currentEffectName = trainerName+" "+standName+"'s evasion rose!";
        }
        else
        {
            currentAttackName = standName+" took off its armour!";
            currentEffectName = trainerName+" "+standName+"'s evasion rose!";
        }
        
        currentAccuracy = 100;
        if (Random.Range(0, 100) < currentAccuracy)
        {
            landed = true;
            index = 0;
            enemyStand.accuracyFactor -= 5;
        }
        else
        {
            landed = false;
        }
    }

    public override void Move3() //Stabbity stab (fighting damage)
    {
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Stabbity Stab!";
        }
        else
        {
            currentAttackName = standName+" used Stabbity Stab!";
        }
        typeFactor = 1f;
        currentEffectName = "(Polneroff noises)";
        if (enemyStand.type == "Normal" || enemyStand.type == "Ice" || enemyStand.type == "Rock")
        {
            currentEffectName = "It was very effective!";
            typeFactor = 1.25f;
        }
        else if (enemyStand.type == "Poison" || enemyStand.type == "Flying" || enemyStand.type == "Psychic" || enemyStand.type == "Bug")
        {
            currentEffectName = "It was not very effective...";
            typeFactor = 0.8f;
        }
        
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

    public override void Move4() //Sword gun (Low accuracy)
    {
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Sword Gun!";
        }
        else
        {
            currentAttackName = standName+" used Sword Gun!";
        }
        typeFactor = 1f;
        currentEffectName = "Pew!";
        if (enemyStand.type == "Normal" || enemyStand.type == "Ice" || enemyStand.type == "Rock")
        {
            currentEffectName = "It was very effective!";
            typeFactor = 1.25f;
        }
        else if (enemyStand.type == "Poison" || enemyStand.type == "Flying" || enemyStand.type == "Psychic" || enemyStand.type == "Bug")
        {
            currentEffectName = "It was not very effective...";
            typeFactor = 0.8f;
        }
        
        currentAccuracy = 50+accuracyFactor;
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
        enemyStand.TakeDamage((8+(level/2))*(2/damageReductionFactor) * Random.Range(0.85f, 1f));
    }

    public override void Attack2()
    {

    }

    public override void Attack3()
    {
        enemyStand.TakeDamage((16+(level/2))*(2/damageReductionFactor)*typeFactor * Random.Range(0.85f, 1f));
    }

    public override void Attack4()
    {
        enemyStand.TakeDamage((21+(level/2))*(2/damageReductionFactor)*typeFactor * Random.Range(0.85f, 1f));
    }
}
