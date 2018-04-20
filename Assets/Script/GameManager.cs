using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager
{
    private ILogic logic;
    private Dictionary<int, int> voteDic;
    private Dictionary<int, int> votedDic;
    private int killTarget;
    private int wereWolfIndex;
    private List<int> DeadList;

    public GameManager(ILogic logic)
    {
        this.logic = logic;
        voteDic = new Dictionary<int, int>();
        votedDic = new Dictionary<int, int>();
        for (int i = 0; i < 3; i++)
        {
            voteDic.Add(i, -1);
            votedDic.Add(i, 0);
        }
        DeadList = new List<int>();
        killTarget = -1;
    }

    public void SetWerewolfIndex()
    {
        wereWolfIndex = logic.GetRandamInt(0, 3);
    }
    
    public int GetWerewolfIndex()
    {
        return wereWolfIndex;
    }

    public void StartGame(Action action)
    {
        logic.StartTime(60, action);
    }

    public void SetVoteTarget(int from, int to)
    {
        if (voteDic[from] > -1)
        {
            votedDic[voteDic[from]]--;
        }
        voteDic[from] = to;
        votedDic[to]++;
    }

    public int GetVotedNum(int index)
    {
        return votedDic[index];
    }

    public Dictionary<int, int> GetTargetDictionary()
    {
        return voteDic;
    }

    public void SetKillTarget(int target)
    {
        killTarget = target;
    }

    public double GetKillTarget()
    {
        return killTarget;
    }

    public double GetMostVotedIndex()
    {
        foreach (int fromIndex in voteDic.Keys)
        {
            votedDic[voteDic[fromIndex]]++;
        }

        int maxValue = votedDic.Values.Max();
        foreach (int votedIndex in votedDic.Keys)
        {
            if (votedDic[votedIndex] == maxValue)
            {
                return votedIndex;
            }
        }

        return -1;
    }

    public List<int> GetDeadList()
    {
        return DeadList;
    }

    public void Kill(int i)
    {
        DeadList.Add(i);
    }

    public string GetWinner()
    {
        if (DeadList.Contains(wereWolfIndex))
        {
            return "Citizen";
        }

        if (DeadList.Count() >= 2)
        {
            return "Werewolf";
        }

        return "";
    }
}