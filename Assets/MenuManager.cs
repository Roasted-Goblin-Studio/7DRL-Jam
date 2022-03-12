using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public MenuPanel startPanel;
    public MenuPanel optionsPanel;
    [SerializeField] private MenuPanel selectedPanel;

    public void OnStartClick() {
        startPanel.DisablePanel(false);
        optionsPanel.DisablePanel(false);
        SceneManager.LoadScene("Tutorial");
    }

    public void OnOptionsClick() {
        startPanel.DisablePanel(false);
        optionsPanel.EnablePanel(false);
    }

    public void OnExitClick() {
        startPanel.DisablePanel(false);
        optionsPanel.DisablePanel(false);
        Application.Quit();
    }

    public void OnBackClick() {
        startPanel.EnablePanel(false);
        optionsPanel.DisablePanel(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        startPanel.EnablePanel(true);
        optionsPanel.DisablePanel(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
