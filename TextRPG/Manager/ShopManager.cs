using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class ShopManager
    {
        public List<Item> items = new List<Item>();

        public void SettingShopData()
        {
            items.Add(new Item(EItem.ARMOR, "수련자 갑옷", +5, "수련에 도움을 주는 갑옷입니다.", 1000));
            items.Add(new Item(EItem.ARMOR, "무쇠갑옷", +9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 700));
            items.Add(new Item(EItem.ARMOR, "스파르타의 갑옷", +15, "수련에 도움을 주는 갑옷입니다.", 3500));
            items.Add(new Item(EItem.WEAPON, "낡은 검", +2, "쉽게 볼 수 있는 낡은 검 입니다.", 600));
            items.Add(new Item(EItem.WEAPON, "청동 도끼", +5, "어디선가 사용됐던거 같은 도끼입니다.", 1500));
            items.Add(new Item(EItem.WEAPON, "스파르타의 창", +7, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 2500));
        }

        

        public void BuyItem(int num, int money, Player player)
        {
            Item item = items[num - 1];

            if (item.isBuy)
            {
                Console.WriteLine("{0}은 이미 구매한 아이템입니다.", item.ItemInfor.iName);
            }
            else
            {
                if (item.ItemInfor.price > money)
                    Console.WriteLine("잔액이 : {0}으로 구매가 불가능합니다.", money);
                else
                {
                    player.BuyItem(item.ItemInfor.price, items[num - 1]);
                    items[num - 1].isBuy = true;
                    Console.WriteLine("{0} 구매하였습니다.", item.ItemInfor.iName);
                }
            }
            Thread.Sleep(500);
        }
    }
}
