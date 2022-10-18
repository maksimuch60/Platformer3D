using UnityEngine;

namespace P3D.Game
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private MovingObject _movingObject;

        private bool _isDoorOpen;
        
        public void OpenDoor()
        {
            if (_isDoorOpen)
                return;
            
            _isDoorOpen = true;
            _movingObject.Play(() => _isDoorOpen = false);
        }
    }
}