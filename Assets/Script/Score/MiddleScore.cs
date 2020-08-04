using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// ミドルスコアクラス（ブロックに当たるたび加算するスコア）
/// </summary>
public class MiddleScore : MonoBehaviour
{
    [Header("スコア量")]
    [SerializeField] int AddScore_ = 1;

    /// <summary>
    /// スコア合計を一時的に保持する変数
    /// </summary>
    private int _scoreSum = 0;

    // Start is called before the first frame update
    void Start()
    {
        _scoreSum = 0;
        GetComponent<Text>().text = Convert.ToString(_scoreSum);
    }

    public void Add() 
    {
        _scoreSum += AddScore_;
        GetComponent<Text>().text = Convert.ToString(_scoreSum);
    }

    /// <summary>
    /// 1点づつマイナスしてその結果を返す
    /// </summary>
    public int Reduce()
    {
        if (_scoreSum > 0)
        {
            _scoreSum -= 1;
            GetComponent<Text>().text = Convert.ToString(_scoreSum);
        }
            
        return _scoreSum;
    }

    /// <summary>
    /// 持っているスコアの値を返す
    /// </summary>
    /// <returns></returns>
    public int GetScoreValue()
    {
        return _scoreSum;
    }
}
