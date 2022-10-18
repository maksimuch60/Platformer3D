using UnityEngine;

namespace P3D.Game
{
    public class Button : MonoBehaviour
    {
        [SerializeField] private MovingObject _movingObject;
        [SerializeField] private StandArea _standArea;
        [SerializeField] private Door _door;
        

        private void OnEnable()
        {
            _standArea.OnEntered += PressButton;
        }

        private void OnDisable()
        {
            _standArea.OnEntered -= PressButton;
        }

        private void PressButton()
        {
            _movingObject.Play(null);
            _door.OpenDoor();
        }
    }
}