using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HierophantGreen : Stand
{
    public override void Move1() //Emerald Splash (low accuracy)
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Emerald Splash!";
        }
        else
        {
            currentAttackName = standName+" used Emerald Splash!";
        }
        typeFactor = 1f;
        currentEffectName = "It actually hit! What a surprise!";
        if (enemyStand.type == "Fire" || enemyStand.type == "Fire" || enemyStand.type == "Rock")
        {
            currentEffectName = "It was very effective!";
            typeFactor = 1.25f;
        }
        else if (enemyStand.type == "Water" || enemyStand.type == "Grass" || enemyStand.type == "Dragon")
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

    public override void Move2() //Movement net (increase evasion)
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Movement Net!";
            currentEffectName = trainerName+" "+standName+"'s evasion rose!";
        }
        else
        {
            currentAttackName = standName+" used Movement Net!";
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

    public override void Move3() //Marionnet (physical damage)
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Marionnet!";
        }
        else
        {
            currentAttackName = standName+" used Marionnet!";
        }
        typeFactor = 1f;
        currentEffectName = "It was quite rude!";
        
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

    public override void Move4() //20 meter radius emerald splash (high water damage)
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used 20 Meter Radius Emerald Splash!";
        }
        else
        {
            currentAttackName = standName+" used Emerald Splash!";
        }
        typeFactor = 1f;
        currentEffectName = "Hierophant's barrier, which activates when touched, completely surrounds you for 20 meters in every direction!";
        if (enemyStand.type == "Fire" || enemyStand.type == "Fire" || enemyStand.type == "Rock")
        {
            currentEffectName = "It was very effective!";
            typeFactor = 1.25f;
        }
        else if (enemyStand.type == "Water" || enemyStand.type == "Grass" || enemyStand.type == "Dragon")
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

    public override void Attack1()
    {
        enemyStand.TakeDamage((8+(level/2))*(2/damageReductionFactor)*typeFactor * Random.Range(0.85f, 1f));
    }

    public override void Attack2()
    {

    }

    public override void Attack3()
    {
        enemyStand.TakeDamage((12+(level/2))*(2/damageReductionFactor)*typeFactor * Random.Range(0.85f, 1f));
    }

    public override void Attack4()
    {
        enemyStand.TakeDamage((16+(level/2))*(2/damageReductionFactor)*typeFactor * Random.Range(0.85f, 1f));
    }
}
