using ChatServer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace ChatServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChatUsers : ControllerBase
    {

        [HttpPost("GetMessage")]
        public async Task<List<Message>> GetMessage(FilterMessage filterMessage)
        {
            string path = Directory.GetCurrentDirectory() + @"\Messeges";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            FileInfo[] allFile = directoryInfo.GetFiles();

            List<Message> meseges = new List<Message>();

            foreach (FileInfo file in allFile)
            {
                if (file.Extension == ".json")
                {
                    string line;

                    using (StreamReader reader = new StreamReader(new FileStream(file.FullName, FileMode.Open)))
                    {
                        line = reader.ReadLine();
                    }

                    meseges.Add(JsonSerializer.Deserialize<Message>(line));
                }
            }

            if (filterMessage.Filter)
            {
                if (filterMessage.DateEnd != new DateTime(0001, 1, 1))
                    return meseges.Where(mes => mes.DateTimeMessege.Date >= filterMessage.DateStart.Date &&
                                                                       mes.DateTimeMessege.Date <= filterMessage.DateEnd.Date).ToList<Message>();
                else
                    return meseges.Where(mes => mes.DateTimeMessege.Date == filterMessage.DateStart.Date).ToList<Message>();
            }
            else
                return meseges;
        }

        [HttpPost("SendMessege")]
        public async Task<ActionResult> SaveMessege(Message messege)
        {
            string path = Directory.GetCurrentDirectory() + @"\Messeges";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            if (!directoryInfo.Exists)
                directoryInfo.Create();

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };

            await using FileStream fileStream = System.IO.File.Create(path+@"\" + messege.DateTimeMessege.ToString("dd.MM.yyyy hh.mm.ss") + ".json");
            await JsonSerializer.SerializeAsync(fileStream, messege);

            return new OkResult();
        }


    }
}
