
using CamadaDeDados.Banco.TabelasSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeDados.Banco.Sql
{
    public class DadosClinica : bancoSQL
    {
        public clinica SalvarClinica(clinica clinica)
        {
            try
            {
                /*Caso o id do artigo for igual a zero, adicione ele a tabela artigo*/
                if (clinica.id_cli == 0)
                {
                    db.clinicas.Add(clinica);
                }
                else
                {
                    /*Senão, atualize ou sobreponha os registros alterados*/
                    db.clinicas.Attach(clinica);
                    db.Entry(pacientes).State = System.Data.Entity.EntityState.Modified;
                }
                /*Salvando as alterações*/
                db.SaveChanges();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

            return clinica;
        }

        public clinica ObterClinicaPorId(int id)
        {
            return (from cl in db.clinicas where cl.id_cli == id select cl).FirstOrDefault();
        }

        public void DesativarClinica(int id)
        {
            try
            {
                var cli = ObterClinicaPorId(id);
                if (cli == null)
                {
                    throw new Exception("Registro não encontrado");
                }
                else
                {
                    bool desativar = false;
                    db.clinicas.SqlQuery("update categoria set ativo_cat =" + desativar + "where id_cat = " + id);
                    db.Entry(cli).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

       

        }
    }

