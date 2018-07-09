﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Data.SQLServer
{
    public class ERP_SQL
    {
        private string StringDeConexion = string.Empty;

        public ERP_SQL()
        {
            StringDeConexion  = System.Configuration.ConfigurationManager.AppSettings["CadenaConexion"];
        }

        /// <summary>
        /// Método que ejecuta un procedimiento almacenado de la base de datos.
        /// </summary>
        /// <param name="nombreProcedimientoAlmacenado">Nombre del procedimiento almacenado que se requiere ejecutar.</param>
        /// <param name="parametros">Diccionario de datos con el nombre de los parámetros y su valor.</param>
        /// <returns>DataSet con la información resultante del procedimiento almacenado.</returns>
        public DataSet EjecutarStoredProcedure(string nombreProcedimientoAlmacenado, Dictionary<string, object> parametros)
        {
            //Creamos un objeto Dataset que será el que contendrá los resultados del procedimiento almacenado.
            DataSet data = new DataSet();

            try
            {

                //Verificamos que la cadena de conexión sea válida y que el nombre del procedimiento sea direfenre de vacío.
                if (StringDeConexion != string.Empty && !string.IsNullOrEmpty(nombreProcedimientoAlmacenado))
                {

                    //Declaramos la conexión con el string definido.
                    using (SqlConnection DBConnection = new SqlConnection(StringDeConexion))
                    {

                        //Declaramos un comando de SQL indicando el nombre del procedimiento y la conexión.
                        SqlCommand sqlCommand = new SqlCommand(nombreProcedimientoAlmacenado, DBConnection);

                        //Indicamos que será un procedimiento almacenado.
                        sqlCommand.CommandType = CommandType.StoredProcedure;

                        //Iteramos la lista de parámetros y los asginamos al comando.
                        foreach (var parametro in parametros)
                        {
                            sqlCommand.Parameters.AddWithValue(parametro.Key, parametro.Value);
                        }

                        //Inicializamos un dataadapter
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = sqlCommand;

                        //Llenamos el dataset con el resultado de la Base de datos
                        adapter.Fill(data);
                    }
                }
            }
            catch (Exception)
            {
                //Registrar el error.
            }
            finally
            {

            }
            //Retornamos el dataset.
            return data;
        }

    }
}
