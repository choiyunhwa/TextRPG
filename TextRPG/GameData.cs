using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TextRPG
{
    
    public class GameData
    {
        // 데이터 경로 저장. (C드라이브, Documents)
        private string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "playerData.json");

        public void SaveGameData(Player player)
        {
            string _playerJson = JsonConvert.SerializeObject(player, Formatting.Indented);
            File.WriteAllText(fileName, _playerJson);
            Console.WriteLine("저장이 완료되었습니다.");

            Thread.Sleep(2000);
        }

        public Player LoadGameData()
        {
            //저장 예외처리
            try 
            { 
                if(!File.Exists(fileName))
                {
                    Console.WriteLine("저장된 파일이 없습니다.");
                    return null;
                }
                string playerJson = File.ReadAllText(fileName);
                Player player = JsonConvert.DeserializeObject<Player>(playerJson);
                Console.WriteLine("저장된 파일을 불러왔습니다.");

                Thread.Sleep(2000);
                return player;
                
            }
            catch(Exception e)
            {
                TextWriter errorWriter = Console.Error;
                errorWriter.WriteLine("데이터 로드 중 오류가 발생하였습니다. : " + e.Message );


                return null;
            }

            
        }
    }
}
