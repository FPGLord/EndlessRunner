using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
  private Image _image;
    
   private void Start()
    {
        Fill();
    }

    private void Fill()
    {
        
    }

    private IEnumerable FillCoroutine()
    {
        yield return new WaitForSeconds(1);
    }

}
