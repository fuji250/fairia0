using DG.Tweening;  //DOTweenを使うときはこのusingを入れる
using UnityEngine;

public class StartController : MonoBehaviour
{
    void Start()
    {
        // 3秒かけて(5,0,0)へ移動する
        this.transform.DOMove(new Vector2(-100f, 0f), 1f).SetDelay(1f);
    }
}