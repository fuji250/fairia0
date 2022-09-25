using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock11 : MonoBehaviour
{
    public GameObject MovingBlock1;
    bool isTrigger1 = false;

    public float evSpeed1;
    public float maxHeight1;
    public float checkHeight;
    float evHeight1;
    public float fPos1;

    void Start()
    {
        evHeight1 = MovingBlock1.transform.position.y;
    }

    void FixedUpdate()
    {
        evHeight1 = MovingBlock1.transform.position.y;
        if (isTrigger1 == false && evHeight1 <= maxHeight1)
        {

            //‰º‚É“®‚©‚·
            MovingBlock1.transform.Translate(new Vector3(0, 1 * evSpeed1, 0));


        }
    }
    //ÚGŠJŽn
    void OnTriggerStay2D(Collider2D col)
    {
        if (evHeight1 >= checkHeight)
        {


            isTrigger1 = true;
            //“®‚«‚ðŽ~‚ß‚é
            if (col.gameObject.tag == "Player")
            {
                MovingBlock1.transform.Translate(new Vector3(0, 0, 0));


                /*if (evHeight <= maxHeight)
                {
                    //ã‚É“®‚©‚·
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


    }
    void OnTriggerExit2D(Collider2D col)
    {
        isTrigger1 = false;
    }
}
