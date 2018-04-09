using System;
using System.Collections.Generic;
using System.Linq;

public class GameManager
{
    private ILogic logic;
    private Dictionary<int, int> voteDic;
    private int killTarget;
    private int wereWolfIndex;
    private List<int> DeadList;

    public GameManager(ILogic logic)
    {
        this.logic = logic;
        voteDic = new Dictionary<int, int>();
        for (int i = 0; i < 6; i++)
        {
            voteDic.Add(i, -1);
        }
        DeadList = new List<int>();
        killTarget = -1;
    }

    public void SetWerewolfIndex()
    {
        wereWolfIndex = logic.GetRandamInt(0, 6);
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
        voteDic[from] = to;
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
        Dictionary<int, int> votedDic = new Dictionary<int, int>();
        for (int i = 0; i < 6; i++)
        {
            votedDic.Add(i, 0);
        }

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

        if (DeadList.Count() >= 5)
        {
            return "Werewolf";
        }

        return "";
    }
}