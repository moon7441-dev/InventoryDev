using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISlot : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField] private TMP_Text textName;
    [SerializeField] private TMP_Text textDescription;
    [SerializeField] private TMP_Text textType;
    [SerializeField] private TMP_Text textStat;

    [SerializeField] private Image imageEquippedMark;

    [SerializeField] private Image imageIcon;

    [SerializeField] private Button button;

    #endregion

    #region Private Fields

    private Item item;
    private UIInventory ownerInventory;

    #endregion

    #region Unity Methods

    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }

    #endregion

    #region Public Methods

    public void Init(UIInventory owner)
    {
        ownerInventory = owner;
    }

    public void SetItem(Item newItem)
    {
        item = newItem;
    }

    public void RefreshUI(bool isEquipped = false)
    {
        if (item == null)
        {
            textName.text = "";
            textDescription.text = "";
            textType.text = "";
            textStat.text = "";

            if (imageIcon != null)
            {
                imageIcon.sprite = null;
                imageIcon.enabled = false;
            }

            if (imageEquippedMark != null)
                imageEquippedMark.gameObject.SetActive(false);

            return;
        }

        textName.text = item.Name;
        textDescription.text = item.Description;
        textType.text = item.Type.ToString();
        textStat.text = $"ATK {item.Attack}, DEF {item.Defense}";

        if (imageIcon != null)
        {
            imageIcon.sprite = item.Icon;
            imageIcon.enabled = (item.Icon != null);
        }

        if (imageEquippedMark != null)
            imageEquippedMark.gameObject.SetActive(isEquipped);

        if (imageEquippedMark != null)
            imageEquippedMark.gameObject.SetActive(isEquipped);
    }

    #endregion

    #region Button

    private void OnClick()
    {
        if (ownerInventory != null && item != null)
        {
            ownerInventory.OnClickSlot(item);
        }
    }

    #endregion
}