using UnityEngine;

public class ConsoleWriter : MonoBehaviour
{
   public void Write(string text)
   {
      print($"{text} frames: {Time.frameCount}" );
   }
}
