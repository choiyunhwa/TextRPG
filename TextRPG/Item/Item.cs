using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{    public struct ItemInfor
    {
        public string iName; //아이템 이름
        public int iPower; //아이템 공격력
        public int iDefense; //아이템 방어력
        public string explain; //아이템 설명
        public int price; //아이템 가격
    }
    public class Item : IItemBuy
    {
        public ItemInfor ItemInfor;
        public EItem itemType;
        public bool isBuy = false;
        public bool isEquip = false;
        public Item(EItem _itemType, string _name, int _value, string _explain, int _price)
        {
            this.itemType = _itemType;
            this.ItemInfor.iName = _name;
            this.ItemInfor.price = _price; 
            this.ItemInfor.explain = _explain;
            if(itemType == EItem.WEAPON)
            {
                this.ItemInfor.iPower = _value;
            }
            else 
            { 
                this.ItemInfor.iDefense = _value;
            }
        }
        public void Buy()
        {
            this.isBuy = true;
        }
    }
}
