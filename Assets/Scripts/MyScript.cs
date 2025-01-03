using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{

    class Item
    {
        public string name = "Unnamed Item";
        public string description = "Undescribed Item";
        public int worth = 1;
        public bool canBeSold = true;
        public int weight = 0;

        public Item(string name, string description, int worth, bool canBeSold, int weight)
        {
            this.name = name;
            this.description = description;
            this.worth = worth;
            this.canBeSold = canBeSold;
            this.weight = weight;
        }
    }

    class Equipment:Item
    {
        public int currentDurability = 100;
        public int maxDurability = 100;

        public Equipment(string name, string description, int worth, bool canBeSold, int weight, int maxDurability):base(name, description, worth, canBeSold, weight)
        {
            //Zastosuj maksymalną trwałość:
            this.maxDurability = maxDurability;

            //Ustaw bieżącą trwałość na maksymalną trwałość:
            currentDurability = maxDurability;
        }
    }

    enum ArmorType
    {
        Helmet,
        Chest,
        Gloves,
        Girdle,
        Boots
    }

    class Armor:Equipment
    {
        public ArmorType type = ArmorType.Helmet;
        public int defense = 1;

        public Armor(string name, string description, int worth, bool canBeSold, int weight, int maxDurability, ArmorType type, int defense):base(name, description, worth, canBeSold, weight, maxDurability)
        {
            this.type = type;
            this.defense = defense;
        }
    }

    enum WeaponType
    {
        Sword,
        Axe,
        Hammer,
        Staff
    }

    class Weapon:Equipment
    {
        public WeaponType type = WeaponType.Sword;
        public int minDamage = 1;
        public int maxDamage = 2;
        public float attackTime = 0.6f;
        public bool dealsBluntDamage = false;

        public Weapon(string name, string description, int worth, bool canBeSold, int weight, int maxDurability, WeaponType type, int minDamage, int maxDamage, float attackTime):base(name, description, worth, canBeSold, weight, maxDurability)
        {
            this.type = type;
            this.minDamage = minDamage;
            this.maxDurability = maxDamage;
            this.attackTime = attackTime;

            // Ustaw dealsBluntDamage w oparciu o typ broni:
            if (type == WeaponType.Sword || type == WeaponType.Axe)
                dealsBluntDamage = false;
            else 
                dealsBluntDamage = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Item item = new Weapon("Rusty Axe", "A beat-up rusty axe", 4, true, 8, 40, WeaponType.Axe, 4, 9, 0.6f);

        Weapon weapon = (Weapon)item;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

}
