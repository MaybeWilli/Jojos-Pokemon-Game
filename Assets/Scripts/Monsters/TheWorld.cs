using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheWorld : Stand
{
    int whackNum = 0;
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
        typeFactor = 1f;
        currentEffectName = "Kakyoin, nooo!!";
        
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

    public override void Move2() //Wryy
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Yell!";
        }
        else
        {
            currentAttackName = standName+" used Yell!";
        }
        currentEffectName = "Dio: WRYYYYYYYYYYYYYY! (Translation: his attack rose)";
        
        currentAccuracy = 100;
        if (Random.Range(0, 100) < currentAccuracy)
        {
            landed = true;
            index = 0;
            damageFactor += 3;
        }
        else
        {
            landed = false;
        }
    }

    public override void Move3() //Muda rush
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Muda Muda Muda!";
        }
        else
        {
            currentAttackName = standName+" used Muda Muda Muda!";
        }
        typeFactor = 1f;
        whackNum = Random.Range(0, 4);
        currentEffectName = "Muda muda muda! (Hit "+whackNum.ToString()+" times";
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

    public override void Move4() //Za Warudooooo!
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
        currentEffectName = "You fool! You shall soon know that The World's true power is, indeed, the power to reign over this world! The World! Stop Time!";
        if (enemyStand.type == "Normal" || enemyStand.type == "Ice" || enemyStand.type == "Rock")
        {
            //currentEffectName = "Star Platinum: Za Warudoooo!! (Bizzare time stop noises). And it was very effective!";
            typeFactor = 1.25f;
        }
        else if (enemyStand.type == "Poison" || enemyStand.type == "Psychic" || enemyStand.type == "Flying" || enemyStand.type == "Bug")
        {
            //currentEffectName = "Star Platinum: Za Warudoooo!! (Bizzare time stop noises). It wasn't very effective, though.";
            typeFactor = 0.8f;
        }
        
        currentAccuracy = 30+accuracyFactor;
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

    }

    public override void Attack3()
    {
        enemyStand.TakeDamage((7+damageFactor+(level/2))*(2/damageReductionFactor)*typeFactor * Random.Range(0.85f, 1f) * whackNum);
    }

    public override void Attack4()
    {
        enemyStand.TakeDamage((30+damageFactor+(level/2))*(2/damageReductionFactor)*typeFactor * Random.Range(0.85f, 1f));
    }
}
