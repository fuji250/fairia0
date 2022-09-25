using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject mainImage;
    public Sprite gameOverSpr;
    public Sprite gameClearSpr;
    public GameObject panel;
    public GameObject restartButton;
    public GameObject nextButton;

    Image titleImage;

    public GameObject Reset;

    [SerializeField]
    public Button rbt;
    [SerializeField]
    public Button nbt;

    // +++プレイヤー操作+++
    public GameObject inputUI;//操作UIパネル

    public GameObject Rpanel;
    public GameObject Npanel;
    // Start is called before the first frame update
    void Start()
    {
        //画像を非表示にする
        Invoke("InactiveImage", 0.0f);
        //パネルを非表示にする
        Npanel.SetActive(false);
        Rpanel.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (GhostChara.gameState == "gameclear")
        {
            //ゲームクリア
            mainImage.SetActive(true);
            panel.SetActive(true);

            Npanel.SetActive(true);
            Rpanel.SetActive(false);
            mainImage.GetComponent<Image>().sprite = gameClearSpr;

            // +++プレイヤー操作+++
            inputUI.SetActive(false);//操作UI隠す

        }
        else if (GhostChara.gameState == "gameover")
        {
            //ゲームオーバー
            mainImage.SetActive(true);
            panel.SetActive(true);



            // NEXTボタンを無効化する
            Button Nbt = nextButton.GetComponent<Button>();
            Npanel.SetActive(false);
            Rpanel.SetActive(true);
            mainImage.GetComponent<Image>().sprite = gameOverSpr;
            //GhostChara.gameState = "gameend";

            // +++プレイヤー操作+++
            inputUI.SetActive(false);//操作UI隠す
        }
        if (Input.GetButtonDown("Reset0"))
        {
            Reset = GameObject.Find("Canvas");
            Reset.GetComponent<ChangeScene>().Load();
        }
        if (GhostChara.gameState == "gameover")
        { 
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("Submit"))
            {
                rbt.onClick.Invoke();
            }
        }
        if (GhostChara.gameState == "gameclear")
        {
            if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("Submit"))
            {
                nbt.onClick.Invoke();
            }
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            FadeManager.Instance.LoadScene("Stage1", 1.0f);
        }
    }
    //画像を非表示にする
    void InactiveImage()
    {
        mainImage.SetActive(false);
    }

    // +++プレイヤー操作+++
    //ジャンプ
    public void Jump()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GhostChara playerCnt = player.GetComponent<GhostChara>();
        playerCnt.Jump();
    }
}
