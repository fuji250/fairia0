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

    // +++�v���C���[����+++
    public GameObject inputUI;//����UI�p�l��

    public GameObject Rpanel;
    public GameObject Npanel;
    // Start is called before the first frame update
    void Start()
    {
        //�摜���\���ɂ���
        Invoke("InactiveImage", 0.0f);
        //�p�l�����\���ɂ���
        Npanel.SetActive(false);
        Rpanel.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (GhostChara.gameState == "gameclear")
        {
            //�Q�[���N���A
            mainImage.SetActive(true);
            panel.SetActive(true);

            Npanel.SetActive(true);
            Rpanel.SetActive(false);
            mainImage.GetComponent<Image>().sprite = gameClearSpr;

            // +++�v���C���[����+++
            inputUI.SetActive(false);//����UI�B��

        }
        else if (GhostChara.gameState == "gameover")
        {
            //�Q�[���I�[�o�[
            mainImage.SetActive(true);
            panel.SetActive(true);



            // NEXT�{�^���𖳌�������
            Button Nbt = nextButton.GetComponent<Button>();
            Npanel.SetActive(false);
            Rpanel.SetActive(true);
            mainImage.GetComponent<Image>().sprite = gameOverSpr;
            //GhostChara.gameState = "gameend";

            // +++�v���C���[����+++
            inputUI.SetActive(false);//����UI�B��
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
    //�摜���\���ɂ���
    void InactiveImage()
    {
        mainImage.SetActive(false);
    }

    // +++�v���C���[����+++
    //�W�����v
    public void Jump()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GhostChara playerCnt = player.GetComponent<GhostChara>();
        playerCnt.Jump();
    }
}
