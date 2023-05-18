using BancoAPI.Entities;

namespace BancoAPI.Persistance
{
    public class DBcontext
    {
        public List<Conta> Contas { get; set; }



        public DBcontext()
        {
            Contas = new List<Conta>();
        }
    }
}
