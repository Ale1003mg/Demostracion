using Dapper;
using Demo.apidat.dto.dto;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.apidat.dao.dao
{
    public interface IDao_Usuarios
    {
        Task<List<Dto_Usuarios>> Getall_Usuario();
        Task<Dto_Usuarios> GetID_Usuario(int idPC);
        Task<Boolean> Mante_Usuario(Dto_Usuarios usuario);

    }
    public  class Dao_Usuarios:IDao_Usuarios
    {
        public readonly string _Conexion;

        public Dao_Usuarios(IConfiguration configuration)
        {
            _Conexion = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Dto_Usuarios>> Getall_Usuario()
        {
            try
            {
                using (var conexion = new SqlConnection(_Conexion))
                {
                    var mante = "select * from Getall_Usuario()";
                    var lis = await conexion.QueryAsync<Dto_Usuarios>(mante);
                    return lis.ToList();
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Prueba", "(Demo.Apidat) Dao_Usuario GetallUsuario" + ex, EventLogEntryType.Error);
                return null;
                throw;
            }
        }

        public async Task<Dto_Usuarios> GetID_Usuario(int idPC)
        {
            try
            {
                using (var conex= new SqlConnection(_Conexion))
                {
                    var mante = "select * from Getid_Usuario(" + idPC + ")";
                    var lis = await conex.QueryAsync<Dto_Usuarios>(mante);
                    return lis.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Prueba", "(Demo.apidat) Dao_Usuario GetID_Usuario" + ex, EventLogEntryType.Error);
                return null;
               
                throw;
            }
        }

        public async Task<Boolean> Mante_Usuario(Dto_Usuarios usuario)
        {
            try
            {
                using (var conex= new SqlConnection(_Conexion))
                {
                    var mante = "ManteUsuarios";
                    var lis = await conex.QueryAsync(mante, usuario, commandType: CommandType.StoredProcedure, commandTimeout: null);
                    return true;
                }

            }
            catch (Exception ex)
            {

                EventLog.WriteEntry("Prueba", "(Demo.apidat) Dao_Usuario Mante_Usuario" + ex, EventLogEntryType.Error);
                return false;
                throw;
            }
        
        }

    }
}
