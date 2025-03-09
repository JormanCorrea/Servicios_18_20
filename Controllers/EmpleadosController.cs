using Servicios_18_20.Clases;
using Servicios_18_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Servicios_18_20.Controllers
{
    [RoutePrefix("api/Empleados")]
    public class EmpleadosController : ApiController
    {
        // *** GET: CONSULTAR - CONSULTAR TODOS *** //
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<EMPLeado> ConsultarTodos()
        {
            clsEmpleado Empleado = new clsEmpleado(); //INSTANCIA DE LA CLASE EMPLEADO
            return Empleado.ConsultarTodos(); //RETORNAR TODOS LOS EMPLEADOS
        }

        // *** GET: CONSULTAR - CONSULTAR POR DOCUMENTO *** //
        [HttpGet]
        [Route("ConsultarXDocumento")]
        public EMPLeado ConsultarXDocumento(string documento)
        {
            clsEmpleado Empleado = new clsEmpleado(); //INSTANCIA DE LA CLASE EMPLEADO
            return Empleado.Consultar(documento); //RETORNAR EMPLEADO POR DOCUMENTO
        }

        // *** POST: INSERTAR *** //
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] EMPLeado empleado)
        {
            clsEmpleado Empleado = new clsEmpleado(); //INSTANCIA DE LA CLASE EMPLEADO
            Empleado.empleado = empleado; //ASIGNAR EMPLEADO
            return Empleado.Insertar(); //RETORNAR MENSAJE DE EXITO O ERROR
        }

        // *** PUT: ACTUALIZAR *** //
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] EMPLeado empleado)
        {
            clsEmpleado Empleado = new clsEmpleado(); //INSTANCIA DE LA CLASE EMPLEADO
            Empleado.empleado = empleado; //ASIGNAR EMPLEADO
            return Empleado.Actualizar(); //RETORNAR MENSAJE DE EXITO O ERROR
        }


        // *** DELETE: ELIMINAR *** //
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] EMPLeado empleado) //SE DEBE ENVIAR EL EMPLEADO COMPLETO
        {
            clsEmpleado Empleado = new clsEmpleado(); //INSTANCIA DE LA CLASE EMPLEADO
            Empleado.empleado = empleado; //ASIGNAR EMPLEADO
            return Empleado.Eliminar(); //RETORNAR MENSAJE DE EXITO O ERROR   
        }

        [HttpDelete]
        [Route("EliminarXDocumento")]
        public string EliminarXDocumento(string documento) //SE DEBE ENVIAR EL EMPLEADO COMPLETO
        {
            clsEmpleado Empleado = new clsEmpleado(); //INSTANCIA DE LA CLASE EMPLEADO
            return Empleado.Eliminar(documento);   
        }




    }    
}