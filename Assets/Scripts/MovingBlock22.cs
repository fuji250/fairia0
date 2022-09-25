using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock22 : MonoBehaviour
{
    public GameObject MovingBlock2;
    bool isTrigger2 = false;

    public float evSpeed2 = 0.01f;
    public float minHeight2 = -1.7f;
    float evHeight2;
    public float fPos2;

    void Start()
    {
        evHeight2 = MovingBlock2.transform.position.y;
    }

    void FixedUpdate()
    {
        evHeight2 = MovingBlock2.transform.position.y;
        if (isTrigger2 == false && evHeight2 >= minHeight2)
        {

            //â∫Ç…ìÆÇ©Ç∑
            MovingBlock2.transform.Translate(new Vector3(0, -1 * evSpeed2, 0));


        }
    }
    //ê⁄êGäJén
    void OnTriggerStay2D(Collider2D col)
    {

        isTrigger2 = true;
        //ìÆÇ´Çé~ÇﬂÇÈ
        if (col.gameObject.tag == "Player")
        {
            MovingBlock2.transform.Translate(new Vector3(0, 0, 0));


            /*if (evHeight <= maxHeight)
            {
                //è„Ç…ìÆÇ©Ç∑
                targetMoveBlock.transform.Translate(new Vector3(0, 1 * evSpeed, 0));
                Debug.Log("++++++++++++++++");
            }*/



            /*if (col.gameObject.tag == "Player")
            {
                if (on)
                {
                    on = false;
                    GetComponent<SpriteRenderer>().sprite = imageOff;
                    //ovingBlock movBlock = targetMoveBlock.GetComponent<MovingBlock>();
                    //movBlock.Stop();
                }
                else
                {
                    on = true;
                    GetComponent<SpriteRenderer>().sprite = imageOn;
                    //MovingBlock movBlock = targetMoveBlock.GetComponent<MovingBlock>();
                    //movBlock.Move();
                }
            }*/
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        isTrigger2 = false;
    }
}
