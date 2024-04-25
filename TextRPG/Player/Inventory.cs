using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Inventory
    {
        public List<Item> items = new List<Item>();
        public bool isDefense = false;
        public bool isPower = false;

        public PlayerEquipment playerEquip;
        public void EquipItem(int num, Player player)
        {
            Item item = items[num - 1];
            Item equipItem = player.equipedItems.Find(x => x.itemType == item.itemType);
            
            //ERROR
            //List안에 같은 옵션의 장비의 정보
            //이미 장착한 아이템이 있고 장착한 아이템과 같지 않을때          

            if(player.equipedItems.Count > 0 && (CheckEquip(item, player) != 1 ||  !item.Equals(item)))
            {
                player.equipedItems.Remove(equipItem);
                player.equipedItems.Add(item);
                Console.WriteLine("{0}에서 {1}으로 장비를 변경하였습니다.", equipItem.ItemInfor.iName,item.ItemInfor.iName);
                item.isEquip = true;
                equipItem.isEquip = false;

            }

            if (item.isEquip || player.equipedItems.Contains(item))
            {
                Console.WriteLine("{0} 장착 해제했습니다.", item.ItemInfor.iName);
                player.equipedItems.Remove(item);
                item.isEquip = false;
            }
            else
            {
                Console.WriteLine("{0} 장착 했습니다.", item.ItemInfor.iName);
                player.equipedItems.Add(item);
                item.isEquip = true;
            }
            SetItemStats(item, item.isEquip);
            Thread.Sleep(500);
        }
        /// <summary>
        /// 플레이어의 장착 아이템 확인 유무 없으면 -1 반환
        /// </summary>
        /// <param name="item"></param>
        /// <param name="player"></param>
        /// <returns></returns>
        public int CheckEquip(Item item, Player player)
        {
            return player.equipedItems.FindIndex(x => x.itemType.Equals(item.itemType));
        }

        public void SetItemStats(Item item, bool isEquip)
        {
            int num = isEquip ? 1 : -1;

            switch(item.itemType) 
            {
                case EItem.ARMOR:
                    playerEquip.defense += item.ItemInfor.iDefense * num;
                    isDefense = isEquip;
                    break;
                case EItem.WEAPON:
                    playerEquip.power += item.ItemInfor.iPower * num;
                    isPower = isEquip;
                    break;            
            }
        }
        public void GetItem(Item item)
        {
            items.Add(item);
        }
        
        public void SetItem(Item item)
        {
            items.Remove(item);
        }


    }
}
