using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static void SetPositionZ(this Transform targetTransform, float newZ)
    {
        targetTransform.position = new Vector3(targetTransform.position.x, targetTransform.position.y, newZ);
    }

    public static float GetMoveTowardsX(this Transform targetTransform, float targetX, float maxDelta)
    {
        return Mathf.MoveTowards(targetTransform.position.x, targetX, maxDelta);
    }

    public static void SetYRotation(this Transform targetTransform, float newY)
    {
        targetTransform.rotation = Quaternion.Euler(0, newY, 0);
    }

   

    public static void Shuffle<T>(this IList<T> list)  
    {  
        int n = list.Count;  
        while (n > 1) {  
            n--;  
            int k = Random.Range(0,list.Count);  
            (list[k], list[n]) = (list[n], list[k]);
        }  
    }
}