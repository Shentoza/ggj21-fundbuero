using System.Collections.Generic;
using UnityEngine;

public class UtilClass : MonoBehaviour
{
    public static void Shuffle<T>(IList<T> list)
    {
        T Temp;
        for (int i = 0; i < list.Count; ++i)
        {
            int rnd = Random.Range(0, list.Count);
            Temp = list[rnd];
            list[rnd] = list[i];
            list[i] = Temp;
        }
    }
}
