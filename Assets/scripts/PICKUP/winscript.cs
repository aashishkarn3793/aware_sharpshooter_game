using UnityEngine;
using TMPro;

public class Chest : MonoBehaviour
{
    const string PLAYER_TAG = "player";

    [SerializeField] GameObject winUI;
    [SerializeField] TextMeshProUGUI chestText;

    static int collectedChests = 0;

    void Start()
    {
        chestText.text = "items collected: " + collectedChests + "/3";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PLAYER_TAG))
        {
            if (collectedChests < 3)
            {
                collectedChests++;
                chestText.text = "items collected: " + collectedChests + "/3";
            }

            if (collectedChests == 3)
            {
                winUI.SetActive(true);
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            Destroy(gameObject);
        }
    }

    public static void ResetChestCount()
    {
        collectedChests = 0;
    }
}