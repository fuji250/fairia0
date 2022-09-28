using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Recorder : MonoBehaviour
{
    //�@����L�����N�^�[
    [SerializeField]
    private GhostChara ghostChara;
    //�@���݋L�����Ă��邩�ǂ���
    private bool isRecord;
    //�@�ۑ�����f�[�^�̍ő吔
    [SerializeField]
    private int maxDataNum = 2000000;
    //�@�L�^�Ԋu
    [SerializeField]
    private float recordDuration = 0.005f;
    //�@�o�ߎ���
    private float elapsedTime = 0f;
    //�@�S�[�X�g�f�[�^
    private ListData listData;
    //�@�Đ������ǂ���
    private bool isPlayBack;

    //�@�S�[�X�g�p�L����
    [SerializeField]
    public GameObject ghost0;


    [SerializeField]
    public GameObject ghost;

    public List<GameObject> ghosts;
    public List<Rigidbody2D> rbodys;


    public List<bool> right0 = new List<bool>();


    public int ghostCount = 0;
    //�@�S�[�X�g�f�[�^��1���肵����̑҂�����
    [SerializeField]
    private float waitTime = 0f;


    public LayerMask groundLayer;
    bool onGround = false;

    public GameObject panel;
    public GameObject mainImage;

    bool firstFlag = true;
    //�@�S�[�X�g�f�[�^�����n�߂����ԁA�܂��͑O�̃f�[�^
    private float startTime;
    //�@�S�[�X�g�̈ʒu�E�p�x�̃f�[�^���Ō�܂ōĐ��������ǂ���
    private bool isLoopReset;

    public float xpos = 0.0f;
    public float ypos = 0.0f;

    bool firstRec = true;


    void Start()
    {
        StartRecord();
        ghostCount = 0;

    }

    //�@�S�[�X�g�f�[�^�N���X
    [Serializable]
    private class ListData
    {
        // �E�J�[�\���L�[�̃��X�g
        public List<List<bool>> rightLists = new List<List<bool>>();
    }
    // Update is called once per frame
    void Update()
    {
        //�L�^
        if (isRecord && GhostChara.gameState == "playing")
        {
            Rec();
        }
    }

    //Update�ŌJ��Ԃ�
    public void Rec()
    {
        var moveHorizontal = Input.GetAxisRaw("Horizontal");

            elapsedTime += Time.deltaTime;

            if (elapsedTime >= recordDuration)
            {
                if (Input.GetAxisRaw("Horizontal") == 1)
                {
                    right0.Add(true);
                    Debug.Log("�E�L�^");
                }
                else
                {
                    right0.Add(false);
                    Debug.Log("�E�L�^");
                }

                elapsedTime = 0f;

                /*
                //�@�f�[�^�ۑ������ő吔�𒴂�����L�^���X�g�b�v
                if (listData.rightLists[ghostCount].Count >= maxDataNum)
                {
                    StopRecord();
                }
                */
            }
    }
    //�@�L�����N�^�[�f�[�^�̕ۑ�
    public void StartRecord()
    {
        //�@�ۑ����鎞�̓S�[�X�g�̍Đ����~
        StopGhost();

        


        isRecord = true;
        elapsedTime = 0f;
        //List�̏�����
        listData = new ListData();
        startTime = Time.realtimeSinceStartup;
        Debug.Log("StartRecord");
    }

    //�@�L�����N�^�[�f�[�^�̕ۑ��̒�~
    public void StopRecord()
    {
        //�Ō�ɓ��������Ă��܂��̂�h�~
        //listData.rightLists[ghostCount].Add(false);
        isRecord = false;
        Debug.Log("StopRecord");
    }

    //�S�[�X�g�̍Đ��{�^�������������̏���
    public void StartGhost()
    {
        listData.rightLists.Add(right0);
        right0 = new List<bool>();

        Debug.Log("StartGhost");
        if (listData == null)
        {
            Debug.Log("�S�[�X�g�f�[�^������܂���");
        }
        else
        {
            isPlayBack = true;

            //�S�[�X�g����
            ghosts.Add(Instantiate(ghost0, new Vector2(xpos, ypos), Quaternion.identity));
            rbodys.Add(ghosts[ghosts.Count -1].GetComponent<Rigidbody2D>());

            StartCoroutine(PlayBack());
            //StartCoroutine(PlayBackJump());
        }
    }

    //�@�S�[�X�g�̒�~
    public void StopGhost()
    {
        //StopCoroutine(PlayBack());
        isPlayBack = false;
    }

    //�@�S�[�X�g�̍Đ�
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

    //RESTARTButton�ŌĂяo��
    //��x����ł���ăX�^�[�g�̏���
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