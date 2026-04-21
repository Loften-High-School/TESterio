using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlSkip : MonoBehaviour

{
    public void OnSTartClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
