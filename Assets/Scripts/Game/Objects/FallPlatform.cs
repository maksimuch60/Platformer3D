using System;
using DG.Tweening;
using UnityEngine;

namespace P3D.Game
{
    public class FallPlatform : MonoBehaviour
    {
        [SerializeField] private StandArea _standArea;
        [SerializeField] private float _fallDelay;
        [SerializeField] private float _fallDuration;
        [SerializeField] private Ease _ease;

        private Vector3 _startPosition;
        private void Awake()
        {
            _startPosition = transform.position;
        }

        private void OnEnable()
        {
            _standArea.OnEntered += Fall;
        }

        private void Fall()
        {
            _standArea.OnEntered -= Fall;

            Sequence sequence = DOTween.Sequence();
            
            sequence.AppendInterval(_fallDelay);
            sequence.Append(transform
                .DOMove(transform.position + new Vector3(0, -50, 0), _fallDuration)
                .SetEase(_ease));

            sequence.OnComplete(Reset);
            
            sequence.SetUpdate(UpdateType.Fixed);
        }

        private void Reset()
        {
            _standArea.OnEntered += Fall;
            transform.position = _startPosition;
        }
    }
}