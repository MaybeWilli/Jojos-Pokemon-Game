using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPlatinum : Stand
{
    int whackNum = 0;
    public override void Move1() //Whack (whack)
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
        typeFactor = 1f;
        currentEffectName = "Ouch! How rude!";
        
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

    public override void Move2() //Star Finger
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Star Finger!";
        }
        else
        {
            currentAttackName = standName+" used Star Finger!";
        }
        if (isEnemy)
        {
            currentEffectName = "Your attack and accuracy fell, OwO!";
        }
        else
        {
            currentEffectName = "The opponent's attack and accuracy fell, UwU!";
        }
        
        currentAccuracy = 100;
        if (Random.Range(0, 100) < currentAccuracy)
        {
            landed = true;
            index = 0;
            enemyStand.accuracyFactor -= 5;
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

    public override void Move3() //Ora rush
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Ora Ora Ora!";
        }
        else
        {
            currentAttackName = standName+" used Ora Ora Ora!";
        }
        typeFactor = 1f;
        whackNum = Random.Range(0, 4);
        currentEffectName = "Ora Ora Ora! (Hit "+whackNum.ToString()+" times";
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

    public override void Move4() //Star Platinum: Za Warudooooo!
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Time Stop!";
        }
        else
        {
            currentAttackName = standName+" used Time Stop!";
        }
        typeFactor = 1f;
        currentEffectName = "Star Platinum: Za Warudoooo!! (Bizzare time stop noises)";
        if (enemyStand.type == "Normal" || enemyStand.type == "Ice" || enemyStand.type == "Rock")
        {
            currentEffectName = "Star Platinum: Za Warudoooo!! (Bizzare time stop noises). And it was very effective!";
            typeFactor = 1.25f;
        }
        else if (enemyStand.type == "Poison" || enemyStand.type == "Psychic" || enemyStand.type == "Flying" || enemyStand.type == "Bug")
        {
            currentEffectName = "Star Platinum: Za Warudoooo!! (Bizzare time stop noises). It wasn't very effective, though.";
            typeFactor = 0.8f;
        }
        
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
        enemyStand.TakeDamage((8+(level/2))*(2/damageReductionFactor) * Random.Range(0.85f, 1f));
    }

    public override void Attack2()
    {

    }

    public override void Attack3()
    {
        enemyStand.TakeDamage((7+(level/2))*(2/damageReductionFactor)*typeFactor * Random.Range(0.85f, 1f) * whackNum);
    }

    public override void Attack4()
    {
        enemyStand.TakeDamage((21+(level/2))*(2/damageReductionFactor)*typeFactor * Random.Range(0.85f, 1f));
    }
}
