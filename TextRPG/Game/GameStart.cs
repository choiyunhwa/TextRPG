using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    //문제 
    //값을 두번 입력해야지 해당화면이나옴
    //화면이 갱신이 안됨
    public class GameStart
    {
        private EStage currentStage = EStage.SCENE_MAIN;

        public void GameIntro(GameManager gameManager)
        {
            gameManager.textManager.StartGameView();
            gameManager.textManager.InputFiled();

            Console.Clear();

            ShowMainMenu(gameManager);
        }

        public void ShowMainMenu(GameManager gameManager)
        {
                
            while (true)
            {
                int selectNum = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (currentStage)
                {
                    case EStage.SCENE_MAIN:
                        gameManager.textManager.ShowMainMenu();
                        gameManager.textManager.InputFiled();
                        switch (selectNum)
                        {
                            case 1:
                                currentStage = EStage.SCENE_STATUS;
                                break;
                            case 2:
                                currentStage = EStage.SCENE_INVENTORY;
                                break;
                            case 3:
                                currentStage = EStage.SCENE_SHOP;
                                break;
                        }
                        break;
                    case EStage.SCENE_STATUS:
                        gameManager.textManager.ShowStatusView(currentStage, gameManager.player);
                        if (selectNum == 0)
                        {
                            currentStage = EStage.SCENE_MAIN;
                        }
                        break;
                    case EStage.SCENE_INVENTORY:
                        gameManager.textManager.ShowInventory(currentStage, gameManager.player);
                        switch (selectNum)
                        {
                            case 0:
                                currentStage = EStage.SCENE_MAIN;
                                break;
                            case 1:
                                currentStage = EStage.SCENE_INVENTORY_EQUIP;
                                break;
                        }
                        break;
                    case EStage.SCENE_INVENTORY_EQUIP:
                        gameManager.textManager.ShowInventory(currentStage, gameManager.player);
                        if (selectNum == 0)
                        {
                            currentStage = EStage.SCENE_INVENTORY;
                        }
                        else
                        {
                            gameManager.player.invetory.EquipItem(selectNum);
                        }

                        break;
                    case EStage.SCENE_SHOP:
                        gameManager.textManager.ShowShopMenu(currentStage, gameManager.player, gameManager.shop, false);
                        switch (selectNum)
                        {
                            case 0:
                                currentStage = EStage.SCENE_MAIN;
                                break;
                            case 1:
                                currentStage = EStage.SCENE_SHOP_BUY;
                                break;
                        }
                        break;
                    case EStage.SCENE_SHOP_BUY:
                        gameManager.textManager.ShowShopMenu(currentStage, gameManager.player, gameManager.shop, true);

                        if (selectNum == 0)
                        {
                            currentStage = EStage.SCENE_SHOP;
                        }
                        else //0외의 숫자를 눌렀을 때 / 아이템이 구매되는 곳
                        {
                            gameManager.shop.BuyItem(selectNum, gameManager.player.playerInfor.gold, gameManager.player);
                        }
                        break;
                    default:
                        Console.WriteLine("다시 선택해주세요.");
                        break;
                }
                
                Console.WriteLine(currentStage);
            }
        }
    }
}
