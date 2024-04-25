using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public enum EStage
    {
        SCENE_MAIN = 0,
        SCENE_STATUS,
        SCENE_INVENTORY,
        SCENE_INVENTORY_EQUIP,
        SCENE_SHOP,
        SCENE_SHOP_BUY,
    }

    public enum EItem
    {
        WEAPON = 0, //무기
        ARMOR, //갑옷
    }
}
