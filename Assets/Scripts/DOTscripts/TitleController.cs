using DG.Tweening;  //DOTween���g���Ƃ��͂���using������
using UnityEngine;

public class TitleController : MonoBehaviour
{
    void Start()
    {
        // 3�b������(5,0,0)�ֈړ�����
        this.transform.DOMove(new Vector3(-0.0f, -3.7f, 0f), 0.8f);
    }
}