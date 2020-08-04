using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

/// <summary>
/// スコア関係の値や関数を管理するクラス
/// </summary>
public class ScoreManager : MonoBehaviour
{
    [Header("勝利条件スコア")]
    [SerializeField] int WinScore_ = 1000;

    /// <summary> プレイヤーのスコア情報 </summary>
    private Score _playerScore = null;

    /// <summary> エネミーのスコア情報 </summary>
    private Score _enemyScore = null;

    /// <summary> ミドルスコアの情報 </summary>
    private GameObject _middleScore = null;

    /// <summary>　プレイヤーのスコア描画オブジェクト</summary>
    private GameObject _playerText = null;

    /// <summary>　エネミーのスコア描画オブジェクト</summary>
    private GameObject _enemyText = null;

    /// <summary> プレイヤーのゴールオブジェクト </summary>
    private GameObject _playerGoal = null;

    /// <summary> エネミーのゴールオブジェクト </summary>
    private GameObject _enemyGoal = null;

    /// <summary> Animator取得変数 </summary>
    private Animator _animator = null;

    /// <summary> Middleスコアの減算が始まっているか </summary>
    private bool _isShave;

    /// <summary> ブロック生成オブジェクト </summary>
    private GameObject _blockFactory = null;

    /// <summary>
    /// ゴールしたかを管理する変数
    /// GoalAnimationからMiddleScoreShaveに
    /// 進む間にGoalスクリプトのLateUpdateで
    /// _isGoalがfalseに変わってしまうため。
    /// </summary>
    private bool _isPlayerGoal = false;
    private bool _isEnemyGoal = false;

    /// <summary> BallFactory </summary>
    private GameObject _ballFactory = null;

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーとエネミーのスコアの情報取得
        _playerScore = GameObject.FindGameObjectWithTag("Player").GetComponent<Score>();
        _enemyScore = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Score>();

        //スコアUIの表示情報取得
        _playerText = GameObject.Find("PlayerScoreText");
        _enemyText = GameObject.Find("EnemyScoreText");

        _middleScore = GameObject.Find("MiddelScore");

        //プレイヤーのスコアテキスト初期化
        _playerText.GetComponent<Text>().text = Convert.ToString(_playerScore);

        //エネミーのスコアテキスト初期化
        _enemyText.GetComponent<Text>().text = Convert.ToString(_enemyScore);

        _playerGoal = GameObject.Find("PlayerGoal");
        _enemyGoal = GameObject.Find("EnemyGoal");

        _animator = GetComponent<Animator>();

        _ballFactory = GameObject.Find("BallFactory");

        _blockFactory = GameObject.Find("BlockFactory");

        _isShave = false;

        _isPlayerGoal = false;
        _isEnemyGoal = false;
    }

    // Update is called once per frame
    void Update()
    {
        //描画
        _playerText.GetComponent<Text>().text = Convert.ToString(_playerScore.GetScore());
        _enemyText.GetComponent<Text>().text = Convert.ToString(_enemyScore.GetScore());

        GoalAnimation();
    }

    private void GoalAnimation()
    {
        //どちらかがゴールしていたら
        if (_playerGoal.GetComponent<Goal>().IsGoal() || _enemyGoal.GetComponent<Goal>().IsGoal())
        {
            _animator.Play("MiddleScoreMove");
            _isPlayerGoal = _playerGoal.GetComponent<Goal>().IsGoal();
            _isEnemyGoal = _enemyGoal.GetComponent<Goal>().IsGoal();
        }

        MiddleScoreShave();

    }

    /// <summary>
    /// ミドルスコアを加算する
    /// </summary>
    public  void Add()
    {
        _middleScore.GetComponent<MiddleScore>().Add();
        _animator.Play("MiddleSizeChange", 0, 0);
    }

    /// <summary>
    /// MiddleScoreがゼロになるまで少しずつ減らす
    /// </summary>
    private void MiddleScoreShave()
    {
        if (_isShave)
        {
            //MiddleScoreが0以下なら実行
            if (_middleScore.GetComponent<MiddleScore>().GetScoreValue() <= 0)
            {
                _isShave = false;
                _animator.Play("MiddleScoreBack");

                //ゴールフラグ初期化
                _isPlayerGoal = _isEnemyGoal = false;
            }

            else
            {
                if (_isEnemyGoal)
                {
                    _enemyScore.SetScore(1);

                }
                if(_isPlayerGoal)
                {
                    _playerScore.SetScore(1);

                }

                //MiddleScoreが0になるまで1ずつ減算
                _middleScore.GetComponent<MiddleScore>().Reduce();
            }
        }
    }

    /// <summary>
    /// MiddleScoreの減算処理を始める関数
    /// Animator内で呼ぶ
    /// </summary>
    private void MiddleScoreShaveStart()
    {
        _isShave = true;
    }

    /// <summary>
    /// BallFactroyの発射命令をAnimatorで呼ぶ為の関数
    /// </summary>
    private void BallFire()
    {
        _ballFactory.GetComponent<BallFactory>().FireSet();
    }

    /// <summary>
    /// MiddleScoreBackが終わったタイミングで呼ぶ
    /// </summary>
    private void BlockReset()
    {
        _blockFactory.GetComponent<AutoInstance>().AllDestory();
        _blockFactory.GetComponent<AutoInstance>().AllInstantiate();
    }

    /// <summary>
    /// 勝敗が決しているか判定
    /// </summary>
    private void ScoreJudge()
    {
        //勝利スコアよりプレイヤーのスコアが大きかったら
        if(WinScore_ < _playerScore.GetScore())
        {
            SceneManager.LoadScene("WinScene");
        }

        if (WinScore_ < _enemyScore.GetScore())
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
