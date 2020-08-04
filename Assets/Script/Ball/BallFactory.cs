using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 弾生成クラス
/// </summary>
public class BallFactory : MonoBehaviour
{
    [Header("発射する弾オブジェクトプレハブ")]
    [SerializeField] GameObject Ball_ = null;

    [Header("弾の初速")]
    [SerializeField] float InitialVelocity_ = 1;

    [Header("発射タイミングのエフェクトプレハブ")]
    [SerializeField] GameObject BirthEffect_ = null;

    [Header("発射までの時間")]
    [SerializeField] float FireCoolTime_ = 1.0f;

    /// <summary>発射準備フラグ</summary>
    private bool _isFireReady;

    /// <summary>発射までのカウントダウン</summary>
    private float _coolTimeCount;

    // Start is called before the first frame update
    void Start()
    {
        _isFireReady = false;

        //最初に止めないと動いてしまうのでStop
        BirthEffect_.GetComponent<ParticleSystem>().Stop();

        _coolTimeCount = 0.0f;

        FireSet();
    }

    private void Update()
    {
        FireReady();
    }

    /// <summary>
    /// 弾発射
    /// </summary>
    private void Fire()
    {
        Instantiate(Ball_).GetComponent<Ball>().SetSpeed(InitialVelocity_);

        //発射後発射準備を戻す
        _isFireReady = false;
        BirthEffect_.GetComponent<ParticleSystem>().Stop();

        _coolTimeCount = 0.0f;
    }

    /// <summary>
    /// 反射準備が完了
    /// </summary>
    public void FireSet()
    {
        _isFireReady = true;

        //エフェクト開始
        BirthEffect_.GetComponent<ParticleSystem>().Play();
    }

    /// <summary>
    /// 毎フレーム発射準備が完了しているか
    /// していたらカウントダウン開始
    /// </summary>
    private void FireReady()
    {
        if (_isFireReady)
        {
            _coolTimeCount += Time.deltaTime;

            //クールタイムが終わっていたら
            if (_coolTimeCount >= FireCoolTime_)
            {
                Fire();
            }
        }
    }
}
