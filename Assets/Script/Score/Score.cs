using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーとエネミーのスコアクラス
/// </summary>
public class Score : MonoBehaviour
{
    private int _score;

    private void Start()
    {
        _score = 0;
    }

    public int GetScore()
    {
        return _score;
    }

    /// <summary>
    /// スコアに加算
    /// </summary>
    /// <param name="value"></param>
    public void SetScore(int value)
    {
        _score += value;
    }
}
