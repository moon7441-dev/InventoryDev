using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("Item Icons")]
    [SerializeField] private Sprite iconSword;
    [SerializeField] private Sprite iconArmor;
    [SerializeField] private Sprite iconRing;
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
        // 플레이어 생성
        Player = new Character(
            id: "Moon",
            level: 1,
            baseMaxHP: 100,
            baseAttack: 40,
            baseDefense: 50,
            gold: 2200
        );

        // 아이템 생성 & 인벤토리 추가
        var sword = new Item("Sword", "기본 검", ItemType.Weapon, attack: 5, defense: 0, icon: iconSword);
        var armor = new Item("Iron Armor", "기본 강철 갑옷", ItemType.Armor, attack: 0, defense: 3, icon: iconArmor);
        var ring = new Item("Power Ring", "힘의 반지", ItemType.Accessory, attack: 2, defense: 1, icon: iconRing);

        Player.AddItem(sword);
        Player.AddItem(armor);
        Player.AddItem(ring);

        // UI에 데이터 세팅
        UIManager.Instance.MainMenu.SetPlayer(Player);
        UIManager.Instance.Status.SetPlayer(Player);
        UIManager.Instance.Inventory.SetPlayer(Player);


    }

    #endregion
}
