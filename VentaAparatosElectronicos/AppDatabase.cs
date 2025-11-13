using SQLite;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Maui.Storage;
using System;

namespace VentaAparatosElectronicos
{
    public static class AppDatabase
    {
        static SQLiteAsyncConnection _db;

        static async Task Init()
        {
            if (_db != null)
                return;

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "venta_aparatos.db3");
            _db = new SQLiteAsyncConnection(dbPath);

            await _db.CreateTableAsync<Usuario>();
            await _db.CreateTableAsync<InventarioItem>();
            await _db.CreateTableAsync<Trabajador>();
            await _db.CreateTableAsync<Cliente>();
            await _db.CreateTableAsync<Factura>();

            // Usuario por defecto
            var count = await _db.Table<Usuario>().CountAsync();
            if (count == 0)
            {
                await _db.InsertAsync(new Usuario
                {
                    Username = "admin",
                    Password = "1234"
                });
            }
        }

        // ---------- USUARIOS ----------
        public static async Task<Usuario> ValidarUsuarioAsync(string username, string password)
        {
            await Init();
            return await _db.Table<Usuario>()
                            .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }

        // ---------- INVENTARIO ----------
        public static async Task<List<InventarioItem>> GetInventarioAsync()
        {
            await Init();
            return await _db.Table<InventarioItem>().ToListAsync();
        }

        public static async Task AddInventarioAsync(InventarioItem item)
        {
            await Init();
            await _db.InsertAsync(item);
        }

        public static async Task DeleteInventarioAsync(InventarioItem item)
        {
            await Init();
            await _db.DeleteAsync(item);
        }

        // ---------- TRABAJADORES ----------
        public static async Task<List<Trabajador>> GetTrabajadoresAsync()
        {
            await Init();
            return await _db.Table<Trabajador>().ToListAsync();
        }

        public static async Task AddTrabajadorAsync(Trabajador t)
        {
            await Init();
            await _db.InsertAsync(t);
        }

        public static async Task DeleteTrabajadorAsync(Trabajador t)
        {
            await Init();
            await _db.DeleteAsync(t);
        }

        // ---------- CLIENTES ----------
        public static async Task<List<Cliente>> GetClientesAsync()
        {
            await Init();
            return await _db.Table<Cliente>().ToListAsync();
        }

        public static async Task AddClienteAsync(Cliente c)
        {
            await Init();
            await _db.InsertAsync(c);
        }

        public static async Task DeleteClienteAsync(Cliente c)
        {
            await Init();
            await _db.DeleteAsync(c);
        }

        // ---------- FACTURAS ----------
        public static async Task<List<Factura>> GetFacturasAsync()
        {
            await Init();
            return await _db.Table<Factura>().ToListAsync();
        }

        public static async Task AddFacturaAsync(Factura f)
        {
            await Init();
            await _db.InsertAsync(f);
        }

        public static async Task DeleteFacturaAsync(Factura f)
        {
            await Init();
            await _db.DeleteAsync(f);
        }
    }
}
