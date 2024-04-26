using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace TextRPG
{
    public class GameMain
    {
        static void Main(string[] args)
        {
            Console.Title = "Text RPG";
            Console.SetWindowSize(100, 20);
            Console.CursorVisible = false;

            GameManager gameManager = new GameManager();

            gameManager.gameStart.GameIntro(gameManager);

        }
    }
}
