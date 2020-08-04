using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゴールクラス
/// </summary>
public class Goal : MonoBehaviour
{
    /// <summary>
    /// ミドルスコア
    /// </summary>
    private GameObject _middleScore = null;

    /// <summary>
    /// ゴールしたかどうか
    /// </summary>
    private bool _isGoal = false;

    // Start is called before the first frame update
    void Start()
    {
        _middleScore = GameObject.Find("MiddelScore");

        _isGoal = false;

        if (_middleScore == null)
        {
            Debug.LogError("ミドルスコアをアタッチしてください");
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _isGoal = false; //ゴールしたフレームのみtrueを返すため
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ゴールを決めた方にミドルスコアの値を渡す
        //Actor_.GetComponent<Actor>().Goal(_middleScore.GetComponent<MiddleScore>().GetScore());

        _isGoal = true;

        Destroy(collision.gameObject); //弾を消す

    }

    /// <summary>
    /// ゴールした瞬間だけtrueを返す
    /// </summary>
    /// <returns></returns>
    public bool IsGoal()
    {
        return _isGoal;
    }
}
