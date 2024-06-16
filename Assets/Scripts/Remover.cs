using UnityEngine;

public class Remover : MonoBehaviour
{
    [ContextMenu("Remove")]
    public void Romove()
    {
        PlayerPrefs.DeleteAll();
    }
}
