using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIStatus : MonoBehaviour
{
    #region Serialized Fields

    [Header("Status Texts")]
    [SerializeField] private TMP_Text textId;
    [SerializeField] private TMP_Text textLevel;
    [SerializeField] private TMP_Text textHP;
    [SerializeField] private TMP_Text textAttack;
    [SerializeField] private TMP_Text textDefense;

    [Header("Buttons")]
    [SerializeField] private Button buttonBack;

    #endregion

    #region Private Fields

    private Character player;

    #endregion

    #region Unity Methods

    private void Start()
    {
        buttonBack.onClick.AddListener(OnClickBack);
    }

    #endregion

    #region Public Methods

    public void SetPlayer(Character character)
    {
        player = character;
        RefreshUI();
    }

    public void RefreshUI()
    {
        if (player == null) return;

        textId.text = $"ID : {player.Id}";
        textLevel.text = $"Level : {player.Level}";
        textHP.text = $"HP : {player.BaseMaxHP}"; // 현재 HP 시스템 없으므로 최대치만
        textAttack.text = $"Attack : {player.GetTotalAttack()}";
        textDefense.text = $"Defense : {player.GetTotalDefense()}";
    }

    #endregion

    #region Button Callbacks

    private void OnClickBack()
    {
        UIManager.Instance.OpenMainMenu();
    }

    #endregion
}