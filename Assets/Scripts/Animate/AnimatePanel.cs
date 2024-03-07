using UnityEngine;
using DG.Tweening;

public class PopupEffect : MonoBehaviour
{
    public float popupDuration = 0.5f;
    public Vector3 targetScale = new Vector3(1.2f, 1.2f, 1.2f);
    public Ease animateStyle = Ease.OutBack;

    void OnEnable()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(targetScale, popupDuration).SetEase(animateStyle);
    }
}