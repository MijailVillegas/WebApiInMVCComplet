using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class claseConexion
    {

        public string CadenaConexion { get; set; }
        public string Consulta { get; set; }
        public DataTable DT = new DataTable();
        private SqlDataAdapter AD;

        public claseConexion()
        {
            CadenaConexion = "";
            Consulta = "";
        }
        public claseConexion(string ConsultaSQL)
        {
            CadenaConexion = "";
            Consulta = ConsultaSQL;
        }
        public claseConexion(string ConsultaSQL, string Cadena)
        {
            CadenaConexion = Cadena;
            Consulta = ConsultaSQL;
        }

        public void Ejecutar()
        {
            if (CadenaConexion == "")
                return;
            else
            {
                SqlConnection cn = new SqlConnection(CadenaConexion);

                if (cn.State == ConnectionState.Closed) cn.Open();
                if (cn.State == ConnectionState.Broken) cn.Open();

                AD = new SqlDataAdapter(Consulta, cn);
                AD.SelectCommand.CommandType = CommandType.Text;
                AD.Fill(DT);
                cn.Close();
                cn.Dispose();
            }
        }

    }
}