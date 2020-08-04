using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ポーズが間に合わなかったため強制終了
/// </summary>
public class AltF4 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
