using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TextRPG.Game
{
    public class Dungeon
    {
        private bool isClear = false;
        public int tempHealth { get; set; }
        public int tempLevel { get; set; }
        public float tempGold { get; set; }
        public string dungeonName { get; set; }

        public bool ISClear
        {
            get
            {
                return isClear;
            }
            set
            {
                isClear = value;
            }
        }

        public void SelectDungeon(EDifficulty dongon, Player player)
        {
            switch (dongon)
            {
                case EDifficulty.EASY:
                    dungeonName = "쉬운";
                    SettingDungeon(player, 5, 1000);
                    break;
                case EDifficulty.MIDDLE:
                    dungeonName = "일반";
                    SettingDungeon(player, 11, 1700);
                    break;
                case EDifficulty.HIGHT:
                    dungeonName = "어려운";
                    SettingDungeon(player, 17, 2500);
                    break;
            }
        }

        public void SettingDungeon(Player player, int recommended, int coin)
        {
            Random random = new Random();

            tempHealth = player.playerInfor.health;
            tempLevel = player.playerInfor.level;
            tempGold = player.playerInfor.gold;

            int defenseValue = (player.playerInfor.defense + player.playerEquip.defense) - recommended;
            int damage = random.Next(20 - defenseValue, 36 - defenseValue);
            int powerValue = random.Next(player.playerInfor.power, player.playerInfor.power * 2);

            if (player.playerInfor.health > 0)
            {
                if (player.playerInfor.defense > recommended) //방어력이 이상일 때
                {
                    ClearDoungeon(player, player.playerInfor.health, tempLevel, coin, damage, powerValue);
                }
                else // 방어력이 낮을 때
                {
                    if (random.NextDouble() < 0.4) //40%확률로 실패
                    {
                        isClear = false;

                        int newHealth = tempHealth >> 1;

                        if (newHealth < tempHealth)
                        {
                            player.playerInfor.health -= newHealth;
                        }
                        else
                        {
                            player.playerInfor.health = 0;
                        }
                    }
                    else
                    {
                        player.playerInfor.health -= damage;
                        ClearDoungeon(player, player.playerInfor.health, tempLevel, coin, damage, powerValue);
                    }
                }
            }
            else
            {
                Console.WriteLine($"{0}의 체력이 부족합니다.");
            }
        }

        private void ClearDoungeon(Player player, int health, int level, float gold, int damage, int power)
        {
            isClear = true;

            float addGold = ( gold / 100) * power;

            if (health > damage)
            {
                player.playerInfor.health -= damage;
            }
            else
            {
                player.playerInfor.health = 0;
            }
            player.playerInfor.gold += addGold;
        }
    }
}
