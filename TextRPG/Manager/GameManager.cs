using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class GameManager
    {
        public TextManager textManager;
        public ShopManager shop;
        public GameStart gameStart;
        public Player player;

        public GameManager()
        {
            this.textManager = new TextManager();
            string plInfor = textManager.SetPlayerInfor();
            string[] splitInfor = plInfor.Split('.');

            this.shop = new ShopManager();
            this.gameStart = new GameStart();
            this.player = new Player(splitInfor[0], splitInfor[1]);
            shop.SettingShopData();
        }

    }
}
