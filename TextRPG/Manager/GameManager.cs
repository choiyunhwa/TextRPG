using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Game;

namespace TextRPG
{
    public class GameManager
    {
        public TextManager textManager;
        public ShopManager shop;
        public GameStart gameStart;
        public Player player;
        public Dungeon dungeon;
        public Rest rest;
        public GameData gameData;
        public GameManager()
        {
            this.textManager = new TextManager();

            int num = textManager.SelectGameLoad();

            this.shop = new ShopManager();
            this.gameStart = new GameStart();            
            this.dungeon = new Dungeon();
            this.rest = new Rest();
            this.gameData = new GameData();

            switch(num)
            {
                case 1:
                    Console.Clear();
                    string plInfor = textManager.SetPlayerInfor();
                    string[] splitInfor = plInfor.Split('.');
                    this.player = new Player(splitInfor[0], splitInfor[1]);
                    break;
                case 2:
                    this.player = gameData.LoadGameData();
                    break;
                default:
                    Console.WriteLine("\n잘못 입력했습니다. 다시 입력해주세요.");
                    Console.ReadLine();
                    break;
            }
            shop.SettingShopData();
        }
    }
}
