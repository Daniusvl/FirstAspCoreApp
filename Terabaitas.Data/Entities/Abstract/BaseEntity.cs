﻿using System;

namespace Terabaitas.Data.Entities.Abstract
{
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
