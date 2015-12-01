using UnityEngine;
using System.Collections;

public class TogglePanel : MonoBehaviour
    {
    
    public void TogglePanelScript (GameObject panel)
    {
        panel.SetActive (!panel.activeSelf);
    }
}