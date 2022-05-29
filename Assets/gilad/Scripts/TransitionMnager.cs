using UnityEngine;
using UnityEngine.SceneManagement;

namespace gilad.Scripts
{
    public class TransitionMnager : MonoBehaviour
    {
        // Start is called before the first frame update

    
        public void ReloadScene()
        {
            HitAndReset.OnReset();
            SceneManager.LoadScene($"level {GameManager.Level}");
            // SceneManager.LoadScene("game");
        }
    }
}
