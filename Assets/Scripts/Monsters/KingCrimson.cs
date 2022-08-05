using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingCrimson : Stand
{
    public override void Move1() //Donut
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Donut!";
        }
        else
        {
            currentAttackName = standName+" used Donut!";
        }
        currentEffectName = "Bucciarati, no!";
        
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

    public override void Move2() //Imaginary Phone
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Imaginary Phone!";
        }
        else
        {
            currentAttackName = standName+" used Imaginary Phone!";
        }
        if (isEnemy)
        {
            currentEffectName = "(Doppio noises) You are rather confused. Your accuracy fell!";
        }
        else
        {
            currentEffectName = "(Doppio noises) The opponent is rather confused, and their defense fell!";
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

    public override void Move3() //Time Erasure
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Erase Time!";
        }
        else
        {
            currentAttackName = standName+" used Erase Time!";
        }
        currentEffectName = "The clouds in the sky don't realize the moment... this is King Crimson's ability!";
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

    public override void Move4() //Requiem stand
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Evolve to Requiem!";
        }
        else
        {
            currentAttackName = standName+" used Evolve to Requiem!";
        }
        typeFactor = 1f;
        currentEffectName = "It canonically failed!";
        
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
        enemyStand.TakeDamage((12+damageFactor+(level/2))*(2/damageReductionFactor) * Random.Range(0.85f, 1f));
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
        
    }
}
