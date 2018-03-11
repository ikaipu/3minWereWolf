using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicMock:ILogic
{
	private int fixNo;
	private int time;
	private int passTime;
	private Action onTime;
	public LogicMock(int fixNo)
	{
		this.fixNo = fixNo;
	}

	public int GetRandamInt(int start,int end)
	{
		return fixNo;
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
