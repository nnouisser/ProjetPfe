using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public GameObject OurInventory;
    public GameObject InfoPanel;
    public GameObject TheAxe;
    public GameObject shoot;


    void Start()
    {
       
    }

    public void OpenPanel()
    {
        InfoPanel.SetActive(true);
    }

    // Méthode pour basculer l'état de l'inventaire
    public void ToggleInventory()
    {
        // If the inventory is not active, activate it; otherwise, deactivate it
        OurInventory.SetActive(!OurInventory.activeSelf);
    }



    public void ItemEquip()
    {
        TheAxe.SetActive(true);
        shoot.SetActive(true);
        InfoPanel.SetActive(false);
    }

    public void ItemCancel()
    {
        InfoPanel.SetActive(false);
    }
}
