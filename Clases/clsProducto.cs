using Servicios_18_20.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Servicios_18_20.Clases
{
	public class clsProducto
	{
		private DBSuperEntities dbSuper = new DBSuperEntities(); //OBJETO PARA GESTIONAR DATOS DE LA BASE DE DATOS
		public PRODucto producto { get; set; }

		public List<PRODucto> ConsultarTodos()
		{
			return dbSuper.PRODuctoes
				.OrderBy(p => p.Nombre)
				.ToList();
		}

		public PRODucto Consultar(int Codigo)
		{
			return dbSuper.PRODuctoes.FirstOrDefault(p => p.Codigo == Codigo); //Trae un producto o un valor NULL
		}

		public List<PRODucto> ConsultarXTipo(int codigoTipoProducto) //Consultar productos por tipo
		{
			return dbSuper.PRODuctoes
				.Where(p => p.CodigoTipoProducto == codigoTipoProducto) //Filtrar por tipo de producto
				.OrderBy(p => p.Nombre) //Ordenar por nombre
				.ToList(); //Retornar lista
		}

		public string Insertar()
		{
			try
			{
				dbSuper.PRODuctoes.Add(producto); //AGREGAR UN PRODUCTO A LA LISTA DE ENTITY FRAMEWORK, SE DEBE INVOCAR EL METODO SAVECHANGES PARA GUARDAR EN LA BD
				dbSuper.SaveChanges(); //GUARDAR EN LA BASE DE DATOS
				return "Se grabo el producto: " + producto.Nombre + " correctamente"; //RETORNAR MENSAJE DE EXITO
			}
			catch (Exception ex)
			{
				return "Error al insertar el producto: " + ex.Message;
			}
		}

		public string Actualizar()
		{
			try
			{
				//CONSULTAR PRODUCTO ANTES PARA VALIDAR QUE EXISTA
				PRODucto prod = Consultar(producto.Codigo); //CONSULTAR PRODUCTO POR CODIGO
				if (prod == null) //SI EL PRODUCTO NO EXISTE
				{
					return "El producto No Existe"; //RETORNAR MENSAJE DE ERROR
				}
				else //SI EL PRODUCTO EXISTE
				{
					dbSuper.PRODuctoes.AddOrUpdate(producto); //ACTUALIZAR PRODUCTO EN LA LISTA DE ENTITY FRAMEWORK / SE DEBE INVOCAR EL METODO SAVECHANGES PARA GUARDAR EN LA BD
					dbSuper.SaveChanges(); //GUARDAR CAMBIOS EN LA BASE DE DATOS
					return "El Producto: " + producto.Nombre + " fue actualizado correctamente"; //RETORNAR MENSAJE DE EXITO
				}
			}
			catch (Exception ex)
			{
				return "Error al actualizar el producto: " + ex.Message;
			}
		}

		public string Eliminar(int Codigo)
		{
			try
			{
				PRODucto prod = Consultar(Codigo); //CONSULTAR PRODUCTO POR CODIGO
				if (prod == null) //SI EL PRODUCTO NO EXISTE
				{
					return "El producto No Existe";
				}
				dbSuper.PRODuctoes.Remove(prod); //ELIMINAR PRODUCTO DE LA LISTA DE ENTITY FRAMEWORK
				dbSuper.SaveChanges(); //GUARDAR CAMBIOS EN LA BASE DE DATOS
				return "El Producto: " + prod.Nombre + " fue eliminado correctamente"; //RETORNAR MENSAJE DE EXITO

			}
			catch (Exception ex)
			{
				return "Error al eliminar el producto: " + ex.Message;
			}
		}

		public string ModificarActivo(int Codigo, bool Activo) //Se reciben dos parametros, el codigo del producto y el estado de activo
        {
			try
			{
				PRODucto prod = Consultar(Codigo); //CONSULTAR PRODUCTO POR CODIGO
				if (prod == null) //SI EL PRODUCTO NO EXISTE
				{
					return "El producto No Existe";
                }
				
				prod.Activo = Activo; //Esta linea significa que el producto activo sera igual al valor que se recibe por parametro
                dbSuper.SaveChanges(); //GUARDAR CAMBIOS EN LA BASE DE DATOS
				if (Activo == true) //Si el producto esta activo
				{
					return "El Producto: " + prod.Nombre + " fue Activado correctamente"; //RETORNAR MENSAJE DE EXITO
				}
				else
				{
					return "Se inactivo el producto: " + prod.Nombre; //RETORNAR MENSAJE DE EXITO
				}

                    
            }
			catch (Exception ex)
			{
				return "Error al inactivar el producto: " + ex.Message;
            }
		}

		public string GrabarImagen(string idProducto, List<string> Archivos)
		{
			foreach (string archivo in Archivos)
            {
                ImagenesProducto imagen = new ImagenesProducto(); //CREAR OBJETO DE IMAGENES PRODUCTO
				imagen.idProducto = Convert.ToInt32(idProducto); //ASIGNAR EL ID DEL PRODUCTO
				imagen.NombreImagen = archivo; //ASIGNAR EL NOMBRE DE LA IMAGEN
                dbSuper.ImagenesProductoes.Add(imagen); //AGREGAR IMAGEN A LA LISTA DE ENTITY FRAMEWORK
				dbSuper.SaveChanges(); //GUARDAR CAMBIOS EN LA BASE DE DATOS
            }
			return "Archivos procesados correctamente";
        }
    }
}