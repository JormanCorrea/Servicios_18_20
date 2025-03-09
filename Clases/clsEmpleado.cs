using Servicios_18_20.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Servicios_18_20.Clases
{
	public class clsEmpleado
	{
		private DBSuperEntities dbSuper = new DBSuperEntities(); //OBJETO PARA GESTIONAR DATOS DE LA BASE DE DATOS
		public EMPLeado empleado { get; set; } //OBJETO TIPO EMPLEADO PARA GESTIONAR CRUD DE LA BASE DE DATOS

		public String Insertar()
		{
            try //INTENTAR INSERTAR UN EMPLEADO EN LA BASE DE DATOS
            {
				dbSuper.EMPLeadoes.Add(empleado); //AGREGAR UN EMPLEADO A LA LISTA DE ENTITY FRAMEWORK, SE DEBE INVOCAR EL METODO SAVECHANGES PARA GUARDAR EN LA BD
				dbSuper.SaveChanges(); //GUARDAR EN LA BASE DE DATOS
                return "Empleado insertado correctamente"; //RETORNAR MENSAJE DE EXITO
            }
			catch (Exception ex) //CAPTURAR ERROR
            {
                return "Error al insertar el empleado: " + ex.Message; //RETORNAR MENSAJE DE ERROR
            }
        }
        public string Actualizar()
        {
            try
            { 
            // ANTES DE ACTUALIZAR SE DEBE CONSULTAR SI EL DATO YA EXISTE PARA PODER ACTUALIZARLO, DE LOS CONTRARIO SE DEBE INSERTAR O RETORNAR UN MENSAJE DE ERROR                 
            //CONSULTAR EMPLEADO
            EMPLeado empl = Consultar(empleado.Documento); //CONSULTAR EMPLEADO POR DOCUMENTO
            if (empl == null) //SI EL EMPLEADO NO EXISTE
            {
                return "El empleado no existe en la base de datos"; //RETORNAR MENSAJE DE ERROR
            }
            dbSuper.EMPLeadoes.AddOrUpdate(empleado); //ACTUALIZAR EMPLEADO EN LA LISTA DE ENTITY FRAMEWORK / SE DEBE INVOCAR EL METODO SAVECHANGES PARA GUARDAR EN LA BD
            dbSuper.SaveChanges(); //GUARDAR CAMBIOS EN LA BASE DE DATOS
            return "Empleado actualizado correctamente"; //RETORNAR MENSAJE DE EXITO
            }
            catch (Exception ex) //CAPTURAR ERROR
            {
                return "Error al actualizar el empleado: " + ex.Message; //RETORNAR MENSAJE DE ERROR
            }
        }
        public EMPLeado Consultar(string Documento)
        {
            //Expresiones Lambda =>: Se convierten en objetos del tipo que se esta invocando
            EMPLeado empl = dbSuper.EMPLeadoes.FirstOrDefault(e => e.Documento == Documento); //la variable "e" se convierte en un objeto de tipo EMPLEADO
            return empl; //RETORNAR EMPLEADO
        }


        //*** OTRA MANERA DE REALIZAR LA VALIDACION ***//
        private bool validar(string Documento)
        {
            if (Consultar(Documento) == null) //SI EL EMPLEADO NO EXISTE
            {
                return false; //RETORNAR FALSO
            }
            else
            {
                return true; //RETORNAR VERDADERO
            }
        }
        public string Eliminar()
        {
            //Primero se debe consultar si el dato existe para poder eliminarlo
            try
            {
                EMPLeado empl = Consultar(empleado.Documento); //CONSULTAR EMPLEADO POR DOCUMENTO
                if (empl == null) //SI EL EMPLEADO NO EXISTE SE ELIMINA
                {
                    return "El empleado no existe"; //RETORNAR MENSAJE DE ERROR
                }

                //SI EL EMPLEADO SI EXISTE - ELSE
                dbSuper.EMPLeadoes.Remove(empl); //ELIMINAR EMPLEADO DE LA LISTA DE ENTITY FRAMEWORK
                dbSuper.SaveChanges(); //GUARDAR CAMBIOS EN LA BASE DE DATOS
                return "Empleado eliminado correctamente"; //RETORNAR MENSAJE DE EXITO
            }
            catch (Exception ex)
            {
                return "Error al eliminar el empleado: " + ex.Message;
            }
        }

        public string Eliminar(string Documento)
        {
            //Primero se debe consultar si el dato existe para poder eliminarlo
            try
            {
                EMPLeado empl = Consultar(Documento); //CONSULTAR EMPLEADO POR DOCUMENTO
                if (empl == null) //SI EL EMPLEADO NO EXISTE SE ELIMINA
                {
                    return "El empleado no existe"; //RETORNAR MENSAJE DE ERROR
                }

                //SI EL EMPLEADO SI EXISTE - ELSE
                dbSuper.EMPLeadoes.Remove(empl); //ELIMINAR EMPLEADO DE LA LISTA DE ENTITY FRAMEWORK
                dbSuper.SaveChanges(); //GUARDAR CAMBIOS EN LA BASE DE DATOS
                return "Empleado eliminado correctamente"; //RETORNAR MENSAJE DE EXITO
            }
            catch (Exception ex)
            {
                return "Error al eliminar el empleado: " + ex.Message;
            }
        }

        //CONSULTAR TODOS LOS EMPLEADOS
        public List<EMPLeado> ConsultarTodos()
        {
            return dbSuper.EMPLeadoes
                .OrderBy(e => e.Nombre) //ORDENAR POR NOMBRE e => e.Nombre hace referencia a la propiedad Nombre de la tabla EMPLEADO
                .ToList(); //RETORNAR TODOS LOS EMPLEADOS ORDENADOS POR NOMBRE
        }
    }

}