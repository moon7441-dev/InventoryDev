using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor,
    Accessory,
    Etc
}

public class Character
{
    #region Fields & Properties

    public string Id { get; private set; }
    public int Level { get; private set; }

    public int BaseMaxHP { get; private set; }
    public int BaseAttack { get; private set; }
    public int BaseDefense { get; private set; }

    public int Gold { get; private set; }

    // 인벤토리
    public List<Item> Inventory { get; private set; }

    // 장착 아이템
    public Item EquippedWeapon { get; private set; }
    public Item EquippedArmor { get; private set; }
    public Item EquippedAccessory { get; private set; }

    #endregion

    #region Constructor

    public Character(string id, int level, int baseMaxHP, int baseAttack, int baseDefense, int gold)
    {
        Id = id;
        Level = level;
        BaseMaxHP = baseMaxHP;
        BaseAttack = baseAttack;
        BaseDefense = baseDefense;
        Gold = gold;

        Inventory = new List<Item>();
        EquippedWeapon = null;
        EquippedArmor = null;
        EquippedAccessory = null;
    }

    #endregion

    #region Inventory Methods

    public void AddItem(Item item)
    {
        if (item == null) return;
        Inventory.Add(item);
    }

    public void Equip(Item item)
    {
        if (item == null) return;

        switch (item.Type)
        {
            case ItemType.Weapon:
                EquippedWeapon = item;
                break;
            case ItemType.Armor:
                EquippedArmor = item;
                break;
            case ItemType.Accessory:
                EquippedAccessory = item;
                break;
            default:
                break;
        }
    }

    public void UnEquip(ItemType type)
    {
        switch (type)
        {
            case ItemType.Weapon:
                EquippedWeapon = null;
                break;
            case ItemType.Armor:
                EquippedArmor = null;
                break;
            case ItemType.Accessory:
                EquippedAccessory = null;
                break;
        }
    }

    #endregion

    #region Status Calculation

    public int GetTotalAttack()
    {
        int result = BaseAttack;

        if (EquippedWeapon != null)
            result += EquippedWeapon.Attack;

        if (EquippedAccessory != null)
            result += EquippedAccessory.Attack;

        return result;
    }

    public int GetTotalDefense()
    {
        int result = BaseDefense;

        if (EquippedArmor != null)
            result += EquippedArmor.Defense;

        if (EquippedAccessory != null)
            result += EquippedAccessory.Defense;

        return result;
    }

    #endregion
}