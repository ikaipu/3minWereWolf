using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
    
public interface ILogic
{
    int GetRandamInt(int start, int end);
    void StartTime(int time, Action onTime);
}
