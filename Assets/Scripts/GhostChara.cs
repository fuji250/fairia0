using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostChara : MonoBehaviour
{
    public Rigidbody2D rbody;//Rigidbody2Dの変数
    public float axisH = 0.0f;//入力
    public float speed = 5.0f;//移動速度

    public float jump = 9.0f;//ジャンプ力
    public LayerMask groundLayer;//着地できるレイヤー


    bool goJump = false;//ジャンプ開始フラグ
    bool onGround = false;//地面に立っているフラグ

    public static string gameState = "playing";//ゲームの状態

    //アニメーション対応
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

    //タッチスクリーン対応追加
    bool isMoving = false;

    public GameObject dia;

    // Start is called before the first frame update
    void Start()
    {
        

        //Rigidbody2Dを取ってくる
        rbody = this.GetComponent<Rigidbody2D>();
        gameState = "playing";//ゲーム中にする

        //Anmatorを取ってくる
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
        //移動
        if(isMoving == false)
        {
            //水平方向の入力をチェックする
            axisH = Input.GetAxisRaw("Horizontal");
        }
        
        //向きの調整
        if (axisH > 0.0f)
        {
            //右向き
            transform.localScale = new Vector2(1, 1);
            Debug.Log("右向き");
        }
        else if(axisH < 0.0f)
        {
            //左向き
            transform.localScale = new Vector2(-1, 1);//左右反転させる
            Debug.Log("左向き");
        }
        //キャラクターをジャンプさせる
        if (Input.GetButtonDown("Jump"))
        {
            Jump();//ジャンプ
        }
    }
    void FixedUpdate()
    {
        
        if (gameState != "playing")
        {
            return;
        }
        //地上判定
        onGround = Physics2D.Linecast(transform.position - (transform.up * 0.57f) + (transform.right * 0.5f), transform.position - (transform.up * 0.57f) - (transform.right * 0.5f), groundLayer);
        
        //速度を更新する
        rbody.velocity = new Vector2(axisH * speed, rbody.velocity.y);

        if (onGround && goJump)
        {
            //地面の上でジャンプキーが押された
            //ジャンプさせる
            Debug.Log("ジャンプ");
            goJump = false;//ジャンプフラグを下す
            Vector2 jumpPw = new Vector2(0, jump);//ジャンプさせるベクトルを作る
            rbody.velocity = new Vector2(0, 0);
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);//瞬間的な力を加える
            
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
    //ジャンプ
    public void Jump()
    {
        if (onGround)
        {
            goJump = true;//ジャンプフラグを立てる
        }
    }
    //接触開始
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Goal();//ゴール！！
            Debug.Log("ゴール");
        }
        else if (collision.gameObject.tag == "Dead")
        {
            GameOver();//ゲームオーバー！！
            Debug.Log("ゲームオーバー");
        }
        else if (collision.gameObject.tag == "FinalGoal")
        {
            //FadeManager.fadeColor = Color.white;
            dia.SetActive(false);
            LastFade.Instance.LoadScene("LAST", 1.0f);
        }
    }
    //ゴール
    public void Goal()
    {
        animator.Play(goalAnime);
        gameState = "gameclear";
        GameStop();//ゲーム停止
    }
    //ゲームオーバー
    public void GameOver()
    {
        m_shakeable.InduceStress(1);
        gameState = "gameover";
        GameStop();//ゲーム停止
        // =======================================
        // ゲームオーバー演出
        // =======================================
        //プレイヤー当たりを消す
        GetComponent<BoxCollider2D>().enabled = false;
        Up.GetComponent<BoxCollider2D>().enabled = false;
        Down.GetComponent<BoxCollider2D>().enabled = false;
        //プレイヤーを上に少し跳ね上げる演出
        rbody.AddForce(new Vector2(0, 800), ForceMode2D.Impulse);

        animator.Play(deadAnime);
    }
    //ゲーム停止
    void GameStop()
    {
        //Rigidbody2Dを取ってくる
        Rigidbody2D rbody = GetComponent<Rigidbody2D>();
        //速度を０にして強制停止
        rbody.velocity = new Vector2(0, 0);
    }
    //タッチスクリーン対応追加
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
