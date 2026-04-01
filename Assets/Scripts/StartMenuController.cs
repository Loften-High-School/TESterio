using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour

{
    public void OnSTartClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

     public void OnExitCLick()
     {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
        Application.Quit();
     }
}
