using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    private void Start()
    {
        HideInventoryPanel();
    }

    public void ShowInventoryPanel()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HideInventoryPanel()
    {
        panel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
