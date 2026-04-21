using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour

{
    public void OnSTartClick()
    {
        SceneManager.LoadScene("Controls");
    }

     public void OnExitCLick()
     {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
        Application.Quit();
     }



}
