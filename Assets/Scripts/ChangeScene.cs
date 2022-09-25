using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//シーンの切り替えに必要

public class ChangeScene : MonoBehaviour
{
    public string NextSceneName;//読み込むシーン名
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //シーンを読み込む
    public void Load()
    {
        FadeManager.Instance.LoadScene(NextSceneName, 1.0f);
    }
    
}
