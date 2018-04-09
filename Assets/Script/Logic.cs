using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic : ILogic {
	
	private int time;
	private int passTime;
	private Action onTime;
	
	public int GetRandamInt(int start,int end)
	{
		return UnityEngine.Random.RandomRange(start,end);
	}

	public void StartTime(int time, Action onTime)
	{
		this.time = time;
		passTime = 0;
		this.onTime = onTime;
	}

	public void PassTime(int passedTime)
	{
		this.passTime += passedTime;
		if (this.passTime >= time)
		{
			if (onTime != null)
			{
				onTime();
				onTime = null;
			}	
		}
	}
}
