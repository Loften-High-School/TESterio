using UnityEngine;
using UnityEngine.SceneManagement;

public class Pinball : MonoBehaviour

{
    public void OnSTartClick()
    {
        SceneManager.LoadScene("Pinball");
    }
}
