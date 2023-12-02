using UnityEngine;

public class CatView : MonoBehaviour
{
    [SerializeField] private Avatar _avatar;
    
    private Cat _data;
    
    void ViewCat(Cat data)
    {
        _data = data;
        _avatar = data.avatar;
    }
}
