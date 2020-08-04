using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    /// <summary>
    /// スクリーン座標
    /// </summary>
    private Vector3 _screenPos;

    /// <summary>
    /// Y座標に固定するための変数
    /// </summary>
    private float _lockPosY;

    [Header("速度")]
    [SerializeField] float _speed = 1.0f;

    /// <summary>
    /// 移動制限 xが右方向の制限 yが左方向の制限
    /// </summary>
    //private Vector2 _moveLimit;

    /// <summary>
    /// Hierarchy上の弾情報
    /// </summary>
    private GameObject _ball;

    // Start is called before the first frame update
    void Start()
    {
        _lockPosY = transform.position.y;
        _ball = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        BallSearch();
        BarMove();
    }

    /// <summary>
    /// Barの移動処理
    /// </summary>
    private void BarMove()
    {
        if(_ball == null)
        {
            //とりあえず真ん中に行かせる
            _screenPos = new Vector3(0.0f, _lockPosY);
        }
        else
        {
            _screenPos = BallPrediction();
        }

        //BallPredictionが指定した座標に段々遅くなりながら移動
        Vector3 pos = Vector3.Lerp(transform.position, _screenPos, Time.deltaTime * _speed);

        //Y軸を代入
        transform.position = new Vector3(pos.x, _lockPosY);
    }

    /// <summary>
    /// 着弾地点の座標を返す
    /// </summary>
    /// <returns></returns>
    private Vector3 BallPrediction()
    {
        Vector2 pos = Vector2.zero;

        //弾が自分に向かってきていいるか半分より上にきてたら
        if (_ball.transform.up.y > 0 || _ball.transform.position.y > 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(_ball.transform.position, _ball.transform.up);
        
            pos = new Vector2(hit.point.x, hit.point.y);
        }

        //RaycastHit2D hit = Physics2D.Raycast(_ball.transform.position, _ball.transform.up);
        //
        //pos = new Vector2(hit.point.x, hit.point.y);

        return pos;
    }

    /// <summary>
    /// ゴールした場合呼ぶ　引数に入った値をScoreコンポーネントにセットする
    /// </summary>
    /// <param name="value"></param>
    public override void Goal(int value)
    {
        GetComponent<Score>().SetScore(value);
    }

    /// <summary>
    /// 弾の情報取得関数
    /// </summary>
    private void BallSearch()
    {
        if(_ball == null)
        {
            _ball = GameObject.FindGameObjectWithTag("Ball");
        }
    }
}
