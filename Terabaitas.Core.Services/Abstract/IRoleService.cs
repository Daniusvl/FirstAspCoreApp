namespace Terabaitas.Core.Services.Abstract
{
    public interface IRoleService
    {
        void Add(string role_name);
        void Remove(string role_name);
    }
}