﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TextRPG
{
    public class TextManager
    {
        
        public Dictionary<EStage, List<string>> titleInfors = new Dictionary<EStage, List<string>>()
        {
            { EStage.SCENE_MAIN, new List<string>{"메인 화면","메뉴를 선택해주세요." } },
            { EStage.SCENE_STATUS, new List<string>{ "상태 보기", "캐릭터의 정보가 표기됩니다." } },
            { EStage.SCENE_INVENTORY, new List<string>{ "인벤토리", "보유 중인 아이템을 관리할 수 있습니다." } },
            { EStage.SCENE_INVENTORY_EQUIP, new List<string>{"인벤토리 - 장착 관리","캐릭터의 정보가 표기됩니다." } },
            { EStage.SCENE_SHOP, new List<string>{ "상점", "필요한 아이템을 얻을 수 있는 상점입니다." } },
            { EStage.SCENE_SHOP_BUY, new List<string>{ "상점 - 아이템 구매", "필요한 아이템을 얻을 수 있는 상점입니다." } },
        };

        public string SetPlayerInfor()
        {
            string job = "";
            Console.WriteLine("\n\n\n\n");
            Console.Write(String.Format("{0}", "닉네임 : ").PadLeft(42 - (21 - ("닉네임 : ".Length / 2)))); 
            string nick = Console.ReadLine();
            Console.WriteLine(String.Format("{0}", "1. 전사 2. 마법사").PadLeft(42 - (21 - ("1. 전사 2. 마법사".Length / 2))));
            Console.Write(String.Format("{0}", "직업 선택 : ").PadLeft(42 - (21 - ("직업 선택 : ".Length / 2))));
            string num = Console.ReadLine();

            if(num == "1")
            {
                job = "전사";
            }
            else if(num == "2")
            {
                job = "마법사";
            }
            else
            {
                Console.WriteLine("다시 입력해주세요.");
                Console.ReadLine();
            }

            return nick + "." + job;
        }

        public void StartGameView()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");

            ShowMainMenu();
        }

        public void ShowMainMenu()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
        }
        public void InputFiled()
        {
            Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
        }

        public void TileMenu(EStage stageName)
        {
            if(titleInfors.ContainsKey(stageName))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(titleInfors[stageName][0]);
                Console.ResetColor();
                Console.WriteLine($"{titleInfors[stageName][1]}\n\n");
                
            }
        }
        public void ShowStatusView(EStage stage, Player player)
        {
            TileMenu(stage);
            Console.WriteLine("LV.{0}", player.playerInfor.level);
            Console.WriteLine("Chad ({0})", player.playerInfor.job);
            Console.Write("공격력 : {0}", player.playerInfor.power);

            
            if(player.invetory.isPower)
            {
                Console.WriteLine("({0})",player.invetory.playerEquip.power);
            }
            Console.Write("\n방어력 : {0}", player.playerInfor.defense);
            if (player.invetory.isDefense)
            {
                Console.WriteLine(" ( {0} )", player.invetory.playerEquip.defense);
            }
            Console.WriteLine("\n체 력 : {0}", player.playerInfor.health);
            Console.WriteLine("Gold : {0} G", player.playerInfor.gold);
            Console.WriteLine("\n");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("\n");
            InputFiled();
        }
        public void ShowInventory(EStage stage, Player player)
        {
            TileMenu(stage);
            Console.WriteLine("[아이템 목록]");
            ShowInvenItemList(player.invetory.items);
            SelectInventoryMenu(stage);
        }
        public void SelectInventoryMenu(EStage stage)
        {
            switch(stage)
            {
                case EStage.SCENE_INVENTORY:
                    Console.WriteLine("\n1. 장착 관리");
                    Console.WriteLine("0. 나가기");
                    break;
                case EStage.SCENE_INVENTORY_EQUIP:
                    Console.WriteLine("\n0. 나가기");
                    break;
            }
        }

        public void ShowShopMenu(EStage stage, Player player, ShopManager shop, bool openShop)
        {
            TileMenu(stage);
            Console.WriteLine("[보유 골드]");
            Console.WriteLine("{0} G\n", player.playerInfor.gold);
            Console.WriteLine("[아이템 목록]");
            ShowShopItemList(shop.items, openShop);
            SelectShopMenu(stage);
            InputFiled();
        }
        public void SelectShopMenu(EStage stage)
        {
            switch(stage)
            {
                case EStage.SCENE_SHOP:
                    Console.WriteLine("\n1. 아이템 구매");
                    Console.WriteLine("0. 나가기");
                    break;
                case EStage.SCENE_SHOP_BUY:
                    Console.WriteLine("\n0. 나가기");
                    break;
            }
        }
        public void ShowInvenItemList(List<Item> items)
        {
            if (items.Count <= 0)
            {
                Console.WriteLine("보유한 장비가 없습니다.");
                return;
            }
            foreach (Item item in items)
            {
                string check = item.isEquip ? "[E] " : "";

                switch(item.itemType)
                {
                    case EItem.ARMOR:
                        Console.Write($"- {check}{item.ItemInfor.iName} | 방어력 +{item.ItemInfor.iDefense} | {item.ItemInfor.explain} ");
                        break;
                    case EItem.WEAPON:
                        Console.Write($"- {check}{item.ItemInfor.iName} | 공격력 +{item.ItemInfor.iDefense} | {item.ItemInfor.explain} ");
                        break;
                }
            }
        }
        public void ShowShopItemList(List<Item> items, bool openShop)
        {
            
            int i = 0;
            foreach (Item item in items)
            {
                string check = openShop ? $"{++i} " : "";
                switch (item.itemType)
                {
                    case EItem.ARMOR:
                        Console.Write($"- {check}{item.ItemInfor.iName} | 방어력 +{item.ItemInfor.iDefense} | {item.ItemInfor.explain} | "); 
                        break;
                    case EItem.WEAPON:
                        Console.Write($"- {check}{item.ItemInfor.iName} | 공격력 +{item.ItemInfor.iDefense} | {item.ItemInfor.explain} | ");
                        break;
                }

                string Aprice = item.isBuy ? "구매 완료" : item.ItemInfor.price.ToString() + "G";
                Console.Write($"{Aprice}\n");
            }
        }

        
    }
}