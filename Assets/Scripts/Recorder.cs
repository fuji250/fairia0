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
    private bool isRecord2;
    private bool isRecord3;
    private bool isRecord4;
    private bool isRecord5;
    private bool isRecord6;
    private bool isRecord7;
    private bool isRecord8;
    private bool isRecord9;
    private bool isRecord10;
    //　保存するデータの最大数
    [SerializeField]
    private int maxDataNum = 200000;
    //　記録間隔
    [SerializeField]
    private float recordDuration = 0.005f;
    //　経過時間
    private float elapsedTime = 0f;
    private float elapsedTime2 = 0f;
    private float elapsedTime3 = 0f;
    private float elapsedTime4 = 0f;
    private float elapsedTime5 = 0f;
    private float elapsedTime6 = 0f;
    private float elapsedTime7 = 0f;
    private float elapsedTime8 = 0f;
    private float elapsedTime9 = 0f;
    private float elapsedTime10 = 0f;
    //　ゴーストデータ
    private GhostData ghostData;
    private GhostData2 ghostData2;
    private GhostData3 ghostData3;
    private GhostData4 ghostData4;
    private GhostData5 ghostData5;
    private GhostData6 ghostData6;
    private GhostData7 ghostData7;
    private GhostData8 ghostData8;
    private GhostData9 ghostData9;
    private GhostData10 ghostData10;
    //　再生中かどうか
    private bool isPlayBack;
    private bool isPlayBack2;
    private bool isPlayBack3;
    private bool isPlayBack4;
    private bool isPlayBack5;
    private bool isPlayBack6;
    private bool isPlayBack7;
    private bool isPlayBack8;
    private bool isPlayBack9;
    private bool isPlayBack10;
    //　ゴースト用キャラ
    [SerializeField]
    public GameObject ghost;
    [SerializeField]
    public GameObject ghost2;
    [SerializeField]
    public GameObject ghost3;
    [SerializeField]
    public GameObject ghost4;
    [SerializeField]
    public GameObject ghost5;
    [SerializeField]
    public GameObject ghost6;
    [SerializeField]
    public GameObject ghost7;
    [SerializeField]
    public GameObject ghost8;
    [SerializeField]
    public GameObject ghost9;
    [SerializeField]
    public GameObject ghost10;
    //　ゴーストデータが1周りした後の待ち時間
    [SerializeField]
    private float waitTime = 0f;

    Rigidbody2D rbody;
    Rigidbody2D rbody2;
    Rigidbody2D rbody3;
    Rigidbody2D rbody4;
    Rigidbody2D rbody5;
    Rigidbody2D rbody6;
    Rigidbody2D rbody7;
    Rigidbody2D rbody8;
    Rigidbody2D rbody9;
    Rigidbody2D rbody10;

    public LayerMask groundLayer;
    bool onGround = false;
    bool onGround2 = false;
    bool onGround3 = false;
    bool onGround4 = false;
    bool onGround5 = false;
    bool onGround6 = false;
    bool onGround7 = false;
    bool onGround8 = false;
    bool onGround9 = false;
    bool onGround10 = false;

    public GameObject panel;
    public GameObject mainImage;

    bool firstFlag = false;
    bool secondFlag = false;
    bool thirdFlag = false;
    bool fourthFlag = false;
    bool fifthFlag = false;
    bool sixthFlag = false;
    bool seventhFlag = false;
    bool eighthFlag = false;
    bool ninethFlag = false;
    bool tenthFlag = false;
    bool FirstFlag = false;
    bool SecondFlag = false;
    bool ThirdFlag = false;
    bool FourthFlag = false;
    bool FifthFlag = false;
    bool SixthFlag = false;
    bool SeventhFlag = false;
    bool EighthFlag = false;
    bool NinethFlag = false;
    bool TenthFlag = false;
    //　ゴーストデータを取り始めた時間、または前のデータ
    private float startTime;
    private float startTime2;
    private float startTime3;
    private float startTime4;
    private float startTime5;
    private float startTime6;
    private float startTime7;
    private float startTime8;
    private float startTime9;
    private float startTime10;
    //　ゴーストの位置・角度のデータを最後まで再生したかどうか
    private bool isLoopReset;
    private bool isLoopReset2;
    private bool isLoopReset3;
    private bool isLoopReset4;
    private bool isLoopReset5;
    private bool isLoopReset6;
    private bool isLoopReset7;
    private bool isLoopReset8;
    private bool isLoopReset9;
    private bool isLoopReset10;

    public float xpos = 0.0f;
    public float ypos = 0.0f;

    void Start()
    {
        rbody = ghost.GetComponent<Rigidbody2D>();
        rbody2 = ghost2.GetComponent<Rigidbody2D>();
        rbody3 = ghost3.GetComponent<Rigidbody2D>();
        rbody4 = ghost4.GetComponent<Rigidbody2D>();
        rbody5 = ghost5.GetComponent<Rigidbody2D>();
        rbody6 = ghost6.GetComponent<Rigidbody2D>();
        rbody7 = ghost7.GetComponent<Rigidbody2D>();
        rbody8 = ghost8.GetComponent<Rigidbody2D>();
        rbody9 = ghost9.GetComponent<Rigidbody2D>();
        rbody10 = ghost10.GetComponent<Rigidbody2D>();
        StartRecord();
        firstFlag = true;
    }
    //　ゴーストデータクラス
    [Serializable]
    private class GhostData
    {
        // 右カーソルキーのリスト
        public List<bool> rightLists = new List<bool>();
        // 左カーソルキーのリスト
        public List<bool> leftLists = new List<bool>();
        // ジャンプキーのリスト
        public List<float> jumpLists = new List<float>();
    }
    [Serializable]
    private class GhostData2
    {
        public List<bool> rightLists = new List<bool>();
        public List<bool> leftLists = new List<bool>();
        public List<float> jumpLists = new List<float>();
    }
    [Serializable]
    private class GhostData3
    {
        public List<bool> rightLists = new List<bool>();
        public List<bool> leftLists = new List<bool>();
        public List<float> jumpLists = new List<float>();
    }
    [Serializable]
    private class GhostData4
    {
        public List<bool> rightLists = new List<bool>();
        public List<bool> leftLists = new List<bool>();
        public List<float> jumpLists = new List<float>();
    }
    [Serializable]
    private class GhostData5
    {
        public List<bool> rightLists = new List<bool>();
        public List<bool> leftLists = new List<bool>();
        public List<float> jumpLists = new List<float>();
    }
    [Serializable]
    private class GhostData6
    {
        public List<bool> rightLists = new List<bool>();
        public List<bool> leftLists = new List<bool>();
        public List<float> jumpLists = new List<float>();
    }
    [Serializable]
    private class GhostData7
    {
        public List<bool> rightLists = new List<bool>();
        public List<bool> leftLists = new List<bool>();
        public List<float> jumpLists = new List<float>();
    }
    [Serializable]
    private class GhostData8
    {
        public List<bool> rightLists = new List<bool>();
        public List<bool> leftLists = new List<bool>();
        public List<float> jumpLists = new List<float>();
    }
    [Serializable]
    private class GhostData9
    {
        public List<bool> rightLists = new List<bool>();
        public List<bool> leftLists = new List<bool>();
        public List<float> jumpLists = new List<float>();
    }
    [Serializable]
    private class GhostData10
    {
        public List<bool> rightLists = new List<bool>();
        public List<bool> leftLists = new List<bool>();
        public List<float> jumpLists = new List<float>();
    }

    // Update is called once per frame
    void Update()
    {
        var moveHorizontal = Input.GetAxisRaw("Horizontal");

        if (isRecord && GhostChara.gameState == "playing")
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= recordDuration)
            {
                if (Input.GetAxisRaw("Horizontal") == 1)
                {
                    ghostData.rightLists.Add(true);
                    Debug.Log("右記録");
                }
                else
                {
                    ghostData.rightLists.Add(false);
                    Debug.Log("右記録");
                }

                if (Input.GetAxisRaw("Horizontal") == -1)
                {
                    ghostData.leftLists.Add(true);
                    Debug.Log("左記録");
                }
                else
                {
                    ghostData.leftLists.Add(false);
                    Debug.Log("左記録");
                }

                elapsedTime = 0f;

                //　データ保存数が最大数を超えたら記録をストップ
                if (ghostData.rightLists.Count >= maxDataNum)
                {
                    StopRecord();
                }
            }
            //　ジャンプは押した時間を保持
            if (Input.GetButtonDown("Jump"))
            {
                ghostData.jumpLists.Add(Time.realtimeSinceStartup - startTime );
                startTime = Time.realtimeSinceStartup;
            }
        }
        if(isRecord2 && GhostChara.gameState == "playing")
        {
            elapsedTime2 += Time.deltaTime;
            if (elapsedTime2 >= recordDuration)
            {
                if (Input.GetAxisRaw("Horizontal") == 1)
                {
                    ghostData2.rightLists.Add(true);
                }
                else
                {
                    ghostData2.rightLists.Add(false);
                }

                if (Input.GetAxisRaw("Horizontal") == -1)
                {
                    ghostData2.leftLists.Add(true);
                }
                else
                {
                    ghostData2.leftLists.Add(false);
                }
                elapsedTime2 = 0f;
                if (ghostData2.rightLists.Count >= maxDataNum)
                {
                    StopRecord2();
                }
            }
            if (Input.GetButtonDown("Jump"))
            {
                ghostData2.jumpLists.Add(Time.realtimeSinceStartup - startTime2);
                startTime2 = Time.realtimeSinceStartup;
            }
        }
        if (isRecord3 && GhostChara.gameState == "playing")
        {
            elapsedTime3 += Time.deltaTime;
            if (elapsedTime3 >= recordDuration)
            {
                if (Input.GetAxisRaw("Horizontal") == 1)
                {
                    ghostData3.rightLists.Add(true);
                }
                else
                {
                    ghostData3.rightLists.Add(false);
                }

                if (Input.GetAxisRaw("Horizontal") == -1)
                {
                    ghostData3.leftLists.Add(true);
                }
                else
                {
                    ghostData3.leftLists.Add(false);
                }
                elapsedTime3 = 0f;
                if (ghostData3.rightLists.Count >= maxDataNum)
                {
                    StopRecord3();
                }
            }
            if (Input.GetButtonDown("Jump"))
            {
                ghostData3.jumpLists.Add(Time.realtimeSinceStartup - startTime3);
                startTime3 = Time.realtimeSinceStartup;
            }
        }
        if (isRecord4 && GhostChara.gameState == "playing")
        {
            elapsedTime4 += Time.deltaTime;
            if (elapsedTime4 >= recordDuration)
            {
                if (Input.GetAxisRaw("Horizontal") == 1)
                {
                    ghostData4.rightLists.Add(true);
                }
                else
                {
                    ghostData4.rightLists.Add(false);
                }

                if (Input.GetAxisRaw("Horizontal") == -1)
                {
                    ghostData4.leftLists.Add(true);
                }
                else
                {
                    ghostData4.leftLists.Add(false);
                }
                elapsedTime4 = 0f;
                if (ghostData4.rightLists.Count >= maxDataNum)
                {
                    StopRecord4();
                }
            }
            if (Input.GetButtonDown("Jump"))
            {
                ghostData4.jumpLists.Add(Time.realtimeSinceStartup - startTime4);
                startTime4 = Time.realtimeSinceStartup;
            }
        }
        if (isRecord5 && GhostChara.gameState == "playing")
        {
            elapsedTime5 += Time.deltaTime;
            if (elapsedTime5 >= recordDuration)
            {
                if (Input.GetAxisRaw("Horizontal") == 1)
                {
                    ghostData5.rightLists.Add(true);
                }
                else
                {
                    ghostData5.rightLists.Add(false);
                }

                if (Input.GetAxisRaw("Horizontal") == -1)
                {
                    ghostData5.leftLists.Add(true);
                }
                else
                {
                    ghostData5.leftLists.Add(false);
                }
                elapsedTime5 = 0f;
                if (ghostData5.rightLists.Count >= maxDataNum)
                {
                    StopRecord5();
                }
            }
            if (Input.GetButtonDown("Jump"))
            {
                ghostData5.jumpLists.Add(Time.realtimeSinceStartup - startTime5);
                startTime5 = Time.realtimeSinceStartup;
            }
        }
        if (isRecord6 && GhostChara.gameState == "playing")
        {
            elapsedTime6 += Time.deltaTime;
            if (elapsedTime6 >= recordDuration)
            {
                if (Input.GetAxisRaw("Horizontal") == 1)
                {
                    ghostData6.rightLists.Add(true);
                }
                else
                {
                    ghostData6.rightLists.Add(false);
                }

                if (Input.GetAxisRaw("Horizontal") == -1)
                {
                    ghostData6.leftLists.Add(true);
                }
                else
                {
                    ghostData6.leftLists.Add(false);
                }
                elapsedTime6 = 0f;
                if (ghostData6.rightLists.Count >= maxDataNum)
                {
                    StopRecord6();
                }
            }
            if (Input.GetButtonDown("Jump"))
            {
                ghostData6.jumpLists.Add(Time.realtimeSinceStartup - startTime6);
                startTime6 = Time.realtimeSinceStartup;
            }
        }
        if (isRecord7 && GhostChara.gameState == "playing")
        {
            elapsedTime7 += Time.deltaTime;
            if (elapsedTime7 >= recordDuration)
            {
                if (Input.GetAxisRaw("Horizontal") == 1)
                {
                    ghostData7.rightLists.Add(true);
                }
                else
                {
                    ghostData7.rightLists.Add(false);
                }

                if (Input.GetAxisRaw("Horizontal") == -1)
                {
                    ghostData7.leftLists.Add(true);
                }
                else
                {
                    ghostData7.leftLists.Add(false);
                }
                elapsedTime7 = 0f;
                if (ghostData7.rightLists.Count >= maxDataNum)
                {
                    StopRecord7();
                }
            }
            if (Input.GetButtonDown("Jump"))
            {
                ghostData7.jumpLists.Add(Time.realtimeSinceStartup - startTime7);
                startTime7 = Time.realtimeSinceStartup;
            }
        }
        if (isRecord8 && GhostChara.gameState == "playing")
        {
            elapsedTime8 += Time.deltaTime;
            if (elapsedTime8 >= recordDuration)
            {
                if (Input.GetAxisRaw("Horizontal") == 1)
                {
                    ghostData8.rightLists.Add(true);
                }
                else
                {
                    ghostData8.rightLists.Add(false);
                }

                if (Input.GetAxisRaw("Horizontal") == -1)
                {
                    ghostData8.leftLists.Add(true);
                }
                else
                {
                    ghostData8.leftLists.Add(false);
                }
                elapsedTime8 = 0f;
                if (ghostData8.rightLists.Count >= maxDataNum)
                {
                    StopRecord8();
                }
            }
            if (Input.GetButtonDown("Jump"))
            {
                ghostData8.jumpLists.Add(Time.realtimeSinceStartup - startTime8);
                startTime8 = Time.realtimeSinceStartup;
            }
        }
        if (isRecord9 && GhostChara.gameState == "playing")
        {
            elapsedTime9 += Time.deltaTime;
            if (elapsedTime9 >= recordDuration)
            {
                if (Input.GetAxisRaw("Horizontal") == 1)
                {
                    ghostData9.rightLists.Add(true);
                }
                else
                {
                    ghostData9.rightLists.Add(false);
                }

                if (Input.GetAxisRaw("Horizontal") == -1)
                {
                    ghostData9.leftLists.Add(true);
                }
                else
                {
                    ghostData9.leftLists.Add(false);
                }
                elapsedTime9 = 0f;
                if (ghostData9.rightLists.Count >= maxDataNum)
                {
                    StopRecord9();
                }
            }
            if (Input.GetButtonDown("Jump"))
            {
                ghostData9.jumpLists.Add(Time.realtimeSinceStartup - startTime9);
                startTime9 = Time.realtimeSinceStartup;
            }
        }
        if (isRecord10 && GhostChara.gameState == "playing")
        {
            elapsedTime10 += Time.deltaTime;
            if (elapsedTime10 >= recordDuration)
            {
                if (Input.GetAxisRaw("Horizontal") == 1)
                {
                    ghostData10.rightLists.Add(true);
                }
                else
                {
                    ghostData10.rightLists.Add(false);
                }

                if (Input.GetAxisRaw("Horizontal") == -1)
                {
                    ghostData10.leftLists.Add(true);
                }
                else
                {
                    ghostData10.leftLists.Add(false);
                }
                elapsedTime10 = 0f;
                if (ghostData10.rightLists.Count >= maxDataNum)
                {
                    StopRecord10();
                }
            }
            if (Input.GetButtonDown("Jump"))
            {
                ghostData10.jumpLists.Add(Time.realtimeSinceStartup - startTime10);
                startTime10 = Time.realtimeSinceStartup;
            }
        }
    }
    //　キャラクターデータの保存
    public void StartRecord()
    {
        //　保存する時はゴーストの再生を停止
        StopGhost();
        isRecord = true;
        elapsedTime = 0f;
        ghostData = new GhostData();
        startTime = Time.realtimeSinceStartup;
        Debug.Log("StartRecord");
    }
    public void StartRecord2()
    {
        StopGhost2();
        isRecord2 = true;
        elapsedTime2 = 0f;
        ghostData2 = new GhostData2();
        startTime2 = Time.realtimeSinceStartup;
    }
    public void StartRecord3()
    {
        StopGhost3();
        isRecord3 = true;
        elapsedTime3 = 0f;
        ghostData3 = new GhostData3();
        startTime3 = Time.realtimeSinceStartup;
    }
    public void StartRecord4()
    {
        StopGhost4();
        isRecord4 = true;
        elapsedTime4 = 0f;
        ghostData4 = new GhostData4();
        startTime4 = Time.realtimeSinceStartup;
    }
    public void StartRecord5()
    {
        StopGhost5();
        isRecord5 = true;
        elapsedTime5 = 0f;
        ghostData5 = new GhostData5();
        startTime5 = Time.realtimeSinceStartup;
    }
    public void StartRecord6()
    {
        StopGhost6();
        isRecord6 = true;
        elapsedTime6 = 0f;
        ghostData6 = new GhostData6();
        startTime6 = Time.realtimeSinceStartup;
    }
    public void StartRecord7()
    {
        StopGhost7();
        isRecord7 = true;
        elapsedTime7 = 0f;
        ghostData7 = new GhostData7();
        startTime7 = Time.realtimeSinceStartup;
    }
    public void StartRecord8()
    {
        StopGhost8();
        isRecord8 = true;
        elapsedTime8 = 0f;
        ghostData8 = new GhostData8();
        startTime8 = Time.realtimeSinceStartup;
    }
    public void StartRecord9()
    {
        StopGhost9();
        isRecord9 = true;
        elapsedTime9 = 0f;
        ghostData9 = new GhostData9();
        startTime9 = Time.realtimeSinceStartup;
    }
    public void StartRecord10()
    {
        StopGhost10();
        isRecord10 = true;
        elapsedTime10 = 0f;
        ghostData10 = new GhostData10();
        startTime10 = Time.realtimeSinceStartup;
    }
    //　キャラクターデータの保存の停止
    public void StopRecord()
    {
        ghostData.rightLists.Add(false);
        ghostData.leftLists.Add(false);
        isRecord = false;
        Debug.Log("StopRecord");
    }
    public void StopRecord2()
    {
        ghostData2.rightLists.Add(false);
        ghostData2.leftLists.Add(false);
        isRecord2 = false;
    }
    public void StopRecord3()
    {
        ghostData3.rightLists.Add(false);
        ghostData3.leftLists.Add(false);
        isRecord3 = false;
    }
    public void StopRecord4()
    {
        ghostData4.rightLists.Add(false);
        ghostData4.leftLists.Add(false);
        isRecord4 = false;
    }
    public void StopRecord5()
    {
        ghostData5.rightLists.Add(false);
        ghostData5.leftLists.Add(false);
        isRecord5 = false;
    }
    public void StopRecord6()
    {
        ghostData6.rightLists.Add(false);
        ghostData6.leftLists.Add(false);
        isRecord6 = false;
    }
    public void StopRecord7()
    {
        ghostData7.rightLists.Add(false);
        ghostData7.leftLists.Add(false);
        isRecord7 = false;
    }
    public void StopRecord8()
    {
        ghostData8.rightLists.Add(false);
        ghostData8.leftLists.Add(false);
        isRecord8 = false;
    }
    public void StopRecord9()
    {
        ghostData9.rightLists.Add(false);
        ghostData9.leftLists.Add(false);
        isRecord9 = false;
    }
    public void StopRecord10()
    {
        ghostData10.rightLists.Add(false);
        ghostData10.leftLists.Add(false);
        isRecord10 = false;
    }
    //　ゴーストの再生ボタンを押した時の処理
    public void StartGhost()
    {
        Debug.Log("StartGhost");
        if (ghostData == null)
        {
            Debug.Log("ゴーストデータがありません");
        }
        else
        {
            isPlayBack = true;
            ghost.SetActive(true);
            StartCoroutine(PlayBack());
            StartCoroutine(PlayBackJump());
        }
    }
    public void StartGhost2()
    {
        if (ghostData2 != null)
        {
            isPlayBack2 = true;
            ghost2.SetActive(true);
            StartCoroutine(PlayBack2());
            StartCoroutine(PlayBackJump2());
        }
    }
    public void StartGhost3()
    {
        if (ghostData3 != null)
        {
            isPlayBack3 = true;
            ghost3.SetActive(true);
            StartCoroutine(PlayBack3());
            StartCoroutine(PlayBackJump3());
        }
    }
    public void StartGhost4()
    {
        if (ghostData4 != null)
        {
            isPlayBack4 = true;
            ghost4.SetActive(true);
            StartCoroutine(PlayBack4());
            StartCoroutine(PlayBackJump4());
        }
    }
    public void StartGhost5()
    {
        if (ghostData5 != null)
        {
            isPlayBack5 = true;
            ghost5.SetActive(true);
            StartCoroutine(PlayBack5());
            StartCoroutine(PlayBackJump5());
        }
    }
    public void StartGhost6()
    {
        if (ghostData6 != null)
        {
            isPlayBack6 = true;
            ghost6.SetActive(true);
            StartCoroutine(PlayBack6());
            StartCoroutine(PlayBackJump6());
        }
    }
    public void StartGhost7()
    {
        if (ghostData7 != null)
        {
            isPlayBack7 = true;
            ghost7.SetActive(true);
            StartCoroutine(PlayBack7());
            StartCoroutine(PlayBackJump7());
        }
    }
    public void StartGhost8()
    {
        if (ghostData8 != null)
        {
            isRecord8 = false;
            isPlayBack8 = true;
            ghost8.SetActive(true);
            StartCoroutine(PlayBack8());
            StartCoroutine(PlayBackJump8());
        }
    }
    public void StartGhost9()
    {
        if (ghostData9 != null)
        {
            isPlayBack9 = true;
            ghost9.SetActive(true);
            StartCoroutine(PlayBack9());
            StartCoroutine(PlayBackJump9());
        }
    }
    public void StartGhost10()
    {
        if (ghostData10 != null)
        {
            isRecord10 = false;
            isPlayBack10 = true;
            ghost10.SetActive(true);
            StartCoroutine(PlayBack10());
            StartCoroutine(PlayBackJump10());
        }
    }
    //　ゴーストの停止
    public void StopGhost()
    {
        StopCoroutine(PlayBack());
        isPlayBack = false;
    }
    public void StopGhost2()
    {
        StopCoroutine(PlayBack2());
        isPlayBack2 = false;
    }
    public void StopGhost3()
    {
        StopCoroutine(PlayBack3());
        isPlayBack3 = false;
    }
    public void StopGhost4()
    {
        StopCoroutine(PlayBack4());
        isPlayBack4 = false;
    }
    public void StopGhost5()
    {
        StopCoroutine(PlayBack5());
        isPlayBack5 = false;
    }
    public void StopGhost6()
    {
        StopCoroutine(PlayBack6());
        isPlayBack6 = false;
    }
    public void StopGhost7()
    {
        StopCoroutine(PlayBack7());
        isPlayBack7 = false;
    }
    public void StopGhost8()
    {
        StopCoroutine(PlayBack8());
        isPlayBack8 = false;
    }
    public void StopGhost9()
    {
        StopCoroutine(PlayBack9());
        isPlayBack9 = false;
    }
    public void StopGhost10()
    {
        StopCoroutine(PlayBack10());
        isPlayBack10 = false;
    }
    //　ゴーストの再生
    IEnumerator PlayBack()
    {
        var i = 0;
        while (isPlayBack)
        {
            if (isLoopReset)
            {
                yield return null;
            }
            yield return new WaitForSeconds(recordDuration);
            if (ghostData.rightLists[i])
            {
                rbody.velocity = new Vector2(ghostChara.speed * 1, rbody.velocity.y);
                ghost.transform.localScale = new Vector2(1, 1);
            }
            if (ghostData.leftLists[i])
            {
                rbody.velocity = new Vector2(ghostChara.speed * -1, rbody.velocity.y);
                ghost.transform.localScale = new Vector2(-1, 1);
            }
            else if (ghostData.rightLists[i] == false && ghostData.leftLists[i] == false)
            {
                rbody.velocity = new Vector2(0, rbody.velocity.y);
            }
            i++;
            if (i >= ghostData.rightLists.Count)
            {
                yield return new WaitForSeconds(waitTime);
                isLoopReset = true;
                i = 0;
            }
        }
    }
    IEnumerator PlayBack2()
    {
        var i = 0;
        while (isPlayBack2)
        {
            if (isLoopReset2)
            {
                yield return null;
            }
            yield return new WaitForSeconds(recordDuration);
            if (ghostData2.rightLists[i])
            {
                rbody2.velocity = new Vector2(ghostChara.speed * 1, rbody2.velocity.y);
                ghost2.transform.localScale = new Vector2(1, 1);
            }
            if (ghostData2.leftLists[i])
            {
                rbody2.velocity = new Vector2(ghostChara.speed * -1, rbody2.velocity.y);
                ghost2.transform.localScale = new Vector2(-1, 1);
            }
            else if (ghostData2.rightLists[i] == false && ghostData2.leftLists[i] == false)
            {
                rbody2.velocity = new Vector2(0, rbody2.velocity.y);
            }
            i++;
            if (i >= ghostData2.rightLists.Count)
            {
                yield return new WaitForSeconds(waitTime);
                isLoopReset2 = true;
                i = 0;
            }
        }
    }
    IEnumerator PlayBack3()
    {
        var i = 0;
        while (isPlayBack3)
        {
            if (isLoopReset3)
            {
                yield return null;
            }
            yield return new WaitForSeconds(recordDuration);
            if (ghostData3.rightLists[i])
            {
                rbody3.velocity = new Vector2(ghostChara.speed * 1, rbody3.velocity.y);
                ghost3.transform.localScale = new Vector2(1, 1);
            }
            if (ghostData3.leftLists[i])
            {
                rbody3.velocity = new Vector2(ghostChara.speed * -1, rbody3.velocity.y);
                ghost3.transform.localScale = new Vector2(-1, 1);
            }
            else if (ghostData3.rightLists[i] == false && ghostData3.leftLists[i] == false)
            {
                rbody3.velocity = new Vector2(0, rbody3.velocity.y);
            }
            i++;
            if (i >= ghostData3.rightLists.Count)
            {
                yield return new WaitForSeconds(waitTime);
                isLoopReset3 = true;
                i = 0;
            }
        }
    }
    IEnumerator PlayBack4()
    {
        var i = 0;
        while (isPlayBack4)
        {
            if (isLoopReset4)
            {
                yield return null;
            }
            yield return new WaitForSeconds(recordDuration);
            if (ghostData4.rightLists[i])
            {
                rbody4.velocity = new Vector2(ghostChara.speed * 1, rbody4.velocity.y);
                ghost4.transform.localScale = new Vector2(1, 1);
            }
            if (ghostData4.leftLists[i])
            {
                rbody4.velocity = new Vector2(ghostChara.speed * -1, rbody4.velocity.y);
                ghost4.transform.localScale = new Vector2(-1, 1);
            }
            else if (ghostData4.rightLists[i] == false && ghostData4.leftLists[i] == false)
            {
                rbody4.velocity = new Vector2(0, rbody4.velocity.y);
            }
            i++;
            if (i >= ghostData4.rightLists.Count)
            {
                yield return new WaitForSeconds(waitTime);
                isLoopReset4 = true;
                i = 0;
            }
        }
    }
    IEnumerator PlayBack5()
    {
        var i = 0;
        while (isPlayBack5)
        {
            if (isLoopReset5)
            {
                yield return null;
            }
            yield return new WaitForSeconds(recordDuration);
            if (ghostData5.rightLists[i])
            {
                rbody5.velocity = new Vector2(ghostChara.speed * 1, rbody5.velocity.y);
                ghost5.transform.localScale = new Vector2(1, 1);
            }
            if (ghostData5.leftLists[i])
            {
                rbody5.velocity = new Vector2(ghostChara.speed * -1, rbody5.velocity.y);
                ghost5.transform.localScale = new Vector2(-1, 1);
            }
            else if (ghostData5.rightLists[i] == false && ghostData5.leftLists[i] == false)
            {
                rbody5.velocity = new Vector2(0, rbody5.velocity.y);
            }
            i++;
            if (i >= ghostData5.rightLists.Count)
            {
                yield return new WaitForSeconds(waitTime);
                isLoopReset5 = true;
                i = 0;
            }
        }
    }
    IEnumerator PlayBack6()
    {
        var i = 0;
        while (isPlayBack6)
        {
            if (isLoopReset6)
            {
                yield return null;
            }
            yield return new WaitForSeconds(recordDuration);
            if (ghostData6.rightLists[i])
            {
                rbody6.velocity = new Vector2(ghostChara.speed * 1, rbody6.velocity.y);
                ghost6.transform.localScale = new Vector2(1, 1);
            }
            if (ghostData6.leftLists[i])
            {
                rbody6.velocity = new Vector2(ghostChara.speed * -1, rbody6.velocity.y);
                ghost6.transform.localScale = new Vector2(-1, 1);
            }
            else if (ghostData6.rightLists[i] == false && ghostData6.leftLists[i] == false)
            {
                rbody6.velocity = new Vector2(0, rbody6.velocity.y);
            }
            i++;
            if (i >= ghostData6.rightLists.Count)
            {
                yield return new WaitForSeconds(waitTime);
                isLoopReset6 = true;
                i = 0;
            }
        }
    }
    IEnumerator PlayBack7()
    {
        var i = 0;
        while (isPlayBack7)
        {
            if (isLoopReset7)
            {
                yield return null;
            }
            yield return new WaitForSeconds(recordDuration);
            if (ghostData7.rightLists[i])
            {
                rbody7.velocity = new Vector2(ghostChara.speed * 1, rbody7.velocity.y);
                ghost7.transform.localScale = new Vector2(1, 1);
            }
            if (ghostData7.leftLists[i])
            {
                rbody7.velocity = new Vector2(ghostChara.speed * -1, rbody7.velocity.y);
                ghost7.transform.localScale = new Vector2(-1, 1);
            }
            else if (ghostData7.rightLists[i] == false && ghostData7.leftLists[i] == false)
            {
                rbody7.velocity = new Vector2(0, rbody7.velocity.y);
            }
            i++;
            if (i >= ghostData7.rightLists.Count)
            {
                yield return new WaitForSeconds(waitTime);
                isLoopReset7 = true;
                i = 0;
            }
        }
    }
    IEnumerator PlayBack8()
    {
        var i = 0;
        while (isPlayBack8)
        {
            if (isLoopReset8)
            {
                yield return null;
            }
            yield return new WaitForSeconds(recordDuration);
            if (ghostData8.rightLists[i])
            {
                rbody8.velocity = new Vector2(ghostChara.speed * 1, rbody8.velocity.y);
                ghost8.transform.localScale = new Vector2(1, 1);
            }
            if (ghostData8.leftLists[i])
            {
                rbody8.velocity = new Vector2(ghostChara.speed * -1, rbody8.velocity.y);
                ghost8.transform.localScale = new Vector2(-1, 1);
            }
            else if (ghostData8.rightLists[i] == false && ghostData8.leftLists[i] == false)
            {
                rbody8.velocity = new Vector2(0, rbody8.velocity.y);
            }
            i++;
            if (i >= ghostData8.rightLists.Count)
            {
                yield return new WaitForSeconds(waitTime);
                isLoopReset8 = true;
                i = 0;
            }
        }
    }
    IEnumerator PlayBack9()
    {
        var i = 0;
        while (isPlayBack9)
        {
            if (isLoopReset9)
            {
                yield return null;
            }
            yield return new WaitForSeconds(recordDuration);
            if (ghostData9.rightLists[i])
            {
                rbody9.velocity = new Vector2(ghostChara.speed * 1, rbody9.velocity.y);
                ghost9.transform.localScale = new Vector2(1, 1);
            }
            if (ghostData9.leftLists[i])
            {
                rbody9.velocity = new Vector2(ghostChara.speed * -1, rbody9.velocity.y);
                ghost9.transform.localScale = new Vector2(-1, 1);
            }
            else if (ghostData9.rightLists[i] == false && ghostData9.leftLists[i] == false)
            {
                rbody9.velocity = new Vector2(0, rbody9.velocity.y);
            }
            i++;
            if (i >= ghostData9.rightLists.Count)
            {
                yield return new WaitForSeconds(waitTime);
                isLoopReset9 = true;
                i = 0;
            }
        }
    }
    IEnumerator PlayBack10()
    {
        var i = 0;
        while (isPlayBack10)
        {
            if (isLoopReset10)
            {
                yield return null;
            }
            yield return new WaitForSeconds(recordDuration);
            if (ghostData10.rightLists[i])
            {
                rbody10.velocity = new Vector2(ghostChara.speed * 1, rbody10.velocity.y);
                ghost10.transform.localScale = new Vector2(1, 1);
            }
            if (ghostData10.leftLists[i])
            {
                rbody10.velocity = new Vector2(ghostChara.speed * -1, rbody10.velocity.y);
                ghost10.transform.localScale = new Vector2(-1, 1);
            }
            else if (ghostData10.rightLists[i] == false && ghostData10.leftLists[i] == false)
            {
                rbody10.velocity = new Vector2(0, rbody10.velocity.y);
            }
            i++;
            if (i >= ghostData10.rightLists.Count)
            {
                yield return new WaitForSeconds(waitTime);
                isLoopReset10 = true;
                i = 0;
            }
        }
    }
    //　ゴーストのアニメーションの再生
    IEnumerator PlayBackJump()
    {
        Debug.Log("ジャンプデータ: " + ghostData.jumpLists.Count);
        //ghostData.jumpLists[0] -= 0.33f;
        var i = 0;
        while (isPlayBack)
        {
            //　キャラクターの位置や角度の終了を待ってからアニメーションデータも最初に戻す
            if (isLoopReset)
            { 
                i = 0;
                isLoopReset = false;
            }
            //　データ数を超えていなければ
            if (i < ghostData.jumpLists.Count)
            {
                yield return new WaitForSeconds(ghostData.jumpLists[i]);
                //地上判定
                onGround = Physics2D.Linecast(ghost.transform.position - (ghost.transform.up * 0.56f) + (ghost.transform.right * 0.5f), ghost.transform.position - (ghost.transform.up * 0.56f) - (ghost.transform.right * 0.5f), groundLayer);
                if (onGround)
                {
                    Vector2 jumpPw = new Vector2(0, ghostChara.jump);
                    rbody.AddForce(jumpPw, ForceMode2D.Impulse);
                    
                Debug.Log("ジャンプ中!!!!!");
                }
                i++;
                //　それ以外はnullを返す
            }
            else
            {
                yield return null;
            }
        }
    }
    IEnumerator PlayBackJump2()
    {
        //ghostData2.jumpLists[0] -= 0.33f;
        var i = 0;
        while (isPlayBack2)
        {
            if (isLoopReset2)
            {
                i = 0;
                isLoopReset2 = false;
            }
            if (i < ghostData2.jumpLists.Count)
            {
                yield return new WaitForSeconds(ghostData2.jumpLists[i]);
                onGround2 = Physics2D.Linecast(ghost2.transform.position - (ghost2.transform.up * 0.56f) + (ghost.transform.right * 0.5f), ghost2.transform.position - (ghost2.transform.up * 0.56f) - (ghost.transform.right * 0.5f), groundLayer);
                if (onGround2)
                {
                    Vector2 jumpPw = new Vector2(0, ghostChara.jump);
                    rbody2.AddForce(jumpPw, ForceMode2D.Impulse);
                }
                i++;
            }
            else
            {
                yield return null;
            }
        }
    }
    IEnumerator PlayBackJump3()
    {
        //ghostData3.jumpLists[0] -= 0.33f;
        var i = 0;
        while (isPlayBack3)
        {
            if (isLoopReset3)
            {
                i = 0;
                isLoopReset3 = false;
            }
            if (i < ghostData3.jumpLists.Count)
            {
                yield return new WaitForSeconds(ghostData3.jumpLists[i]);
                onGround3 = Physics2D.Linecast(ghost3.transform.position - (ghost3.transform.up * 0.56f) + (ghost.transform.right * 0.5f), ghost3.transform.position - (ghost3.transform.up * 0.56f) - (ghost.transform.right * 0.5f), groundLayer);
                if (onGround3)
                {
                    Vector2 jumpPw = new Vector2(0, ghostChara.jump);
                    rbody3.AddForce(jumpPw, ForceMode2D.Impulse);
                }
                i++;
            }
            else
            {
                yield return null;
            }
        }
    }
    IEnumerator PlayBackJump4()
    {
        //ghostData4.jumpLists[0] -= 0.33f;
        var i = 0;
        while (isPlayBack4)
        {
            if (isLoopReset4)
            {
                i = 0;
                isLoopReset4 = false;
            }
            if (i < ghostData4.jumpLists.Count)
            {
                yield return new WaitForSeconds(ghostData4.jumpLists[i]);
                onGround4 = Physics2D.Linecast(ghost4.transform.position - (ghost4.transform.up * 0.56f) + (ghost.transform.right * 0.5f), ghost4.transform.position - (ghost4.transform.up * 0.56f) - (ghost.transform.right * 0.5f), groundLayer);
                if (onGround4)
                {
                    Vector2 jumpPw = new Vector2(0, ghostChara.jump);
                    rbody4.AddForce(jumpPw, ForceMode2D.Impulse);
                }
                i++;
            }
            else
            {
                yield return null;
            }
        }
    }
    IEnumerator PlayBackJump5()
    {
        //ghostData5.jumpLists[0] -= 0.33f;
        var i = 0;
        while (isPlayBack5)
        {
            if (isLoopReset5)
            {
                i = 0;
                isLoopReset5 = false;
            }
            if (i < ghostData5.jumpLists.Count)
            {
                yield return new WaitForSeconds(ghostData5.jumpLists[i]);
                onGround5 = Physics2D.Linecast(ghost5.transform.position - (ghost5.transform.up * 0.56f) + (ghost.transform.right * 0.5f), ghost5.transform.position - (ghost5.transform.up * 0.56f) - (ghost.transform.right * 0.5f), groundLayer);
                if (onGround5)
                {
                    Vector2 jumpPw = new Vector2(0, ghostChara.jump);
                    rbody5.AddForce(jumpPw, ForceMode2D.Impulse);
                }
                i++;
            }
            else
            {
                yield return null;
            }
        }
    }
    IEnumerator PlayBackJump6()
    {
        //ghostData6.jumpLists[0] -= 0.33f;
        var i = 0;
        while (isPlayBack6)
        {
            if (isLoopReset6)
            {
                i = 0;
                isLoopReset6 = false;
            }
            if (i < ghostData6.jumpLists.Count)
            {
                yield return new WaitForSeconds(ghostData6.jumpLists[i]);
                onGround6 = Physics2D.Linecast(ghost6.transform.position - (ghost6.transform.up * 0.56f) + (ghost.transform.right * 0.5f), ghost6.transform.position - (ghost6.transform.up * 0.56f) - (ghost.transform.right * 0.5f), groundLayer);
                if (onGround6)
                {
                    Vector2 jumpPw = new Vector2(0, ghostChara.jump);
                    rbody6.AddForce(jumpPw, ForceMode2D.Impulse);
                }
                i++;
            }
            else
            {
                yield return null;
            }
        }
    }
    IEnumerator PlayBackJump7()
    {
        //ghostData7.jumpLists[0] -= 0.33f;
        var i = 0;
        while (isPlayBack7)
        {
            if (isLoopReset7)
            {
                i = 0;
                isLoopReset7 = false;
            }
            if (i < ghostData7.jumpLists.Count)
            {
                yield return new WaitForSeconds(ghostData7.jumpLists[i]);
                onGround7 = Physics2D.Linecast(ghost7.transform.position - (ghost7.transform.up * 0.56f) + (ghost.transform.right * 0.5f), ghost7.transform.position - (ghost7.transform.up * 0.56f) - (ghost.transform.right * 0.5f), groundLayer);
                if (onGround7)
                {
                    Vector2 jumpPw = new Vector2(0, ghostChara.jump);
                    rbody7.AddForce(jumpPw, ForceMode2D.Impulse);
                }
                i++;
            }
            else
            {
                yield return null;
            }
        }
    }
    IEnumerator PlayBackJump8()
    {
        //ghostData8.jumpLists[0] -= 0.33f;
        var i = 0;
        while (isPlayBack8)
        {
            if (isLoopReset8)
            {
                i = 0;
                isLoopReset8 = false;
            }
            if (i < ghostData8.jumpLists.Count)
            {
                yield return new WaitForSeconds(ghostData8.jumpLists[i]);
                onGround8 = Physics2D.Linecast(ghost8.transform.position - (ghost8.transform.up * 0.56f) + (ghost.transform.right * 0.5f), ghost8.transform.position - (ghost8.transform.up * 0.56f) - (ghost.transform.right * 0.5f), groundLayer);
                if (onGround8)
                {
                    Vector2 jumpPw = new Vector2(0, ghostChara.jump);
                    rbody8.AddForce(jumpPw, ForceMode2D.Impulse);
                }
                i++;
            }
            else
            {
                yield return null;
            }
        }
    }
    IEnumerator PlayBackJump9()
    {
        //ghostData9.jumpLists[0] -= 0.33f;
        var i = 0;
        while (isPlayBack9)
        {
            if (isLoopReset9)
            {
                i = 0;
                isLoopReset9 = false;
            }
            if (i < ghostData9.jumpLists.Count)
            {
                yield return new WaitForSeconds(ghostData9.jumpLists[i]);
                onGround9 = Physics2D.Linecast(ghost9.transform.position - (ghost9.transform.up * 0.56f) + (ghost.transform.right * 0.5f), ghost9.transform.position - (ghost9.transform.up * 0.56f) - (ghost.transform.right * 0.5f), groundLayer);
                if (onGround9)
                {
                    Vector2 jumpPw = new Vector2(0, ghostChara.jump);
                    rbody9.AddForce(jumpPw, ForceMode2D.Impulse);
                }
                i++;
            }
            else
            {
                yield return null;
            }
        }
    }
    IEnumerator PlayBackJump10()
    {
        //ghostData10.jumpLists[0] -= 0.33f;
        var i = 0;
        while (isPlayBack10)
        {
            if (isLoopReset10)
            {
                i = 0;
                isLoopReset10 = false;
            }
            if (i < ghostData10.jumpLists.Count)
            {
                yield return new WaitForSeconds(ghostData10.jumpLists[i]);
                onGround10 = Physics2D.Linecast(ghost10.transform.position - (ghost10.transform.up * 0.56f) + (ghost.transform.right * 0.5f), ghost10.transform.position - (ghost10.transform.up * 0.56f) - (ghost.transform.right * 0.5f), groundLayer);
                if (onGround10)
                {
                    Vector2 jumpPw = new Vector2(0, ghostChara.jump);
                    rbody10.AddForce(jumpPw, ForceMode2D.Impulse);
                }
                i++;
            }
            else
            {
                yield return null;
            }
        }
    }
    void OnApplicationQuit()
    {
        Debug.Log("アプリケーション終了");
    }
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
            ghost.transform.position = new Vector2(xpos, ypos);
            firstFlag = false;
            secondFlag = true;

            StopRecord();

            StartGhost();
            StartRecord2();
        }
        else if (secondFlag == true)
        {
            ghost.transform.position = new Vector2(xpos, ypos);
            ghost2.transform.position = new Vector2(xpos, ypos);

            StopRecord2();

            secondFlag = false;
            thirdFlag = true;

            StartGhost();
            StartGhost2();
            StartRecord3();
        }
        else if (thirdFlag == true)
        {
            ghost.transform.position = new Vector2(xpos, ypos);
            ghost2.transform.position = new Vector2(xpos, ypos);
            ghost3.transform.position = new Vector2(xpos, ypos);

            StopRecord3();

            thirdFlag = false;
            fourthFlag = true;

            StartGhost();
            StartGhost2();
            StartGhost3();
            StartRecord4();
        }
        else if (fourthFlag == true)
        {
            ghost.transform.position = new Vector2(xpos, ypos);
            ghost2.transform.position = new Vector2(xpos, ypos);
            ghost3.transform.position = new Vector2(xpos, ypos);
            ghost4.transform.position = new Vector2(xpos, ypos);

            StopRecord4();

            fourthFlag = false;
            fifthFlag = true;

            StartGhost();
            StartGhost2();
            StartGhost3();
            StartGhost4();
            StartRecord5();
        }
        else if (fifthFlag == true)
        {
            ghost.transform.position = new Vector2(xpos, ypos);
            ghost2.transform.position = new Vector2(xpos, ypos);
            ghost3.transform.position = new Vector2(xpos, ypos);
            ghost4.transform.position = new Vector2(xpos, ypos);
            ghost5.transform.position = new Vector2(xpos, ypos);

            StopRecord5();

            fifthFlag = false;
            sixthFlag = true;

            StartGhost();
            StartGhost2();
            StartGhost3();
            StartGhost4();
            StartGhost5();
            StartRecord6();
        }
        else if (sixthFlag == true)
        {
            ghost.transform.position = new Vector2(xpos, ypos);
            ghost2.transform.position = new Vector2(xpos, ypos);
            ghost3.transform.position = new Vector2(xpos, ypos);
            ghost4.transform.position = new Vector2(xpos, ypos);
            ghost5.transform.position = new Vector2(xpos, ypos);
            ghost6.transform.position = new Vector2(xpos, ypos);

            StopRecord6();

            sixthFlag = false;
            seventhFlag = true;

            StartGhost();
            StartGhost2();
            StartGhost3();
            StartGhost4();
            StartGhost5();
            StartGhost6();
            StartRecord7();
        }
        else if (seventhFlag == true)
        {
            ghost.transform.position = new Vector2(xpos, ypos);
            ghost2.transform.position = new Vector2(xpos, ypos);
            ghost3.transform.position = new Vector2(xpos, ypos);
            ghost4.transform.position = new Vector2(xpos, ypos);
            ghost5.transform.position = new Vector2(xpos, ypos);
            ghost6.transform.position = new Vector2(xpos, ypos);
            ghost7.transform.position = new Vector2(xpos, ypos);

            StopRecord7();

            seventhFlag = false;
            eighthFlag = true;

            StartGhost();
            StartGhost2();
            StartGhost3();
            StartGhost4();
            StartGhost5();
            StartGhost6();
            StartGhost7();
            StartRecord8();
        }
        else if (eighthFlag == true)
        {
            ghost.transform.position = new Vector2(xpos, ypos);
            ghost2.transform.position = new Vector2(xpos, ypos);
            ghost3.transform.position = new Vector2(xpos, ypos);
            ghost4.transform.position = new Vector2(xpos, ypos);
            ghost5.transform.position = new Vector2(xpos, ypos);
            ghost6.transform.position = new Vector2(xpos, ypos);
            ghost7.transform.position = new Vector2(xpos, ypos);
            ghost8.transform.position = new Vector2(xpos, ypos);
            StopRecord8();

            eighthFlag = false;
            ninethFlag = true;

            StartGhost();
            StartGhost2();
            StartGhost3();
            StartGhost4();
            StartGhost5();
            StartGhost6();
            StartGhost7();
            StartGhost8();
            StartRecord9();
        }
        else if (ninethFlag == true)
        {
            ghost.transform.position = new Vector2(xpos, ypos);
            ghost2.transform.position = new Vector2(xpos, ypos);
            ghost3.transform.position = new Vector2(xpos, ypos);
            ghost4.transform.position = new Vector2(xpos, ypos);
            ghost5.transform.position = new Vector2(xpos, ypos);
            ghost6.transform.position = new Vector2(xpos, ypos);
            ghost7.transform.position = new Vector2(xpos, ypos);
            ghost8.transform.position = new Vector2(xpos, ypos);
            ghost9.transform.position = new Vector2(xpos, ypos);
            StopRecord9();

            ninethFlag = false;
            tenthFlag = true;

            StartGhost();
            StartGhost2();
            StartGhost3();
            StartGhost4();
            StartGhost5();
            StartGhost6();
            StartGhost7();
            StartGhost8();
            StartGhost9();
            StartRecord10();
        }
        else if (tenthFlag == true)
        {
            ghost.transform.position = new Vector2(xpos, ypos);
            ghost2.transform.position = new Vector2(xpos, ypos);
            ghost3.transform.position = new Vector2(xpos, ypos);
            ghost4.transform.position = new Vector2(xpos, ypos);
            ghost5.transform.position = new Vector2(xpos, ypos);
            ghost6.transform.position = new Vector2(xpos, ypos);
            ghost7.transform.position = new Vector2(xpos, ypos);
            ghost8.transform.position = new Vector2(xpos, ypos);
            ghost9.transform.position = new Vector2(xpos, ypos);
            ghost10.transform.position = new Vector2(xpos, ypos);

            StopRecord10();

            tenthFlag = false;
            FirstFlag = true;
            //eleventhFlag = true;

            StartGhost();
            StartGhost2();
            StartGhost3();
            StartGhost4();
            StartGhost5();
            StartGhost6();
            StartGhost7();
            StartGhost8();
            StartGhost9();
            StartGhost10();
            //StartRecord();
            //StartRecord11();
        }
        else if (FirstFlag == true)
        {
            ghost.transform.position = new Vector2(xpos, ypos);
            ghost2.transform.position = new Vector2(xpos, ypos);
            ghost3.transform.position = new Vector2(xpos, ypos);
            ghost4.transform.position = new Vector2(xpos, ypos);
            ghost5.transform.position = new Vector2(xpos, ypos);
            ghost6.transform.position = new Vector2(xpos, ypos);
            ghost7.transform.position = new Vector2(xpos, ypos);
            ghost8.transform.position = new Vector2(xpos, ypos);
            ghost9.transform.position = new Vector2(xpos, ypos);
            ghost10.transform.position = new Vector2(xpos, ypos);

            StopRecord();

            FirstFlag = false;
            SecondFlag = true;
            //eleventhFlag = true;

            StartGhost();
            StartGhost2();
            StartGhost3();
            StartGhost4();
            StartGhost5();
            StartGhost6();
            StartGhost7();
            StartGhost8();
            StartGhost9();
            StartGhost10();
        }
        else if (SecondFlag == true)
        {
            ghost.transform.position = new Vector2(xpos, ypos);
            ghost2.transform.position = new Vector2(xpos, ypos);
            ghost3.transform.position = new Vector2(xpos, ypos);
            ghost4.transform.position = new Vector2(xpos, ypos);
            ghost5.transform.position = new Vector2(xpos, ypos);
            ghost6.transform.position = new Vector2(xpos, ypos);
            ghost7.transform.position = new Vector2(xpos, ypos);
            ghost8.transform.position = new Vector2(xpos, ypos);
            ghost9.transform.position = new Vector2(xpos, ypos);
            ghost10.transform.position = new Vector2(xpos, ypos);

            StopRecord2();

            SecondFlag = false;
            ThirdFlag = true; 
            //eleventhFlag = true;

            StartGhost();
            StartGhost2();
            StartGhost3();
            StartGhost4();
            StartGhost5();
            StartGhost6();
            StartGhost7();
            StartGhost8();
            StartGhost9();
            StartGhost10();
        }
        else if (ThirdFlag == true)
        {
            ghost.transform.position = new Vector2(xpos, ypos);
            ghost2.transform.position = new Vector2(xpos, ypos);
            ghost3.transform.position = new Vector2(xpos, ypos);
            ghost4.transform.position = new Vector2(xpos, ypos);
            ghost5.transform.position = new Vector2(xpos, ypos);
            ghost6.transform.position = new Vector2(xpos, ypos);
            ghost7.transform.position = new Vector2(xpos, ypos);
            ghost8.transform.position = new Vector2(xpos, ypos);
            ghost9.transform.position = new Vector2(xpos, ypos);
            ghost10.transform.position = new Vector2(xpos, ypos);

            StopRecord3();

            ThirdFlag = false;
            FourthFlag = true;
            //eleventhFlag = true;

            StartGhost();
            StartGhost2();
            StartGhost3();
            StartGhost4();
            StartGhost5();
            StartGhost6();
            StartGhost7();
            StartGhost8();
            StartGhost9();
            StartGhost10();
        }
        else if (FourthFlag == true)
        {
            ghost.transform.position = new Vector2(xpos, ypos);
            ghost2.transform.position = new Vector2(xpos, ypos);
            ghost3.transform.position = new Vector2(xpos, ypos);
            ghost4.transform.position = new Vector2(xpos, ypos);
            ghost5.transform.position = new Vector2(xpos, ypos);
            ghost6.transform.position = new Vector2(xpos, ypos);
            ghost7.transform.position = new Vector2(xpos, ypos);
            ghost8.transform.position = new Vector2(xpos, ypos);
            ghost9.transform.position = new Vector2(xpos, ypos);
            ghost10.transform.position = new Vector2(xpos, ypos);

            StopRecord4();

            FourthFlag = false;
            FifthFlag = true;
            //eleventhFlag = true;

            StartGhost();
            StartGhost2();
            StartGhost3();
            StartGhost4();
            StartGhost5();
            StartGhost6();
            StartGhost7();
            StartGhost8();
            StartGhost9();
            StartGhost10();
        }
        else if (FifthFlag == true)
        {
            ghost.transform.position = new Vector2(xpos, ypos);
            ghost2.transform.position = new Vector2(xpos, ypos);
            ghost3.transform.position = new Vector2(xpos, ypos);
            ghost4.transform.position = new Vector2(xpos, ypos);
            ghost5.transform.position = new Vector2(xpos, ypos);
            ghost6.transform.position = new Vector2(xpos, ypos);
            ghost7.transform.position = new Vector2(xpos, ypos);
            ghost8.transform.position = new Vector2(xpos, ypos);
            ghost9.transform.position = new Vector2(xpos, ypos);
            ghost10.transform.position = new Vector2(xpos, ypos);

            StopRecord5();

            FifthFlag = false;
            SixthFlag = true;
            //eleventhFlag = true;

            StartGhost();
            StartGhost2();
            StartGhost3();
            StartGhost4();
            StartGhost5();
            StartGhost6();
            StartGhost7();
            StartGhost8();
            StartGhost9();
            StartGhost10();
        }
        else if (SixthFlag == true)
        {
            ghost.transform.position = new Vector2(xpos, ypos);
            ghost2.transform.position = new Vector2(xpos, ypos);
            ghost3.transform.position = new Vector2(xpos, ypos);
            ghost4.transform.position = new Vector2(xpos, ypos);
            ghost5.transform.position = new Vector2(xpos, ypos);
            ghost6.transform.position = new Vector2(xpos, ypos);
            ghost7.transform.position = new Vector2(xpos, ypos);
            ghost8.transform.position = new Vector2(xpos, ypos);
            ghost9.transform.position = new Vector2(xpos, ypos);
            ghost10.transform.position = new Vector2(xpos, ypos);

            StopRecord6();

            SixthFlag = false;
            SeventhFlag = true;
            //eleventhFlag = true;

            StartGhost();
            StartGhost2();
            StartGhost3();
            StartGhost4();
            StartGhost5();
            StartGhost6();
            StartGhost7();
            StartGhost8();
            StartGhost9();
            StartGhost10();
        }
        else if (SeventhFlag == true)
        {
            ghost.transform.position = new Vector2(xpos, ypos);
            ghost2.transform.position = new Vector2(xpos, ypos);
            ghost3.transform.position = new Vector2(xpos, ypos);
            ghost4.transform.position = new Vector2(xpos, ypos);
            ghost5.transform.position = new Vector2(xpos, ypos);
            ghost6.transform.position = new Vector2(xpos, ypos);
            ghost7.transform.position = new Vector2(xpos, ypos);
            ghost8.transform.position = new Vector2(xpos, ypos);
            ghost9.transform.position = new Vector2(xpos, ypos);
            ghost10.transform.position = new Vector2(xpos, ypos);

            StopRecord7();

            SeventhFlag = false;
            EighthFlag = true;
            //eleventhFlag = true;

            StartGhost();
            StartGhost2();
            StartGhost3();
            StartGhost4();
            StartGhost5();
            StartGhost6();
            StartGhost7();
            StartGhost8();
            StartGhost9();
            StartGhost10();
        }
        else if (EighthFlag == true)
        {
            ghost.transform.position = new Vector2(xpos, ypos);
            ghost2.transform.position = new Vector2(xpos, ypos);
            ghost3.transform.position = new Vector2(xpos, ypos);
            ghost4.transform.position = new Vector2(xpos, ypos);
            ghost5.transform.position = new Vector2(xpos, ypos);
            ghost6.transform.position = new Vector2(xpos, ypos);
            ghost7.transform.position = new Vector2(xpos, ypos);
            ghost8.transform.position = new Vector2(xpos, ypos);
            ghost9.transform.position = new Vector2(xpos, ypos);
            ghost10.transform.position = new Vector2(xpos, ypos);

            StopRecord8();

            EighthFlag = false;
            NinethFlag = true;
            //eleventhFlag = true;

            StartGhost();
            StartGhost2();
            StartGhost3();
            StartGhost4();
            StartGhost5();
            StartGhost6();
            StartGhost7();
            StartGhost8();
            StartGhost9();
            StartGhost10();
        }
        else if (NinethFlag == true)
        {
            ghost.transform.position = new Vector2(xpos, ypos);
            ghost2.transform.position = new Vector2(xpos, ypos);
            ghost3.transform.position = new Vector2(xpos, ypos);
            ghost4.transform.position = new Vector2(xpos, ypos);
            ghost5.transform.position = new Vector2(xpos, ypos);
            ghost6.transform.position = new Vector2(xpos, ypos);
            ghost7.transform.position = new Vector2(xpos, ypos);
            ghost8.transform.position = new Vector2(xpos, ypos);
            ghost9.transform.position = new Vector2(xpos, ypos);
            ghost10.transform.position = new Vector2(xpos, ypos);

            StopRecord9();

            NinethFlag = false;
            TenthFlag = true;
            //eleventhFlag = true;

            StartGhost();
            StartGhost2();
            StartGhost3();
            StartGhost4();
            StartGhost5();
            StartGhost6();
            StartGhost7();
            StartGhost8();
            StartGhost9();
            StartGhost10();
        }
        else if (TenthFlag == true)
        {
            ghost.transform.position = new Vector2(xpos, ypos);
            ghost2.transform.position = new Vector2(xpos, ypos);
            ghost3.transform.position = new Vector2(xpos, ypos);
            ghost4.transform.position = new Vector2(xpos, ypos);
            ghost5.transform.position = new Vector2(xpos, ypos);
            ghost6.transform.position = new Vector2(xpos, ypos);
            ghost7.transform.position = new Vector2(xpos, ypos);
            ghost8.transform.position = new Vector2(xpos, ypos);
            ghost9.transform.position = new Vector2(xpos, ypos);
            ghost10.transform.position = new Vector2(xpos, ypos);

            StopRecord10();

            tenthFlag = false;
            FirstFlag = true;
            //eleventhFlag = true;

            StartGhost();
            StartGhost2();
            StartGhost3();
            StartGhost4();
            StartGhost5();
            StartGhost6();
            StartGhost7();
            StartGhost8();
            StartGhost9();
            StartGhost10();
        }
    }
}