using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public struct PlayerInfo
    {
        public string name; //이름
        public int level; //레벨
        public string job; //직업
        public int power; //공격력
        public int defense; //방어력
        public int health; //방어력
        public int gold; //골드
    }

    public struct PlayerEquipment
    {
        public int power; //공격력
        public int defense; //방어력
    }

    public class Player
    {
        public PlayerInfo playerInfor;
        public Inventory invetory = new Inventory();
        public List<Item> equipedItems = new List<Item>();
        public Player(string _name, string _job)
        {
            playerInfor.name = _name;
            playerInfor.level = 0;
            playerInfor.job = _job;
            playerInfor.health = 100;
            playerInfor.power = 10;
            playerInfor.defense = 5;
            playerInfor.gold = 1500;
        }

        public void BuyItem(int money, Item item)
        {
            playerInfor.gold -= money;
            invetory.GetItem(item);
        }
    }
}
