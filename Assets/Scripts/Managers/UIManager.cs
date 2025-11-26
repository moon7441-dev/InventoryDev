using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Singleton

    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    #endregion

    #region Serialized Fields

    [SerializeField] private UIMainMenu uiMainMenu;
    [SerializeField] private UIStatus uiStatus;
    [SerializeField] private UIInventory uiInventory;

    #endregion

    #region Properties

    public UIMainMenu MainMenu => uiMainMenu;
    public UIStatus Status => uiStatus;
    public UIInventory Inventory => uiInventory;

    #endregion

    #region Public Methods

    public void OpenMainMenu()
    {
        uiMainMenu.gameObject.SetActive(true);
        uiStatus.gameObject.SetActive(false);
        uiInventory.gameObject.SetActive(false);
    }

    public void OpenStatus()
    {
        uiMainMenu.gameObject.SetActive(false);
        uiStatus.gameObject.SetActive(true);
        uiInventory.gameObject.SetActive(false);
    }

    public void OpenInventory()
    {
        uiMainMenu.gameObject.SetActive(false);
        uiStatus.gameObject.SetActive(false);
        uiInventory.gameObject.SetActive(true);
    }

    #endregion
}