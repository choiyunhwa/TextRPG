using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        public void EquipItem(int num)
        {
            Item item = items[num - 1];
           
            if(item.isEquip)
            {
                Console.WriteLine("{0} 장착 해제했습니다.", item.ItemInfor.iName);
                item.isEquip = false;
            }
            else
            {
                Console.WriteLine("{0} 장착 했습니다.", item.ItemInfor.iName);
                item.isEquip = true;
            }
            SetItemStats(item, item.isEquip);
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


    }
}
