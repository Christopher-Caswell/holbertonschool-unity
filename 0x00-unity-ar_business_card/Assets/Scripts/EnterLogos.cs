using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class EnterLogos : MonoBehaviour
{
    [SerializeField] private RectTransform _targetRectTransform;
    [SerializeField] private float _endScale = 1f;
    [SerializeField] private float _endPositionx = 0f;
    public GameObject _logo;

    private Sequence _sequence;

    public void Start()
    {
        _logo.SetActive(true);
        _targetRectTransform
            .DOLocalMoveX(endValue: _endPositionx, duration: 2f, snapping: false)
            .OnComplete(() =>
        {
            _targetRectTransform
            .DOScale(endValue: _endScale, duration: .5f);
        });
    }

    public void StopEnterLogos()
    {
        _sequence = DOTween
                        .Sequence()
                        .SetAutoKill(false);
    }


}
