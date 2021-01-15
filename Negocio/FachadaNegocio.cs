using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
    public class FachadaNegocio
    {
        public bool creteCliente(Entidades.clieteDTO objCliente)
        {
            try
            {
                return Persistencia.FachadaPersistencia.Instancia.createCliete(objCliente);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<Entidades.clieteDTO> listacliente()
        {
            try
            {
                return Persistencia.FachadaPersistencia.Instancia.listCliente();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Entidades.clieteDTO getClieteById(int id )
        {
            try
            {
                return Persistencia.FachadaPersistencia.Instancia.getClienteById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool updateCliete (int id, Entidades.clieteDTO objCliete)
        {
            try
            {
                return Persistencia.FachadaPersistencia.Instancia.updateCliete(id, objCliete);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
