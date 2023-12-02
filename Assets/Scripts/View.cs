using UnityEngine;

public abstract class View<T> : MonoBehaviour
{
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

   public abstract void ViewData(T data);

}
