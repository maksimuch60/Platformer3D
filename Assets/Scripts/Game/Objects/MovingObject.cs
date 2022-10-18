using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace P3D.Game
{
    public class MovingObject : MonoBehaviour
    {
        [SerializeField] private List<Transform> _points;

        [SerializeField] private bool _isNeedPlayOnStart;
        [SerializeField] private bool _isLoop;
        

        [Header("Animation settings")]
        [SerializeField] private float _delayInPosition = 1f;
        [SerializeField] private float _duration = 1f;
        [SerializeField] private Ease _ease;

        private Tween _tween;

        public List<Transform> Points => _points;

        private void Awake()
        {
            if (!IsValid())
            {
                return;
            }
            
            transform.position = _points.First().position;
        }

        private void Start()
        {
            if (!IsValid())
            {
                return;
            }

            if (_isNeedPlayOnStart)
            {
                Play(null);
            }
        }

        private bool IsValid()
        {
            return _points != null && _points.Count > 1;
        }
        public void Play(Action callback)
        {
            _tween?.Kill(true);

            Sequence sequence = DOTween.Sequence();
            
            for(int i = 1; i < _points.Count; i++)
            {
                sequence.AppendInterval(_delayInPosition);
                sequence.Append(transform
                    .DOMove(_points[i].position, _duration)
                    .SetEase(_ease));
            }
            
            
            
            sequence.AppendInterval(_delayInPosition);
            sequence.Append(transform
                .DOMove(_points.First().position, _duration)
                .SetEase(_ease));

            if (_isLoop)
            {
                sequence.SetLoops(-1);
            }
            else
            {
                sequence.OnComplete(() => callback?.Invoke());
            }
            
            sequence.SetUpdate(UpdateType.Fixed);

            _tween = sequence;
        }
    }
}