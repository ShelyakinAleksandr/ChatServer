﻿using System;

namespace ChatServer.Models
{
    public class FilterMessage
    {
        /// <summary>
        /// Нужна ли сортировка по дате
        /// </summary>
        public bool Filter { get; set; }
        /// <summary>
        /// Дата начала поиска
        /// </summary>
        public DateTime DateStart { get; set; }

        /// <summary>
        /// Дата завершения поиска
        /// </summary>
        public DateTime DateEnd { get; set; }
    }
}
