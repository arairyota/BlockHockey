using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// アタッチしたオブジェクトの自動生成
///生成したオブジェクトの管理 
/// </summary>
public class AutoInstance : MonoBehaviour
{
    [Header("生成するオブジェクトをアタッチ")]
    [SerializeField] GameObject InstansObject = null;

    [Header("生成する間隔")]
    [SerializeField] Vector2 _offsetPos = new Vector2(0, 0);

    [Header("オブジェクトの生成数")]
    [SerializeField] Vector2Int _instanceNum = new Vector2Int(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        AllInstantiate();

    }

    /// <summary>
    /// 生成したObjectの位置を微調整する値を出す関数
    /// </summary>
    /// <param name="objectScale">微調整したいオブジェクト</param>
    /// <param name="x">二重forの最初のカウンタ</param>
    /// <param name="y">二重forの次のカウンタ</param>
    /// <returns></returns>
    private Vector3 OffsetSum(Vector2 offsetPos, int x, int y)
    {
        return new Vector3(offsetPos.x * x, offsetPos.y * -y);
    }

    /// <summary>
    /// 生成
    /// </summary>
    public void AllInstantiate()
    {
        for (int x = 0; x < _instanceNum.x; x++)
        {
            for (int y = 0; y < _instanceNum.y; y++)
            {
                var newObject = Instantiate(InstansObject);
                newObject.transform.position = transform.position;
                Vector3 offset = OffsetSum(_offsetPos, x, y);
                newObject.transform.position += offset;

            }
        }
    }

    /// <summary>
    /// 生成したオブジェクト全て消去
    /// </summary>
    public void AllDestory()
    {
        var blocks = GameObject.FindGameObjectsWithTag(InstansObject.tag);
        foreach(var block in blocks)
        {
            Destroy(block.gameObject);
        }
        
    }
}
