using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Game
{
    public class Dungeon
    {
        private Random random = new Random();

        public void SelectDungeon(EDifficulty dongon)
        {
            switch (dongon) 
            {
                case EDifficulty.EASY:
                    break;
                case EDifficulty.MIDDLE:
                    break;
                case EDifficulty.HIGHT:
                    break;
            }
        }
        
        public void SettingDungeon(Player player, int recommended, int coin)
        {
            int damage = random.Next(20,36);

            if(player.playerInfor.defense > recommended) //방어력이 이상일 때
            {

            }
            else
            {
                if(random.NextDouble() < 0.4) // 방어력이 낮을 때
                {

                }
            }
            
        }
    }
}
