using UnityEngine;

public class AnchorMover : MonoBehaviour
{
    [SerializeField] private Conveyer _conveyer;

    public void MoveAnchor(Transform anchor)
    {
        anchor.Translate(_conveyer.moveSpeed * Time.deltaTime, 0, 0, Space.World);
    }
}