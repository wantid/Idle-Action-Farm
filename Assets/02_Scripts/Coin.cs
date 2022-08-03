using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    public float TimeToMove;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.position = rectTransform.position + Vector3.right * Random.Range(0, 50f) + Vector3.up * Random.Range(0, 15f);
    }

    private void Start()
    {
        rectTransform.DOLocalMove(GameManager.instance.coinsText.GetComponent<RectTransform>().position, TimeToMove)
            .SetEase(Ease.InOutQuint)
            .OnComplete(OnMoved);
    }

    private void OnMoved()
    {
        GameManager.instance.CoinsUpdate();
        Destroy(gameObject);
    }
}
