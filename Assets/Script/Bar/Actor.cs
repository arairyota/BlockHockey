using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーやエネミーの継承元
/// </summary>
public abstract class Actor : MonoBehaviour
{
    /// <summary>
    /// ゴールした時の処理
    /// </summary>
    /// <param name="value"></param>
   public abstract void Goal(int value);
}
