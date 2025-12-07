using UnityEngine;

public class UI_MainMenu : MonoBehaviour
{
    public void PlayGameBTN()
    {
        GameManager.instance.ContinuePlay();
    }

    public void QuitGameBTN()
    {
        Application.Quit();
    }
}
