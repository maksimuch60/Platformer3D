using UnityEngine;

namespace P3D.Game
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Base settings")]
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _speed;
        [SerializeField] private float _gravityMultiplier;
    
    
        [Header("Grounded")]
        [SerializeField] private Transform _checkGroundTransform;
        [SerializeField] private float _checkGroundRadius;
        [SerializeField] private LayerMask _checkGroundLayerMask;
    
        [Header("Jump")]
        [SerializeField] private float _jumpHeight;

        private Vector3 _fallVector;
        private Transform _cachedTransform;

        private void Awake()
        {
            _cachedTransform = transform;
        }

        private void Update()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 moveVector = _cachedTransform.right * horizontal + _cachedTransform.forward * vertical;
            moveVector *= _speed * Time.deltaTime;

            _characterController.Move(moveVector);

            bool isGrounded =
                Physics.CheckSphere(_checkGroundTransform.position, _checkGroundRadius, _checkGroundLayerMask);

            if (isGrounded && _fallVector.y < 0)
            {
                _fallVector.y = 0;
            }
        
            float gravity = Physics.gravity.y * _gravityMultiplier;
        
            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                _fallVector.y = Mathf.Sqrt(_jumpHeight * -2f * gravity);
            }

            _fallVector.y += gravity * Time.deltaTime;

            _characterController.Move(_fallVector * Time.deltaTime);
        }
    }
}
