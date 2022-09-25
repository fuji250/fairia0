using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostChara : MonoBehaviour
{
    public Rigidbody2D rbody;//Rigidbody2D�̕ϐ�
    public float axisH = 0.0f;//����
    public float speed = 5.0f;//�ړ����x

    public float jump = 9.0f;//�W�����v��
    public LayerMask groundLayer;//���n�ł��郌�C���[


    bool goJump = false;//�W�����v�J�n�t���O
    bool onGround = false;//�n�ʂɗ����Ă���t���O

    public static string gameState = "playing";//�Q�[���̏��

    //�A�j���[�V�����Ή�
    Animator animator;
    public string stopAnime = "PlayerStop";
    public string moveAnime = "PlayerMove";
    public string jumpAnime = "PlayerJump";
    public string goalAnime = "PlayerGoal";
    public string deadAnime = "PlayerOver";
    public string nowAnime = "";
    public string oldAnime = "";

    public ShakeableTransform m_shakeable;

    public GameObject Up;
    public GameObject Down;

    //�^�b�`�X�N���[���Ή��ǉ�
    bool isMoving = false;

    public GameObject dia;

    // Start is called before the first frame update
    void Start()
    {
        

        //Rigidbody2D������Ă���
        rbody = this.GetComponent<Rigidbody2D>();
        gameState = "playing";//�Q�[�����ɂ���

        //Anmator������Ă���
        animator = GetComponent<Animator>();
        nowAnime = stopAnime;
        oldAnime = stopAnime;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState != "playing")
        {
            return;
        }
        //�ړ�
        if(isMoving == false)
        {
            //���������̓��͂��`�F�b�N����
            axisH = Input.GetAxisRaw("Horizontal");
        }
        
        //�����̒���
        if (axisH > 0.0f)
        {
            //�E����
            transform.localScale = new Vector2(1, 1);
            Debug.Log("�E����");
        }
        else if(axisH < 0.0f)
        {
            //������
            transform.localScale = new Vector2(-1, 1);//���E���]������
            Debug.Log("������");
        }
        //�L�����N�^�[���W�����v������
        if (Input.GetButtonDown("Jump"))
        {
            Jump();//�W�����v
        }
    }
    void FixedUpdate()
    {
        
        if (gameState != "playing")
        {
            return;
        }
        //�n�㔻��
        onGround = Physics2D.Linecast(transform.position - (transform.up * 0.57f) + (transform.right * 0.5f), transform.position - (transform.up * 0.57f) - (transform.right * 0.5f), groundLayer);
        
        //���x���X�V����
        rbody.velocity = new Vector2(axisH * speed, rbody.velocity.y);

        if (onGround && goJump)
        {
            //�n�ʂ̏�ŃW�����v�L�[�������ꂽ
            //�W�����v������
            Debug.Log("�W�����v");
            goJump = false;//�W�����v�t���O������
            Vector2 jumpPw = new Vector2(0, jump);//�W�����v������x�N�g�������
            rbody.velocity = new Vector2(0, 0);
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);//�u�ԓI�ȗ͂�������
            
        }
        if (onGround)
        {
            if(axisH == 0)
            {
                nowAnime = stopAnime;
            }
            else
            {
                nowAnime = moveAnime;
            }
        }
        else
        {
            nowAnime = jumpAnime;
        }
        if(nowAnime != oldAnime)
        {
            oldAnime = nowAnime;
            animator.Play(nowAnime);
        }
        
    }
    //�W�����v
    public void Jump()
    {
        if (onGround)
        {
            goJump = true;//�W�����v�t���O�𗧂Ă�
        }
    }
    //�ڐG�J�n
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Goal();//�S�[���I�I
            Debug.Log("�S�[��");
        }
        else if (collision.gameObject.tag == "Dead")
        {
            GameOver();//�Q�[���I�[�o�[�I�I
            Debug.Log("�Q�[���I�[�o�[");
        }
        else if (collision.gameObject.tag == "FinalGoal")
        {
            //FadeManager.fadeColor = Color.white;
            dia.SetActive(false);
            LastFade.Instance.LoadScene("LAST", 1.0f);
        }
    }
    //�S�[��
    public void Goal()
    {
        animator.Play(goalAnime);
        gameState = "gameclear";
        GameStop();//�Q�[����~
    }
    //�Q�[���I�[�o�[
    public void GameOver()
    {
        m_shakeable.InduceStress(1);
        gameState = "gameover";
        GameStop();//�Q�[����~
        // =======================================
        // �Q�[���I�[�o�[���o
        // =======================================
        //�v���C���[�����������
        GetComponent<BoxCollider2D>().enabled = false;
        Up.GetComponent<BoxCollider2D>().enabled = false;
        Down.GetComponent<BoxCollider2D>().enabled = false;
        //�v���C���[����ɏ������ˏグ�鉉�o
        rbody.AddForce(new Vector2(0, 800), ForceMode2D.Impulse);

        animator.Play(deadAnime);
    }
    //�Q�[����~
    void GameStop()
    {
        //Rigidbody2D������Ă���
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        //���x���O�ɂ��ċ�����~
        rbody.velocity = new Vector2(0, 0);
    }
    //�^�b�`�X�N���[���Ή��ǉ�
    public void SetAxis(float h,float v)
    {
        axisH = h;
        if(axisH == 0)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
    }
}
