using DG.Tweening;  //DOTweenを使うときはこのusingを入れる
using UnityEngine;

public class TitleController : MonoBehaviour
{
    void Start()
    {
        // 3秒かけて(5,0,0)へ移動する
        this.transform.DOMove(new Vector3(-0.0f, -3.7f, 0f), 0.8f);
    }
}