using UnityEngine;

public class help_menu : MonoBehaviour
{
    [SerializeField] GameObject helpMenuUI;
    
    public void openHelpMenu()
    {
        helpMenuUI.SetActive(true);
    }
    public void closeHelpMenu()
    {
        helpMenuUI.SetActive(false);
    }
}
