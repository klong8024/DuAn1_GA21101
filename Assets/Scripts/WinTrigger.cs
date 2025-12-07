using UnityEngine;

public class WinTrigger : MonoBehaviour
{
    public GameObject winScreen;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && CameraBounds.bossIsDead)
        {
            winScreen.SetActive(true);
        }
    }
}
