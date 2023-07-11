using UnityEngine;
using UnityEngine.Serialization;


public class Coins : MonoBehaviour
{
   private void OnTriggerEnter(Collider coll)
    {
        PlayerMovement.coinsAmount++;
        gameObject.SetActive(false);
    }
}