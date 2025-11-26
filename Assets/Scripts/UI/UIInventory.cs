using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInventory : MonoBehaviour
{
    #region Serialized Fields

    [Header("Equipped Texts")]
    [SerializeField] private TMP_Text textWeapon;
    [SerializeField] private TMP_Text textArmor;
    [SerializeField] private TMP_Text textAccessory;

    [Header("Inventory UI")]
    [SerializeField] private Transform slotParent;  // ScrollView의 Content
    [SerializeField] private UISlot slotPrefab;

    [Header("Buttons")]
    [SerializeField] private Button buttonBack;

    #endregion

    #region Private Fields

    private Character player;
    private List<UISlot> slotList = new List<UISlot>();

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
        InitInventoryUI();
        RefreshEquipped();
    }

    private void InitInventoryUI()
    {
        foreach (Transform child in slotParent)
        {
            Destroy(child.gameObject);
        }
        slotList.Clear();

        if (player == null || player.Inventory == null) return;

        foreach (var item in player.Inventory)
        {
            var slot = Instantiate(slotPrefab, slotParent);
            slot.Init(this);
            bool isEquipped = IsEquipped(item);
            slot.SetItem(item);
            slot.RefreshUI(isEquipped);
            slotList.Add(slot);
        }
    }

    private bool IsEquipped(Item item)
    {
        if (player == null) return false;

        return (player.EquippedWeapon == item ||
                player.EquippedArmor == item ||
                player.EquippedAccessory == item);
    }

    private void RefreshEquipped()
    {
        if (player == null) return;

        textWeapon.text = player.EquippedWeapon != null
            ? $"Weapon : {player.EquippedWeapon.Name}"
            : "Weapon : (없음)";

        textArmor.text = player.EquippedArmor != null
            ? $"Armor : {player.EquippedArmor.Name}"
            : "Armor : (없음)";

        textAccessory.text = player.EquippedAccessory != null
            ? $"Accessory : {player.EquippedAccessory.Name}"
            : "Accessory : (없음)";
    }

    public void OnClickSlot(Item item)
    {
        if (item == null || player == null) return;

        if (IsEquipped(item))
        {
            player.UnEquip(item.Type);
        }
        else
        {
            player.Equip(item);
        }

        RefreshEquipped();
        UIManager.Instance.Status.RefreshUI();
        InitInventoryUI();
    }

    #endregion

    #region Button

    private void OnClickBack()
    {
        UIManager.Instance.OpenMainMenu();
    }

    #endregion
}