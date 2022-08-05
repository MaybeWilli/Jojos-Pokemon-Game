using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagiciansRed : Stand
{
    public override void Move1() //Red Bind (reduce enemy attack)
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Red Bind!";
        }
        else
        {
            currentAttackName = standName+" used Red Bind!";
        }
        if (isEnemy)
        {
            currentEffectName = "Your attack fell!";
        }
        else
        {
            currentEffectName = "The opponent's attack fell!";
        }
        currentAccuracy = 100;
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

    public override void Move2() //Whack (whacks)
    {
        shouldText = true;
        currentAttackName = standName+" used Whack!";
        currentEffectName = "It was quite hurtful!";
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

    public override void Move3() //Piss attack (reduce enemy defense)
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Piss Attack!";
        }
        else
        {
            currentAttackName = standName+" used Piss Attack!";
        }
        if (isEnemy)
        {
            currentEffectName = "Pisssssss! Your defense fell!";
        }
        else
        {
            currentEffectName = "Pisssssss! The opponent's defense fell!";
        }
        currentAccuracy = 100;
        if (Random.Range(0, 100) < currentAccuracy)
        {
            landed = true;
            index = 0;
            enemyStand.ReduceDefense(2);
        }
        else
        {
            landed = false;
        }
    }

    public override void Move4() //Crossfire Hurricane
    {
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Crossfire Hurricane!";
        }
        else
        {
            currentAttackName = standName+" used Crossfire Hurricane!";
        }
        typeFactor = 1f;
        currentEffectName = "Woosh! Boom! Explosion!";
        if (enemyStand.type == "Grass" || enemyStand.type == "Ice" || enemyStand.type == "Bug")
        {
            currentEffectName = "It was very effective!";
            typeFactor = 1.25f;
        }
        else if (enemyStand.type == "Water" || enemyStand.type == "Fire" || enemyStand.type == "Rock")
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

    }

    public override void Attack2()
    {
        enemyStand.TakeDamage((8+(level/2))*(2/damageReductionFactor) * Random.Range(0.85f, 1f));
    }

    public override void Attack3()
    {

    }

    public override void Attack4()
    {
        enemyStand.TakeDamage((16+(level/2))*(2/damageReductionFactor)*typeFactor * Random.Range(0.85f, 1f));
    }
}
