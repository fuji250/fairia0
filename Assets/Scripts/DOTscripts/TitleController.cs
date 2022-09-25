using DG.Tweening;  //DOTween‚ðŽg‚¤‚Æ‚«‚Í‚±‚Ìusing‚ð“ü‚ê‚é
using UnityEngine;

public class TitleController : MonoBehaviour
{
    void Start()
    {
        // 3•b‚©‚¯‚Ä(5,0,0)‚ÖˆÚ“®‚·‚é
        this.transform.DOMove(new Vector3(-0.0f, -3.7f, 0f), 0.8f);
    }
}