using UnityEngine;
using DG.Tweening;

public class LoadingCircle : MonoBehaviour
{
    public float rotationSpeed = 360f;

    private void OnEnable()
    {
        transform.DORotate(new Vector3(0f, 0f, 360f), 1f, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Incremental)
            .SetEase(Ease.Linear);
    }

    private void OnDisable()
    {
        transform.DOKill();
    }
}