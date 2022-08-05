using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrazyDiamond : Stand
{
    int whackNum = 0;
    public override void Move1() //Hair (whack)
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Feel Offended!";
        }
        else
        {
            currentAttackName = standName+" used Feel Offended!";
        }
        typeFactor = 1f;
        currentEffectName = "Josuke hates people insulting his hair more than anything else! "+trainerName+" "+standName+"'s attack rose!";
        
        currentAccuracy = 80+accuracyFactor;
        if (Random.Range(0, 100) < currentAccuracy)
        {
            landed = true;
            index = 0;
            damageFactor++;
        }
        else
        {
            landed = false;
        }
    }

    public override void Move2() //Whack
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
        currentEffectName = "Probably shouldn't have insulted his hair...";
        
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

    public override void Move3() //Dora rush
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Dora rush!";
        }
        else
        {
            currentAttackName = standName+" used Dora rush!";
        }
        typeFactor = 1f;
        whackNum = Random.Range(0, 4);
        currentEffectName = "Dorarararararara! (Hit "+whackNum.ToString()+" times";
        if (enemyStand.type == "Fighting" || enemyStand.type == "Dragon" || enemyStand.type == "Dark")
        {
            currentEffectName = "Dorarararararara! (Hit "+whackNum.ToString()+" times! And it was very effective!";
            typeFactor = 1.25f;
        }
        else if (enemyStand.type == "Fire" || enemyStand.type == "Poison" || enemyStand.type == "Steel")
        {
            currentEffectName = "Dorarararararara! (Hit "+whackNum.ToString()+" times! It wasn't very effective, though.";
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

    public override void Move4() //Glass Bullet
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Glass Bullet!";
        }
        else
        {
            currentAttackName = standName+" used Glass Bullet!";
        }
        typeFactor = 1f;
        currentEffectName = "(Painful glass noises)";
        if (enemyStand.type == "Fighting" || enemyStand.type == "Dragon" || enemyStand.type == "Dark")
        {
            currentEffectName = "(Very effective painful glass noises)";
            typeFactor = 1.25f;
        }
        else if (enemyStand.type == "Fire" || enemyStand.type == "Poison" || enemyStand.type == "Steel")
        {
            currentEffectName = "(Not very effective painful glass noises)";
            typeFactor = 0.8f;
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

    public override void Attack1()
    {
        
    }

    public override void Attack2()
    {
        enemyStand.TakeDamage((8+damageFactor+(level/2))*(2/damageReductionFactor) * Random.Range(0.85f, 1f));
    }

    public override void Attack3()
    {
        enemyStand.TakeDamage((7+damageFactor+(level/2))*(2/damageReductionFactor)*typeFactor * Random.Range(0.85f, 1f) * whackNum);
    }

    public override void Attack4()
    {
        enemyStand.TakeDamage((12+damageFactor+(level/2))*(2/damageReductionFactor)*typeFactor * Random.Range(0.85f, 1f));
    }
}
