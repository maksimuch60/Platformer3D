using System;
using UnityEngine;

namespace P3D.Game
{
    public class DeathZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            //TODO: refactor in future
            Reloader.Reload();
        }
    }
}