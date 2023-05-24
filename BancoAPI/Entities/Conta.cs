
namespace BancoAPI.Entities
{
    public class Conta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Saldo { get; set; }
        public bool IsDeleted { get; set; }

        public void Update(double saldo)
        {
            Saldo = saldo;
        }
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
