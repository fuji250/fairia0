using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastGhost : MonoBehaviour
{
    public Rigidbody2D rbody;//Rigidbody2Dの変数
    public float axisH = 0.0f;//入力
    public float speed = 5.0f;//移動速度

    public float jump = 9.0f;//ジャンプ力
    public LayerMask groundLayer;//着地できるレイヤー


    bool goJump = false;//ジャンプ開始フラグ
    bool onGround = false;//地面に立っているフラグ

    // Start is called before the first frame update
    void Start()
    {
        //Rigidbody2Dを取ってくる
        rbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
            Jump();//ジャンプ
        
    }
    void FixedUpdate()
    {
        //地上判定
        onGround = Physics2D.Linecast(transform.position - (transform.up * 0.58f) + (transform.right * 0.5f), transform.position - (transform.up * 0.58f) - (transform.right * 0.5f), groundLayer);

        //速度を更新する
        //rbody.velocity = new Vector2(axisH * speed, rbody.velocity.y);

        if (onGround && goJump)
        {
            //地面の上でジャンプキーが押された
            //ジャンプさせる
            Debug.Log("ジャンプ");
            Vector2 jumpPw = new Vector2(0, jump);//ジャンプさせるベクトルを作る
            rbody.AddForce(jumpPw, ForceMode2D.Impulse);//瞬間的な力を加える
            goJump = false;//ジャンプフラグを下す
        }
    }
    public void Jump()
    {
        goJump = true;//ジャンプフラグを立てる

    }
}
