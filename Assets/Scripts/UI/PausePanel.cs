using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject PlayerUI;
    public GameObject MiniMapCanvasUI;
    public GameObject SavePanel;

    private void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel.SetActive(true);
            PlayerUI.SetActive(false);
            MiniMapCanvasUI.SetActive(false);
            SavePanel.SetActive(false);

            Cursor.lockState = CursorLockMode.Confined;
        }
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ContinueButton()
    {
        pausePanel.SetActive(false);
        PlayerUI.SetActive(true);
        MiniMapCanvasUI.SetActive(true);
        SavePanel.SetActive(true);
    }
}
