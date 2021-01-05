using System;

namespace WhatToBuy
{
    public class ProductDto
    {
        public Guid Id {get;set;}
        public Guid ListId {get;set;}
        public string Name {get;set;}
        public bool IsChecked {get;set;}

        public ToBuyList List {get;set;}
    }
}