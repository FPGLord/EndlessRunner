using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerVariable : ScriptableObject
{
    private Conveyer _conveyer;
    public Conveyer conveyer => _conveyer;

    public void Set(Conveyer conveyer)
    {
        _conveyer = conveyer;
    }

    public void MoveBack()
    {
        _conveyer.MoveBack();
    }

    public void SpeedUpBox()
    {
        _conveyer.SpeedUp();
    }

    public void SpeedDownBox()
    {
        _conveyer.SpeedDown();
    }
    
 
}
