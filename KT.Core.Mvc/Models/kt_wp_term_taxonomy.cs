﻿using System;
namespace KT.Core.Mvc.Models
{

    public class wp_term_taxonomy
    {
        public UInt64 term_taxonomy_id { get; set; }
        public UInt64 term_id { get; set; }
        public string taxonomy { get; set; }
        public string description { get; set; }
        public UInt64 parent { get; set; }
        public UInt64 count { get; set; }
    }
}
