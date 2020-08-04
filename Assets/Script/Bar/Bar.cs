using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// バー（プレイヤー）クラス
/// </summary>
public class Bar : Actor
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
    [SerializeField] float Speed_ = 1.0f;

    /// <summary>
    /// 移動制限 xが右方向の制限 yが左方向の制限
    /// </summary>
    private Vector2 _moveLimit;

    private void Awake()
    {
        MoveLimitSet();
    }

    // Start is called before the first frame update
    void Start()
    {
        _lockPosY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        BarMove();
        
    }

    /// <summary>
    /// Barの移動処理
    /// </summary>
    private void BarMove()
    {
        //メインカメラからみたマウスポジションに変換し代入
        _screenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       
        //マウスが指定した座標に段々遅くなりながら移動
        Vector3 pos = Vector3.Lerp(transform.position, _screenPos, Time.deltaTime * Speed_);

        //Y軸は固定の為ここで代入
        transform.position = new Vector3(pos.x, _lockPosY);

        MoveLimit();
    }

    /// <summary>
    /// 進める制限を_moveLimitに代入する
    /// </summary>
    private void MoveLimitSet()
    {
        //右にrayを飛ばしそのオブジェクトを取得
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right);

        //hitに情報があったら
        if (hit) 
        {
            //当たった座標を代入
            _moveLimit.x = hit.point.x;
        } 
        //なかった場合
        else
        {
            _moveLimit.x = 0.0f;
            Debug.LogError("Bar.cs hitに値が返って来ませんでした");
        }

        //左にrayを飛ばしそのオブジェクトを取得
        hit = Physics2D.Raycast(transform.position, -transform.right);

        //hitに情報があったら
        if (hit)
        {
            _moveLimit.y = hit.point.x;
        }
        //なかった場合
        else
        {
            _moveLimit.y = 0;
            Debug.LogError("Bar.cs hitに値が返って来ませんでした");
        }
        
    }

    /// <summary>
    /// 毎フレームマウス座標が移動制限領域を超えてないか確認する
    /// 超えていた場合制限座標を代入
    /// </summary>
    private void MoveLimit()
    {
        Vector2 pos = transform.position;

        if (pos.x > _moveLimit.x) pos.x = _moveLimit.x;

        if (pos.x < _moveLimit.y) pos.x = _moveLimit.y;

        transform.position = pos;
    }

    /// <summary>
    /// ゴールした場合呼ぶ　引数に入った値をScoreコンポーネントにセットする
    /// </summary>
    /// <param name="value"></param>
    public override void Goal(int value)
    {
        GetComponent<Score>().SetScore(value);
    }
}
