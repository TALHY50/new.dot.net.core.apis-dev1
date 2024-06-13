﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMT.PayAll.Model;

namespace IMT.PayAll.Response.Common
{
    public class SourceAmount
    {
        private string _currency;
        [Required]
        [MaxLength(3)]
        [MinLength(3)]
        public string currency
        {
            get => _currency;
            set
            {
                if (!Enum.GetNames(typeof(Currency)).Contains(value))
                {
                    throw new InvalidOperationException($"Invalid Currency: {value}");
                }
                _currency = value;
            }
        }
        [Required]
        public int value { get; set; }
    }
}
