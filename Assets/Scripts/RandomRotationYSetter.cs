using UnityEngine;

public class RandomRotationYSetter : MonoBehaviour
{
    [SerializeField] private int[] _angles;

    public void Set(Transform targetTransform)
    {
        var randomIndex = Random.Range(0, _angles.Length);
        targetTransform.SetYRotation(_angles[randomIndex]);
      
    }
}