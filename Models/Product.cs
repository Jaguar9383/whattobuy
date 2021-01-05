using System;

namespace WhatToBuy
{
    public class Product
    {
        public Guid Id {get;set;}
        public Guid ListId {get;set;}
        public string Name {get;set;}
        public bool IsChecked {get;set;}

        public virtual ToBuyList List {get;set;}
    }
}