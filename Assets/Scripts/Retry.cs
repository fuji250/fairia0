using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retry : MonoBehaviour
{
    public GameObject MB2;
    public GameObject MB1;
    public float firstPos2;
    public float firstPos1;
    //Transform setposi;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ritsuki()
    {
        Vector3 posi2 = new Vector3 ( MB2.transform.position.x, MB2.transform.position.y, 0 );
        posi2.y = firstPos2;
        MB2.transform.position = posi2;

        Vector3 posi1 = new Vector3(MB1.transform.position.x, MB1.transform.position.y, 0);
        posi1.y = firstPos1;
        MB1.transform.position = posi1;
    }
}
