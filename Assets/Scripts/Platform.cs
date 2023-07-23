using UnityEngine;

public class Platform : MonoBehaviour
{
    public void Move(Vector2 moveDelta)
    {
       transform.Translate(moveDelta);
    }
}