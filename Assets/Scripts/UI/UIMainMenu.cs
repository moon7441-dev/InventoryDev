using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIMainMenu : MonoBehaviour
{
    #region Serialized Fields

    [Header("Player Info Texts")]
    [SerializeField] private TMP_Text textId;
    [SerializeField] private TMP_Text textLevel;
    [SerializeField] private TMP_Text textGold;

    [Header("Buttons")]
    [SerializeField] private Button buttonStatus;
    [SerializeField] private Button buttonInventory;

    #endregion

    #region Private Fields

    private Character player;

    #endregion

    #region Unity Methods

    private void Start()
    {
        buttonStatus.onClick.AddListener(OnClickStatus);
        buttonInventory.onClick.AddListener(OnClickInventory);
    }

    #endregion

    #region Public Methods

    public void SetPlayer(Character character)
    {
        player = character;
        RefreshUI();
    }

    public void RefreshUI(bool isEquipped = false)
    {
        if (player == null) return;

        textId.text = $"ID : {player.Id}";
        textLevel.text = $"{player.Level}";
        textGold.text = $"{player.Gold:n0} Gold";
    }

    #endregion

    #region Button Callbacks

    private void OnClickStatus()
    {
        UIManager.Instance.OpenStatus();
    }

    private void OnClickInventory()
    {
        UIManager.Instance.OpenInventory();
    }

    #endregion
}