using DG.Tweening;  //DOTween���g���Ƃ��͂���using������
using UnityEngine;

public class StartController : MonoBehaviour
{
    void Start()
    {
        // 3�b������(5,0,0)�ֈړ�����
        this.transform.DOMove(new Vector2(-100f, 0f), 1f).SetDelay(1f);
    }
}