﻿using Seminar_Tihomir_Samardzija.Models.Base;

namespace Seminar_Tihomir_Samardzija.Models.Binding
{
    public class ProductCategoryBinding : ProductCategoryBase
    {
    }

    public class ProductCategoryUpdateBinding : ProductCategoryBinding
    {
        public int Id { get; set; }
    }
}