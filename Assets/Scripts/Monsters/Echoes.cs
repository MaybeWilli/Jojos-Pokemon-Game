using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echoes : Stand
{
    public override void Move1() //Annoying noise
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Annoying Noise!";
        }
        else
        {
            currentAttackName = standName+" used Annoying Noise!";
        }
        typeFactor = 1f;
        if (isEnemy)
        {
            currentEffectName = "Nya nya nya nya nya! (Translation: your attack fell)";
        }
        else
        {
            currentEffectName = "Nya nya nya nya nya! (Translation: the opponent's attack fell)";
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

    public override void Move2() //Super annoying noise
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Super Annoying Noise!";
        }
        else
        {
            currentAttackName = standName+" used Super Annoying Noise!";
        }
        if (isEnemy)
        {
            currentEffectName = "Do u know da wae? x 15 (Translation: Your defense fell";
        }
        else
        {
            currentEffectName = "Do u know da wae? x 15 (Translation: The opponent's defense fell";
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

    public override void Move3() //Three Freeze
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Three Freeze!";
        }
        else
        {
            currentAttackName = standName+" used Three Freeze!";
        }
        typeFactor = 1f;
        //whackNum = Random.Range(0, 4);
        currentEffectName = "Echoes act three: three freeze!";
        if (enemyStand.type == "Fighting" || enemyStand.type == "Poison")
        {
            currentEffectName = "Ok master, lets kill da hoe! Beeeeeetch! (It was very effective)";
            typeFactor = 1.25f;
        }
        else if (enemyStand.type == "Psychic")
        {
            currentEffectName = "S-H-I-T (it was not very effective)";
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

    public override void Move4() //Cry for Jotaro
    {
        shouldText = true;
        if (trainerName != null)
        {
            currentAttackName = trainerName+" "+standName+" used Call for Jotaro!";
        }
        else
        {
            currentAttackName = standName+" used Call for Jotaro!";
        }
        typeFactor = 1f;
        currentEffectName = "Jotaro: Koichi, you truly are a reliable guy.";
        if (enemyStand.type == "Fighting" || enemyStand.type == "Poison")
        {
            currentEffectName = "Jotaro: Koichi, you've gained a PS2 Stand! So reliable, UwU! (It was very effective)";
            typeFactor = 1.25f;
        }
        else if (enemyStand.type == "Psychic")
        {
            currentEffectName = "Jotaro: Bruh. (It was not very effective";
            typeFactor = 0.8f;
        }
        
        currentAccuracy = 100; //because its RELIABLE!
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
        enemyStand.TakeDamage((5+damageFactor+(level/2))*(2/damageReductionFactor) * Random.Range(0.85f, 1f));
        enemyStand.ReduceDefense(2);
    }

    public override void Attack3()
    {
        enemyStand.TakeDamage((10+damageFactor+(level/2))*(2/damageReductionFactor)*typeFactor * Random.Range(0.85f, 1f));
    }

    public override void Attack4()
    {
        enemyStand.TakeDamage((15+damageFactor+(level/2))*(2/damageReductionFactor)*typeFactor * Random.Range(0.85f, 1f));
    }
}
