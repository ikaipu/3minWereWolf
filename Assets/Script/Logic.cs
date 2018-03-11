using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic : ILogic {
	
	public int GetRandamInt(int start,int end)
	{
		return UnityEngine.Random.RandomRange(start,end);
	}

	public void StartTime(int time, Action onTime)
	{
		throw new NotImplementedException();
	}
}
