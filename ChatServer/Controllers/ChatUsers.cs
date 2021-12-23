using ChatServer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using IO = System.IO;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Linq;
using System;
using Newtonsoft.Json;

namespace ChatServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ChatUsers : ControllerBase
    {

        [HttpPost("GetMessage")]
        public async Task<List<Message>> GetMessage(FilterMessage filterMessage)
        {
            string path = IO.Directory.GetCurrentDirectory() + @"\Messeges.json";

            IO.DirectoryInfo directoryInfo = new IO.DirectoryInfo(path);

             List<Message> messages = JsonConvert.DeserializeObject<List<Message>>(IO.File.ReadAllText(path));

            if (filterMessage.Filter)
            {
                if (filterMessage.DateEnd != new DateTime(0001, 1, 1))
                    return messages.Where(mes => mes.DateTimeMessege.Date >= filterMessage.DateStart.Date &&
                                                                       mes.DateTimeMessege.Date <= filterMessage.DateEnd.Date).ToList<Message>();
                else
                    return messages.Where(mes => mes.DateTimeMessege.Date == filterMessage.DateStart.Date).ToList<Message>();
            }
            else
                return messages;
        }

        [HttpPost("SendMessege")]
        public async Task<ActionResult> SaveMessege(Message messege)
        {
            string path = IO.Directory.GetCurrentDirectory() + @"\Messeges.json";


            if (!IO.File.Exists(path))
            {
                List<Message> messages = new List<Message>();
                messages.Add(messege);

               await using (IO.StreamWriter sw = IO.File.CreateText(path))
                {
                    sw.WriteLine(JsonConvert.SerializeObject(messages));
                }
            }
            else
            {
                List<Message> messages = JsonConvert.DeserializeObject<List<Message>>(IO.File.ReadAllText(path));

                messages.Add(messege);

                await using (IO.StreamWriter sw = IO.File.CreateText(path))
                {
                    sw.WriteLine(JsonConvert.SerializeObject(messages));
                }
            }

            return new OkResult();
        }


    }
}
