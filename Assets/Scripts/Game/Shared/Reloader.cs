using UnityEngine.SceneManagement;

namespace P3D.Game
{
    public static class Reloader
    {
        public static void Reload()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}