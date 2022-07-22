using AccesoDatos;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class LNegocio
    {
        DContacto oContacto = new DContacto();
        
        public DataTable CargarDatos(int nId)
        {
            return oContacto.ListContacto(nId);
        }

        public void InsertarContacto(EContacto oCont)
        {
            oContacto.AddContacto(oCont);
        }
        public void ActualizarContacto(EContacto oCont)
        {
            oContacto.EditContacto(oCont);
        }
        public void BorrarContacto(int nId)
        {
            oContacto.DeletContacto(nId);
        }
    }
}
