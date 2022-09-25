using DG.Tweening;  //DOTween‚ðŽg‚¤‚Æ‚«‚Í‚±‚Ìusing‚ð“ü‚ê‚é
using UnityEngine;

public class StartController : MonoBehaviour
{
    void Start()
    {
        // 3•b‚©‚¯‚Ä(5,0,0)‚ÖˆÚ“®‚·‚é
        this.transform.DOMove(new Vector2(-100f, 0f), 1f).SetDelay(1f);
    }
}