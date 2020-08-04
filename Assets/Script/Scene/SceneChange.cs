using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン変更クラス
/// </summary>
public class SceneChange : MonoBehaviour
{
    [Header("SceneName")]
    [SerializeField] string Name_ = null;

    /// <summary>
    /// シーンチェンジ
    /// </summary>
    public void Change()
    {
        SceneManager.LoadScene(Name_);

    }
}
