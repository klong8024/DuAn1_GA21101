using UnityEngine;

public class UI_WinScreen : MonoBehaviour
{

    private void OnEnable()
    {
        CameraBounds.bossIsDead = false;
        Debug.Log("Biến đã được đặt lại!");
    }
    public void GoToMainMenu()
    {
        GameManager.instance.ChangeScene("MainMenu", RespawnType.NonSpecific);
    }
}
