using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellController : MonoBehaviour
{

    public float deleteTime = 3.0f;//�폜���鎞��

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, deleteTime);//�폜�ݒ�
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(gameObject);//�����ɐڐG���������
    }
}
