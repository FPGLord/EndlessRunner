using UnityEngine;


public class Coins : MonoBehaviour
{
    private int _coinsAmount; //переменная для хранения кол-ва собираемых монет.

    private void OnTriggerEnter(Collider coll)
    {
       _coinsAmount++;
        gameObject.SetActive(false);
    }
}