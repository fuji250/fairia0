using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{

    public float deleteTime = 3.0f;//íœ‚·‚éŠÔ

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, deleteTime);//íœİ’è
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(gameObject);//‰½‚©‚ÉÚG‚µ‚½‚çÁ‚·
    }
}
