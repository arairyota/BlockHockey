using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 当たったらスコアと速度を加算
/// </summary>
public class AddScore : MonoBehaviour
{
    /// <summary>
    /// 加算したいスコア
    /// </summary>
     GameObject _scoreManager = null;

    /// <summary>
    /// ブロックごとに与える速度が変わる用
    /// </summary>
    [Header("弾加算速度")]
    [SerializeField] float Speed_ = 0.1f;

    private void Start()
    {
        _scoreManager = GameObject.Find("ScoreManager");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _scoreManager.GetComponent<ScoreManager>().Add();
        collision.gameObject.GetComponent<Ball>().AddSpeed(Speed_);
    }
}
