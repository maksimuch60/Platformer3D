using System;
using UnityEngine;

namespace P3D.Game
{
    [RequireComponent(typeof(Collider))]
    public class StandArea : MonoBehaviour
    {
        private Transform _previousParent;

        public event Action OnEntered;
        private void Awake()
        {
            Collider col = GetComponent<Collider>();
            col.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Tags.Player))
                return;

            _previousParent = other.transform.parent;
            other.transform.SetParent(transform);
            
            OnEntered?.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag(Tags.Player))
                return;

            other.transform.SetParent(_previousParent);
        }
    }
}