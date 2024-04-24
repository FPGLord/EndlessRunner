using UnityEngine;

public static class Extensions
{
    public static void SetPositionZ(this Transform targetTransform, float newZ)
    {
        targetTransform.position = new Vector3(targetTransform.position.x, targetTransform.position.y, newZ);
    }

    public static float GetMoveTowardsZ(this Transform targetTransform, float targetZ, float maxDelta)
    {
        return Mathf.MoveTowards(targetTransform.position.z, targetZ, maxDelta);
    }
}