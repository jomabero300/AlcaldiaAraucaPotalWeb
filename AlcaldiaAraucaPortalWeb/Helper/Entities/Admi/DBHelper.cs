using AlcaldiaAraucaPortalWeb.Models;
using System;

namespace AlcaldiaAraucaPortalWeb.Helper.Entities.Admi
{
    public class DBHelper
    {
        public static Response ExceptionCatcha(Exception ex)
        {
            var response = new Response { Succeeded = false };
            if (ex.InnerException==null)
            {
                response.Message = ex.Message;
            }
            else if (ex.InnerException.Message.Contains("IX_"))
            {
                response.Message = "El registro ya existe..";
            }
            else if (ex.InnerException.Message.Contains("REFERENCE"))
            {
                response.Message = "El registro no se puede eliminar porque tiene registros relacionados";
            }
            else
            {
                response.Message = ex.Message;
            }

            return response;
        }

    }
}