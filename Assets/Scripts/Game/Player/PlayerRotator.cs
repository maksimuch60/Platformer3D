using UnityEngine;

namespace P3D.Game
{
    public class PlayerRotator : MonoBehaviour
    {
        [SerializeField] private float _sensitivity;
    
    
        private Vector3 _previousMousePosition;

        private void Start()
        {
            _previousMousePosition = Input.mousePosition;
        }

        private void Update()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 delta = _previousMousePosition - mousePosition;
            float rotationDelta = delta.x;
            transform.Rotate(-transform.up, rotationDelta * _sensitivity * Time.deltaTime);
            _previousMousePosition = mousePosition;
        }
    }
}