using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TierText : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI playerName;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI kills;
    [SerializeField] private TextMeshProUGUI assists;
    [SerializeField] private TextMeshProUGUI deaths;
    public int Score => int.Parse(score.text);
    public int Kills => int.Parse(kills.text);
    public int Assists => int.Parse(assists.text);
    public int Deaths => int.Parse(deaths.text);


    private void Start()
    {
        int _kills = Random.Range(0, 100);
        int _assists = Random.Range(0, 100);
        int _deaths = Random.Range(0, 100);

        int _score = (_kills * 3) + (_assists * 1) - (_deaths * 1);

        if(_score < 0)
        {
            _score = 0;
        }

        score.text = _score.ToString();
        kills.text = _kills.ToString();
        assists.text = _assists.ToString();
        deaths.text = _deaths.ToString();
    }

    public void ChangeValues(string name , int kills, int assists, int deaths , int score)
    {
        playerName.text = name;
        this.kills.text = kills.ToString();
        this.assists.text = assists.ToString();
        this.deaths.text = deaths.ToString();
        this.score.text = score.ToString();
    }
}
