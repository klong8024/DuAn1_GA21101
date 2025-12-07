using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public static bool bossIsDead = false;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            bossIsDead = true;
            Debug.Log("Boss is dead!");
        }
    }
}
