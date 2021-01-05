using System;
using System.Collections.Generic;

namespace WhatToBuy
{
    public class ListDto
    {
        public Guid Id {get;set;}
        public string Name {get;set;}
        public ICollection<Product> Products {get;set;}
    }
}