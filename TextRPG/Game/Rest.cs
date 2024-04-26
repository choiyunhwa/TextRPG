using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Rest
    {

        public void RecoveryStrength(Player player) 
        {
            int price = 500;

            if (player.playerInfor.health < 100)
            {
                if (player.playerInfor.gold >= price)
                {
                    player.playerInfor.gold -= price;
                    player.playerInfor.health = 100;

                    Console.WriteLine("휴식을 완료했습니다.");
                }
                else
                {
                    Console.WriteLine("Gold가 부족합니다");
                }
            }
            else
            {
                Console.WriteLine("현재 최대 체력입니다.");
            }

            Thread.Sleep(500);

        }
    }
}
