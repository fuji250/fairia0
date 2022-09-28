using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Recorder : MonoBehaviour
{
    //　操作キャラクター
    [SerializeField]
    private GhostChara ghostChara;
    //　現在記憶しているかどうか
    private bool isRecord;
    //　保存するデータの最大数
    [SerializeField]
    private int maxDataNum = 2000000;
    //　記録間隔
    [SerializeField]
    private float recordDuration = 0.005f;
    //　経過時間
    private float elapsedTime = 0f;
    //　ゴーストデータ
    private ListData listData;
    //　再生中かどうか
    private bool isPlayBack;

    //　ゴースト用キャラ
    [SerializeField]
    public GameObject ghost0;


    [SerializeField]
    public GameObject ghost;

    public List<GameObject> ghosts;
    public List<Rigidbody2D> rbodys;


    public List<bool> right0 = new List<bool>();


    public int ghostCount = 0;
    //　ゴーストデータが1周りした後の待ち時間
    [SerializeField]
    private float waitTime = 0f;


    public LayerMask groundLayer;
    bool onGround = false;

    public GameObject panel;
    public GameObject mainImage;

    bool firstFlag = true;
    //　ゴーストデータを取り始めた時間、または前のデータ
    private float startTime;
    //　ゴーストの位置・角度のデータを最後まで再生したかどうか
    private bool isLoopReset;

    public float xpos = 0.0f;
    public float ypos = 0.0f;

    bool firstRec = true;


    void Start()
    {
        StartRecord();
        ghostCount = 0;

    }

    //　ゴーストデータクラス
    [Serializable]
    private class ListData
    {
        // 右カーソルキーのリスト
        public List<List<bool>> rightLists = new List<List<bool>>();
    }
    // Update is called once per frame
    void Update()
    {
        //記録
        if (isRecord && GhostChara.gameState == "playing")
        {
            Rec();
        }
    }

    //Updateで繰り返す
    public void Rec()
    {
        var moveHorizontal = Input.GetAxisRaw("Horizontal");

            elapsedTime += Time.deltaTime;

            if (elapsedTime >= recordDuration)
            {
                if (Input.GetAxisRaw("Horizontal") == 1)
                {
                    right0.Add(true);
                    Debug.Log("右記録");
                }
                else
                {
                    right0.Add(false);
                    Debug.Log("右記録");
                }

                elapsedTime = 0f;

                /*
                //　データ保存数が最大数を超えたら記録をストップ
                if (listData.rightLists[ghostCount].Count >= maxDataNum)
                {
                    StopRecord();
                }
                */
            }
    }
    //　キャラクターデータの保存
    public void StartRecord()
    {
        //　保存する時はゴーストの再生を停止
        StopGhost();

        


        isRecord = true;
        elapsedTime = 0f;
        //Listの初期化
        listData = new ListData();
        startTime = Time.realtimeSinceStartup;
        Debug.Log("StartRecord");
    }

    //　キャラクターデータの保存の停止
    public void StopRecord()
    {
        //最後に動き続けてしまうのを防止
        //listData.rightLists[ghostCount].Add(false);
        isRecord = false;
        Debug.Log("StopRecord");
    }

    //ゴーストの再生ボタンを押した時の処理
    public void StartGhost()
    {
        listData.rightLists.Add(right0);
        right0 = new List<bool>();

        Debug.Log("StartGhost");
        if (listData == null)
        {
            Debug.Log("ゴーストデータがありません");
        }
        else
        {
            isPlayBack = true;

            //ゴースト生成
            ghosts.Add(Instantiate(ghost0, new Vector2(xpos, ypos), Quaternion.identity));
            rbodys.Add(ghosts[ghosts.Count -1].GetComponent<Rigidbody2D>());

            StartCoroutine(PlayBack());
            //StartCoroutine(PlayBackJump());
        }
    }

    //　ゴーストの停止
    public void StopGhost()
    {
        //StopCoroutine(PlayBack());
        isPlayBack = false;
    }

    //　ゴーストの再生
    IEnumerator PlayBack()
    {
        //var i = 0;
        while (isPlayBack)
        {
            if (isLoopReset)
            {
                yield return null;
            }

            for (int j = 0; j < ghosts.Count; j++)
            {
                for (int i = 0; i < listData.rightLists[ghosts.Count-1].Count; i++)
                {
                    yield return new WaitForSeconds(recordDuration);
                if (listData.rightLists[j][i] == true)
                {
                    rbodys[j].velocity = new Vector2(ghostChara.speed * 1, rbodys[j].velocity.y);
                    ghost.transform.localScale = new Vector2(1, 1);
                }

                /*
                    if (listData.leftLists[ghostCount][i])
                    {
                        rbodys[j].velocity = new Vector2(ghostChara.speed * -1, rbodys[j].velocity.y);
                        ghost.transform.localScale = new Vector2(-1, 1);
                    }
                */
                //if (listData.rightLists[ghostCount][i] == false && listData.leftLists[ghostCount][i] == false)
                if (listData.rightLists[j][i] == false)
                {
                    rbodys[j].velocity = new Vector2(0, rbodys[j].velocity.y);
                }
                
                /*
                if (i >= listData.rightLists[ghosts.Count].Count)
                {
                    yield return new WaitForSeconds(waitTime);
                    isLoopReset = true;
                    i = 0;
                }
                */
                }
                
            }
        }
    }

    //RESTARTButtonで呼び出し
    //一度死んでから再スタートの処理
    public void roop()
    {
        GameObject.Find("Player").GetComponent<BoxCollider2D>().enabled = true;
        GameObject.Find("Up").GetComponent<BoxCollider2D>().enabled = true;
        GameObject.Find("Down").GetComponent<BoxCollider2D>().enabled = true;
        //GameObject.Find("Player").GetComponent<PolygonCollider2D>().enabled = true;
        GameObject.Find("Player").transform.position = new Vector2(xpos, ypos);
        GhostChara.gameState = "playing";
        panel.SetActive(false);

        mainImage.SetActive(false);
        if (firstFlag == true)
        {
            
        }
        //ghost.transform.position = new Vector2(xpos, ypos);

            StopRecord();

            StartGhost();
        //StartRecord();

    }
}