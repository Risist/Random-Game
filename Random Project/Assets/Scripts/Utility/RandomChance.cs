using System.Collections;
using UnityEngine;

/*
 * Helper class to randomise and id from given set with different probabilites for evry oportunity 
 * 
 */

[System.Serializable]
public class RandomChance
{
    public float[] chances = null;

    public int GetRandedId()
    {
        float sum = 0;
        foreach (float it in chances)
            sum += it;

        float randed = Random.Range(0, sum);

        float lastSum = 0;
        for (int i = 0; i < chances.Length; ++i)
            if (randed > lastSum && randed < lastSum + chances[i])
            {
                return i;
            }
            else
            {
                lastSum += chances[i];
            }

        return -1;
    }
}

