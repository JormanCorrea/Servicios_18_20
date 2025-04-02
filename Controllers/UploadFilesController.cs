using Servicios_18_20.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Servicios_18_20.Controllers
{
    [RoutePrefix("api/UploadFiles")]
    public class UploadFilesController : ApiController
    {
        [HttpPost]
        [Route("CargarArchivos")]
        public async Task<HttpResponseMessage> CargarArchivos(HttpRequestMessage request, string Datos, string Proceso)
        {
            clsUpload upload = new clsUpload();
            upload.request = request;
            upload.Datos = Datos;
            upload.Proceso = Proceso;
            return await upload.CargarArchivos();
        }
    }
}