using System;

namespace Terabaitas.Data.Entities.Abstract
{
    public interface IBaseEntity
    {
        DateTime DateCreated { get; set; }
        int Id { get; set; }
    }
}