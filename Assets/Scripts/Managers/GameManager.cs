using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager Instance { get; private set; }

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

    #region Fields & Properties

    public Character Player { get; private set; }

    #endregion

    private void Start()
    {
        SetData();
    }

    #region Init

    private void SetData()
    {
        // 1. 플레이어 생성
        Player = new Character(
            id: "Moon",
            level: 1,
            baseMaxHP: 100,
            baseAttack: 10,
            baseDefense: 5,
            gold: 1000
        );

        // 2. 아이템 생성 & 인벤토리 추가
        var sword = new Item("Bronze Sword", "기본 브론즈 검", ItemType.Weapon, attack: 5, defense: 0);
        var armor = new Item("Leather Armor", "기본 가죽 갑옷", ItemType.Armor, attack: 0, defense: 3);
        var ring = new Item("Power Ring", "힘의 반지", ItemType.Accessory, attack: 2, defense: 1);

        Player.AddItem(sword);
        Player.AddItem(armor);
        Player.AddItem(ring);

        // 3. UI에 데이터 세팅
        UIManager.Instance.MainMenu.SetPlayer(Player);
        UIManager.Instance.Status.SetPlayer(Player);
        UIManager.Instance.Inventory.SetPlayer(Player);
    }

    #endregion
}
