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
            gameManager.textManager.InputField();

            //Console.Clear();

            ShowMainMenu(gameManager);
        }

        public void ShowMainMenu(GameManager gameManager)
        {
            int selectNum = 0;

            while (true)
            {
                Console.Clear();

                switch (currentStage)
                {
                    case EStage.SCENE_MAIN:
                        gameManager.textManager.ShowMainMenu();
                        gameManager.textManager.InputField();
                        selectNum = int.Parse(Console.ReadLine());
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
                            default:
                                gameManager.textManager.InputFailField();
                                break;
                        }
                        break;
                    case EStage.SCENE_STATUS:
                        gameManager.textManager.ShowStatusView(currentStage, gameManager.player);
                        selectNum = int.Parse(Console.ReadLine());
                        if (selectNum == 0)
                        {
                            currentStage = EStage.SCENE_MAIN;
                        }
                        else
                        {
                            gameManager.textManager.InputFailField();
                        }
                        break;
                    case EStage.SCENE_INVENTORY:
                        gameManager.textManager.ShowInventory(currentStage, gameManager.player);
                        selectNum = int.Parse(Console.ReadLine());
                        switch (selectNum)
                        {
                            case 0:
                                currentStage = EStage.SCENE_MAIN;
                                break;
                            case 1:
                                currentStage = EStage.SCENE_INVENTORY_EQUIP;
                                break;
                            default:
                                gameManager.textManager.InputFailField();
                                break;
                        }
                        break;
                    case EStage.SCENE_INVENTORY_EQUIP:
                        gameManager.textManager.ShowInventory(currentStage, gameManager.player);
                        selectNum = int.Parse(Console.ReadLine());
                        if (selectNum == 0)
                        {
                            currentStage = EStage.SCENE_INVENTORY;
                        }
                        else if(selectNum <= gameManager.player.invetory.items.Count)
                        {
                            gameManager.player.invetory.EquipItem(selectNum, gameManager.player);
                        }
                        else
                        {
                            gameManager.textManager.InputFailField();
                        }

                        break;
                    case EStage.SCENE_SHOP:
                        gameManager.textManager.ShowShopMenu(currentStage, gameManager.player, gameManager.shop, false);
                        selectNum = int.Parse(Console.ReadLine());
                        switch (selectNum)
                        {
                            case 0:
                                currentStage = EStage.SCENE_MAIN;
                                break;
                            case 1:
                                currentStage = EStage.SCENE_SHOP_BUY;
                                break;
                            case 2:
                                currentStage = EStage.SCEME_SHOP_SELL;
                                break;
                            default:
                                gameManager.textManager.InputFailField();
                                break;
                        }
                        break;
                    case EStage.SCENE_SHOP_BUY:
                        gameManager.textManager.ShowShopMenu(currentStage, gameManager.player, gameManager.shop, true);
                        selectNum = int.Parse(Console.ReadLine());
                        if (selectNum == 0)
                        {
                            currentStage = EStage.SCENE_SHOP;
                        }
                        else if(selectNum <= gameManager.shop.items.Count)//0외의 숫자를 눌렀을 때 / 아이템이 구매되는 곳
                        {
                            gameManager.shop.BuyItem(selectNum, gameManager.player.playerInfor.gold, gameManager.player);
                        }
                        else
                        {
                            gameManager.textManager.InputFailField();
                        }
                        break;
                    case EStage.SCEME_SHOP_SELL:
                        gameManager.textManager.ShowShopMenu(currentStage, gameManager.player, gameManager.shop, true);
                        selectNum = int.Parse(Console.ReadLine());
                        if(selectNum == 0)
                        {
                            currentStage = EStage.SCENE_SHOP;
                        }
                        else if(selectNum <= gameManager.shop.items.Count)
                        {
                            gameManager.shop.SellItem(selectNum, gameManager.player);
                        }
                        else
                        {
                            gameManager.textManager.InputFailField();
                        }
                        break;

                    default:
                        gameManager.textManager.InputFailField();
                        break;
                }                
            }
        }
    }
}
