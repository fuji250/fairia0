using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage9 : MonoBehaviour
{
    public float BlockXpos = 0.0f;
    public float BlockYpos = 0.0f;

    public GameObject MovingBlock;
    public GameObject Switch;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Reset()
    {

        MovingBlock.transform.position = new Vector2(BlockXpos, BlockYpos);
        Switch.GetComponent<SwitchAction>().on = false;
        Switch.GetComponent<SpriteRenderer>().sprite = Switch.GetComponent<SwitchAction>().imageOff;
        MovingBlock movBlock = MovingBlock.GetComponent<MovingBlock>();
        movBlock.Stop();
        //GameObject.Find("SwitchAction").GetComponent<BoxCollider2D>().enabled = true;
        //GameObject.Find("Player").transform.position = new Vector2(xpos, ypos);
    }
}
