using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatServer.Models
{
    /// <summary>
    /// Класс модели принятого сообщения
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Время отправки
        /// </summary>
        public DateTime DateTimeMessege { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string NameUser { get; set; }
        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Messeges { get; set; }
    }
}
