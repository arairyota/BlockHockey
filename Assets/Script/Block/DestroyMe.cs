using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 当たったら自分自身を消す
/// </summary>
public class DestroyMe : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
