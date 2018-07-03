using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;
using System.Collections;



namespace Data.ServiceObject
{
    class SO_Clientes
    {
        public int AltaClientes(DO_Clientes clientes)
        {
            try
            {
                using (var conexion = new EntitiesERP())
                {
                    Clientes obj = new Clientes();
                    obj.Id_Clientes = clientes.Id_Cliente;
                    obj.Nombre = clientes.Nombre;
                    obj.RFC = clientes.RFC;
                    obj.Telefono = clientes.Telefono;
                    obj.Direccion = clientes.Direccion;
                    obj.Correo = clientes.Correo;

                    conexion.Clientes.Add(obj);
                    return conexion.SaveChanges();
                }
            }
            catch (Exception)
            {

                return 0;
            }

        }
        public int BorrarClientes(int Id_Cliente)
        {
            try
            {
                using (var conexion = new EntitiesERP())
                {
                    Clientes obj = conexion.Clientes.Where(x => x.Id_Clientes == Id_Cliente).FirstOrDefault();

                    conexion.Entry(obj).State = EntityState.Deleted;
                    return conexion.SaveChanges();
                }
            }
            catch (Exception)
            {
                return 0;
            }

        }
        public int ActualizarCliente(DO_Clientes cliente)
        {
            try
            {

                using (var conexion = new EntitiesERP())
                {
                    Clientes obj = conexion.Clientes.Where(x => x.Id_Clientes == cliente.Id_Cliente).FirstOrDefault();

                    obj.Id_Clientes = cliente.Id_Cliente;
                    obj.Nombre = cliente.Nombre;
                    obj.RFC = cliente.RFC;
                    obj.Telefono = cliente.Telefono;
                    obj.Direccion = cliente.Direccion;
                    obj.Correo = cliente.Correo;


                    conexion.Entry(obj).State = EntityState.Modified;
                    return conexion.SaveChanges();
                }
            }
            catch (Exception)
            {

                return 0;
            }

        }
        public IList ObtenerTodos()
        {
            try
            {
                using (var conexion = new EntitiesERP())
                {
                    var Lista = (from tabla in conexion.Clientes select tabla).ToList();

                    return Lista;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}

