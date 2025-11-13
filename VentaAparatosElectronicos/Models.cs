using SQLite;
using System;

namespace VentaAparatosElectronicos
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50), Unique]
        public string Username { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }
    }

    public class InventarioItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }

    public class Trabajador
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Puesto { get; set; }
    }

    public class Cliente
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
    }

    public class Factura
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ClienteNombre { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
    }
}
