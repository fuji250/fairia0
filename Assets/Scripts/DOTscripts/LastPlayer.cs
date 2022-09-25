using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LastPlayer : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Image image;

    void Start()
    {
        //1•b‚ÅÔF‚É•Ï‰»‚µŒ³‚ÌF‚É–ß‚é‚Ì‚ğ‚¸‚Á‚ÆŒJ‚è•Ô‚·
        //this.image.DOFade(endValue : 0f, duration : 0.1f).SetLoops(-1, LoopType.Restart);
        transform.DOScale(4.0f, 0.5f);
    }
}