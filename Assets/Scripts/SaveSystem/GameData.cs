using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    public List<Inventory_Item> itemList;
    public SerializableDictionary<string, int> inventory;
    public SerializableDictionary<string, ItemType> equipedItems;

    public int skillPoints;
    public SerializableDictionary<string, bool> skillTreeUI;
    public SerializableDictionary<SkillType, SkillUpgradeType> skillUpgrades;

    public SerializableDictionary<string, bool> unlockedCheckpoints;

    public string lastScenePlayed;
    public Vector3Data lastPlayerPosition;

    public GameData()
    {
        inventory = new SerializableDictionary<string, int>();
        equipedItems = new SerializableDictionary<string, ItemType>();

        skillTreeUI = new SerializableDictionary<string, bool>();
        skillUpgrades = new SerializableDictionary<SkillType, SkillUpgradeType>();

        unlockedCheckpoints = new SerializableDictionary<string, bool>();
    }
}
