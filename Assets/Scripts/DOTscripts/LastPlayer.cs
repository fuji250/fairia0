using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LastPlayer : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Image image;

    void Start()
    {
        //1�b�ŐԐF�ɕω������̐F�ɖ߂�̂������ƌJ��Ԃ�
        //this.image.DOFade(endValue : 0f, duration : 0.1f).SetLoops(-1, LoopType.Restart);
        transform.DOScale(4.0f, 0.5f);
    }
}