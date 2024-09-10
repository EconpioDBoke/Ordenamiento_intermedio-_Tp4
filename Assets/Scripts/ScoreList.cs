using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreList : MonoBehaviour
{
    [SerializeField] private List<TierText> entries = new List<TierText>();
    [SerializeField] private TierText tierTextPrefab;

    [SerializeField] private int maxElementsInBoard = 10;

    private void Awake()
    {
        CreateTierBoxes();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SortScore();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            SortKills();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            SortAssist();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SortDeaths();
        }
    }

    private void CreateTierBoxes()
    {
        for(int i = 0;i < maxElementsInBoard; i++)
        {
            TierText tier = Instantiate(tierTextPrefab, transform);
            tier.playerName.text = "Player " + i;
            entries.Add(tier);
        }
    }

    private void SortScore()
    {
        int smallest;

        for (int i = 0; i < entries.Count - 1; i++)
        {
            smallest = i;

            for (int index = i + 1; index < entries.Count; index++)
            {
                if (entries[index].Score < entries[smallest].Score)
                {
                    smallest = index;
                }
            }

            Swap(i, smallest, entries);
        }

        Debug.Log("Done");
    }

    private void SortKills()
    {
        int smallest;

        for (int i = 0; i < entries.Count - 1; i++)
        {
            smallest = i;

            for (int index = i + 1; index < entries.Count; index++)
            {
                if (entries[index].Kills < entries[smallest].Kills)
                {
                    smallest = index;
                }
            }

            Swap(i, smallest, entries);
        }

        Debug.Log("Done");
    }

    private void SortAssist()
    {
        int smallest;

        for (int i = 0; i < entries.Count - 1; i++)
        {
            smallest = i;

            for (int index = i + 1; index < entries.Count; index++)
            {
                if (entries[index].Assists < entries[smallest].Assists)
                {
                    smallest = index;
                }
            }

            Swap(i, smallest, entries);
        }

        Debug.Log("Done");
    }

    private void SortDeaths()
    {
        int smallest;

        for (int i = 0; i < entries.Count - 1; i++)
        {
            smallest = i;

            for (int index = i + 1; index < entries.Count; index++)
            {
                if (entries[index].Deaths < entries[smallest].Deaths)
                {
                    smallest = index;
                }
            }

            Swap(i, smallest, entries);
        }

        Debug.Log("Done");
    }

    private void Swap(int first, int second, List<TierText> data)
    {
        string tempName = data[first].playerName.text;
        int tempKills = data[first].Kills;
        int tempAssists = data[first].Assists;
        int tempDeaths = data[first].Deaths;
        int tempScore = data[first].Score;

        data[first].ChangeValues(data[second].playerName.text, data[second].Kills, data[second].Assists, data[second].Deaths, data[second].Score);
        data[second].ChangeValues (tempName, tempKills, tempAssists, tempDeaths, tempScore);
        Debug.Log("Swap");
    }
}

