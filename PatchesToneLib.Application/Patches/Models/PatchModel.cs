﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PatchesToneLib.Application.Patches.Models
{
    public class PatchModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string FileName { get; set; }
        public string Genre { get; set; }
        public string Model { get; set; }
        public string Author { get; set; }
    }
}
