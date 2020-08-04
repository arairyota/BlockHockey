using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 弾クラス
/// </summary>
public class Ball : MonoBehaviour
{
    /// <summary>
    /// 速度
    /// </summary>
    private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        //生成位置をBallFactoryの上に移動
        transform.position = GameObject.Find("BallFactory").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //向いてるベクトルに速度をかける
        transform.position += transform.up * _speed * Time.deltaTime;  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Reflect(collision);
    }

    /// <summary>
    /// 弾の反射処理
    /// </summary>
    /// <param name="collision"></param>
    private void Reflect(Collision2D collision)
    {
        //引数の法線を格納する変数
        Vector3 normal = new Vector3();

        //接触点の法線を求める
        foreach (ContactPoint2D contact in collision.contacts)
        {
            normal = contact.normal;
        }

        //反射後のベクトルをupベクトルに代入
        transform.up = Vector3.Reflect(transform.up, normal);
    }

    /// <summary>
    /// 弾の速度代入
    /// </summary>
    /// <param name="speed"></param>
    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    /// <summary>
    /// 弾に速度を加算
    /// </summary>
    /// <param name="speed"></param>
    public void AddSpeed(float speed)
    {
        _speed += speed;
    }
}
