using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyFingers : Stand
{
    public override void Move1() //Zippy Punch
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Zipper Punch!";
        }
        else
        {
            currentAttackName = standName+" used Zipper Punch!";
        }
        typeFactor = 1f;
        if (isEnemy)
        {
            currentEffectName = "Your fly is undone!";
        }
        else
        {
            currentEffectName = "Your opponent's fly is undone!";
        }
        if (enemyStand.type == "Grass" || enemyStand.type == "Fighting" || enemyStand.type == "Bug")
        {
            currentEffectName = currentEffectName+" It was very effective!";
            typeFactor = 1.25f;
        }
        else if (enemyStand.type == "Electric" || enemyStand.type == "Rock")
        {
            currentEffectName = currentEffectName+" It was not very effective...";
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

    public override void Move2() //Lick
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Lick!";
        }
        else
        {
            currentAttackName = standName+" used Lick!";
        }
        typeFactor = 1f;
        //whackNum = Random.Range(0, 4);
        currentEffectName = "This is the taste of a liar! Giornio Giovanna!";
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

    public override void Move3() //Attract
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Attract!";
        }
        else
        {
            currentAttackName = standName+" used Attract!";
        }
        typeFactor = 1f;
        //whackNum = Random.Range(0, 4);
        if (isEnemy)
        {
            currentEffectName = "Your accuracy fell!";
        }
        else
        {
            currentEffectName = "Your opponent's accuracy fell!";
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

    public override void Move4() //Sticky Fingr
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" tries to evolve!";
            currentEffectName = "It's succesfully evolved to "+standName+" Requiem! "+trainerName+" "+standName+" uses Sticky Finger! (So sticky OwO)";
        }
        else
        {
            currentAttackName = standName+" tries to evolve!";
            currentEffectName = "It's succesfully evolved to "+standName+" Requiem! "+standName+" uses Sticky Finger! (So sticky UwU)";
        }
        typeFactor = 1f;
        
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
        
    }

    public override void Attack4()
    {
        enemyStand.TakeDamage((100+damageFactor+(level/2))*(2/damageReductionFactor)*typeFactor * Random.Range(0.85f, 1f));
    }
}
