using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicHolder
{

	public static bool isMock = false;
	
	public static ILogic GetLogic()
	{
		if (isMock)
		{
			return new LogicMock(0);
		}
		else
		{
			return new Logic();
		}
	}
}
