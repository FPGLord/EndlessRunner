using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoxes : MonoBehaviour
{
   [SerializeField] private GameObject[] _prefabBoxes;
   [SerializeField] private Transform _platform;

   private void Start()
   {
      CreateBoxes();
   }

   public void CreateBoxes()
   {
      foreach (var box in _prefabBoxes)
      {
         box.transform.SetParent(_platform);
         box.SetActive(true);
      }
   }
}
