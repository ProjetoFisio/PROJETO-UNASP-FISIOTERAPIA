
using CamadaDeDados.Banco.TabelasSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeDados.Banco.Sql
{
     public class DadosEstado : bancoSQL
    {
        DadosPais dp = new DadosPais();
        /*Método para salvar/atualizar*/
        public estado SalvarArtigo(estado estado)
        {
            try
            {
                /*Caso o id do estado seja igual a zero, adicione ele a tabela estado*/
                if (estado.id_state == 0)
                { 
                    db.estadoes.Add(estado);
                }
                else
                {
                    /*Senão, atualize ou sobreponha os registros alterados*/
                    db.estadoes.Attach(estado);
                    db.Entry(estadoes).State = System.Data.Entity.EntityState.Modified;
                }
                /*Salvando as alterações*/
                db.SaveChanges();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

            return estado;
        }

        //Listar os estados.
        public List<estado> ObterTodosOsEstados()
        {
            return (from state in db.estadoes select state).ToList();
        }
        //Excluindo estados
        public void ExcluirEstado(int id)
        {
            db.Database.ExecuteSqlCommand(@"delete from estado where id_state = {0}", id);
        }


    }
}
