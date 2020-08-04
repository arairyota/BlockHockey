using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision2DOrijin : MonoBehaviour
{
    /// <summary>
    /// 弾の参照
    /// </summary>
    private GameObject _bullet = null;

    static int MAX_VERTEX = 4;

    /// <summary>
    /// SpriteRenderer参照
    /// </summary>
    private SpriteRenderer Rend = null;

    /// <summary>
    /// 弾観測フラグ
    /// </summary>
    private bool _isSearch = false;

    // Start is called before the first frame update
    void Start()
    {
        Rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        HitCheck();
    }

    private bool HitCheck()
    {
        _bullet = GameObject.FindGameObjectWithTag("Ball");

        if (_bullet == null)
        {
            //Debug.LogError("_bulletが無い！");
            return false;
        }

        Vector2 vec1 = new Vector2(0.0f, 0.0f);
        Vector2 vec2 = new Vector2(0.0f, 0.0f);
        float[] cross_Z = new float[MAX_VERTEX];

        Vector2[] vector = new Vector2[5];

        vector[0].x = (-Rend.bounds.extents.x * 0.5f) + transform.position.x;
        vector[0].y = (Rend.bounds.extents.y * 0.5f) + transform.position.y;

        vector[1].x = (Rend.bounds.extents.x * 0.5f) + transform.position.x;
        vector[1].y = (Rend.bounds.extents.y * 0.5f) + transform.position.y;

        vector[2].x = (-Rend.bounds.extents.x * 0.5f) + transform.position.x;
        vector[2].y = (-Rend.bounds.extents.y * 0.5f) + transform.position.y;

        vector[3] = vector[0];

        //vector[3].x = (Rend.bounds.extents.x * 0.5f) + transform.position.x;
        //vector[3].y = (-Rend.bounds.extents.y * 0.5f) + transform.position.y;

        vector[4] = vector[0];

        //for(int j = 0; j < 2; j++)
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        vec1.x = vector[i + j].x - _bullet.transform.position.x;
        //        vec1.y = vector[i + j].y - _bullet.transform.position.y;
        //
        //        vec2.x = vector[i + 1 + j].x - vector[i + j].x;
        //        vec2.y = vector[i + 1 + j].y - vector[i + j].y;
        //
        //        cross_Z[i] = (vec1.x * vec2.y - vec2.x * vec1.y);
        //    }
        //
        //    //全部minus
        //    if ((Mathf.Sign(cross_Z[0]) == -1 && Mathf.Sign(cross_Z[1]) == -1 && Mathf.Sign(cross_Z[2]) == -1) || (Mathf.Sign(cross_Z[0]) == 1 && Mathf.Sign(cross_Z[1]) == 1 && Mathf.Sign(cross_Z[2]) == 1))
        //    {
        //        return true;
        //    }
        //}

        for (int j = 0; j < 2; j++)
        {

            for (int i = 0; i < 3; i++)
            {
                vec1.x = vector[i + j].x - _bullet.transform.position.x;
                vec1.y = vector[i + j].y - _bullet.transform.position.y;

                if (i == 3)
                {
                    vec2.x = vector[0 + j].x - vector[i + j].x;
                    vec2.y = vector[0 + j].y - vector[i + j].y;
                }

                else
                {
                    vec2.x = vector[i + 1 + j].x - vector[i + j].x;
                    vec2.y = vector[i + 1 + j].y - vector[i + j].y;
                }


                cross_Z[i] = (vec1.x * vec2.y - vec2.x * vec1.y);
            }

            //全部minus
            if ((Mathf.Sign(cross_Z[0]) == -1 && Mathf.Sign(cross_Z[1]) == -1 && Mathf.Sign(cross_Z[2]) == -1) || (Mathf.Sign(cross_Z[0]) == 1 && Mathf.Sign(cross_Z[1]) == 1 && Mathf.Sign(cross_Z[2]) == 1))
            {
                return true;
            }

        }

        



        return false;
    }

    private bool IsBulletSerch()
    {


        return false;
    }
}
