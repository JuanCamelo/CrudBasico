using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class FachadaPersistencia
    {
        private static FachadaPersistencia instancia;
        public static FachadaPersistencia Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new FachadaPersistencia();
                return instancia;
            }   
        }

        public bool createCliete(Entidades.clieteDTO objCliet)
        {
            bool valid = false;
            try
            {
                using (OPHELIAEntities cone = new  OPHELIAEntities())
                {
                    CLIENTE obj = new CLIENTE();
                    obj.NOMBRE = objCliet.nombre;
                    obj.APELLIDO = objCliet.nombre;
                    obj.DIRECCION = objCliet.direccion;
                    obj.EMAIL = objCliet.email;
                    obj.FECHA_NACIMIENTO = objCliet.fecha;
                    obj.TELEFONO = objCliet.telefono;

                    cone.CLIENTE.Add(obj);
                    cone.SaveChanges();
                    valid = true;

                }

            }
            catch (Exception ex)
            {
                valid = false;
            }
            return valid;
        }


        public List<Entidades.clieteDTO> listCliente()
        {
            List<Entidades.clieteDTO> lstCliete = new List<Entidades.clieteDTO>();
            try
            {
                using (OPHELIAEntities cone = new OPHELIAEntities())
                {
                    lstCliete  = (from o in cone.CLIENTE 
                                   select new Entidades.clieteDTO
                                   {
                                   clienteId = o.ID_CLIENTE,
                                   nombre = o.NOMBRE,
                                   apellido = o.APELLIDO,
                                   email = o.EMAIL,
                                   telefono = o.TELEFONO,
                                   direccion = o.DIRECCION
                                   }).ToList();
                }

            }
            catch (Exception ex)
            {

                lstCliete = new List<Entidades.clieteDTO>();
            }
            return lstCliete;

        }

        public Entidades.clieteDTO getClienteById(int id)
        {
            Entidades.clieteDTO ObjCliete = new Entidades.clieteDTO();
            try
            {
                using (OPHELIAEntities cone = new OPHELIAEntities())
                {
                    CLIENTE obj = cone.CLIENTE.Where(x => x.ID_CLIENTE == id).FirstOrDefault();
                    if (obj != null)
                    {
                        ObjCliete.nombre = obj.NOMBRE;
                        ObjCliete.apellido = obj.APELLIDO;
                        ObjCliete.fecha = obj.FECHA_NACIMIENTO;
                        ObjCliete.telefono = obj.TELEFONO;
                        ObjCliete.email = obj.EMAIL;
                        ObjCliete.direccion = obj.DIRECCION;
                    }
                }
                
            }
            catch (Exception)
            {

                throw;
            }

            return ObjCliete;
        }

        public bool updateCliete(int id,Entidades.clieteDTO ObjClien)
        {
            bool valid = false;
            try
            {
                using (OPHELIAEntities cone = new OPHELIAEntities())
                {
                    CLIENTE obj = cone.CLIENTE.Where(x => x.ID_CLIENTE == id).FirstOrDefault();
                    if (obj != null)
                    {
                        obj.NOMBRE = ObjClien.nombre;
                        obj.APELLIDO = ObjClien.apellido;
                        obj.TELEFONO = ObjClien.telefono;
                        obj.DIRECCION = ObjClien.direccion;
                        obj.FECHA_NACIMIENTO = ObjClien.fecha;

                        cone.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                        cone.SaveChanges();
                        valid = true;
                    }

                }

            }
            catch (Exception ex)
            {

                valid = false;
            }
            return valid;
        }
    }
}
