using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Servicios_18_20.Clases
{
	public class clsUpload
	{
        //HttpRequestMessage: Permite configurar todos los detalles de una solicitud HTTP antes de enviarla.
        public HttpRequestMessage request { get; set; } 
        public string Datos { get; set; } //Datos a enviar
		public string Proceso { get; set; } //Proceso a realizar
		private List<string> Archivos { get; set; } //Archivos a enviar
		public async Task<HttpResponseMessage> CargarArchivos() //Metodo para cargar archivos
        {
			if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            string root = HttpContext.Current.Server.MapPath("~/Archivos");
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                //Leer Archivo
                Archivos = new List<string>(); //Inicializa la lista de archivos
                await request.Content.ReadAsMultipartAsync(provider);
                foreach(MultipartFileData file in provider.FileData) //Aquie queda la coleccion de archivos
                {
                    string filename = file.Headers.ContentDisposition.FileName; //Captura el nombre del archivo
                    //Procesamiento al nombre del archivo
                    if (filename.StartsWith("\"") && filename.EndsWith("\""))
                    {
                        filename = filename.Trim('"');
                    }
                    if (filename.Contains(@"/") || filename.Contains(@"\"))
                    {
                        filename = Path.GetFileName(filename);
                    }
                    if (File.Exists(Path.Combine(root, filename)))
                    {
                        File.Delete(file.LocalFileName);
                        return request.CreateResponse(HttpStatusCode.Conflict, "El Archivo ya existe");
                    }                    
                    File.Move(file.LocalFileName, Path.Combine(root, filename));
                    Archivos.Add(filename); //Agrega el archivo a la lista
                }
                //RETORNAR RESPUESTA EXITOSA
                string Respuesta = GrabarInfoDB(); //Llama al metodo para grabar la informacion en la base de datos
                return request.CreateResponse(HttpStatusCode.OK, "Se grabo el archivo exitosamente " + Respuesta);
            }
            catch (Exception ex)
            {
                //Respuesta en caso de error: Error 500 y se pasa mensaje del error
                return request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }

        private string GrabarInfoDB()
        {
            switch(Proceso.ToUpper())
            {
               case "PRODUCTO":
                    clsProducto producto = new clsProducto();
                    return producto.GrabarImagen(Datos, Archivos);
                default:
                    return "Proceso no definido";
            }
        }

    }
}