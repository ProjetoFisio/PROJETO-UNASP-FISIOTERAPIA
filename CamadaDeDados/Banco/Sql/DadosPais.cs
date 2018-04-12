using CamadaDeDados.Banco.TabelasSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeDados.Banco.Sql
{
    public class DadosPais : bancoSQL
    {
        /*Método para salvar/atualizar*/
        public pai SalvarPais(pai pais)
        {
            try
            {
                /*Caso o id do país for igual a zero, adicione ele a tabela país*/
                if (pais.id_pais == 0)
                {
                    db.pais.Add(pais);
                }
                else
                {
                    /*Senão, atualize ou sobreponha os registros alterados*/
                    db.pais.Attach(pais);
                    db.Entry(pais).State = System.Data.Entity.EntityState.Modified;
                }
                /*Salvando as alterações*/
                db.SaveChanges();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

            return pais;
        }

        //Retornando todos os países
        public List<pai> ObterTodosOsPaises()
        {
            return (from countries in db.pais select countries).ToList();
        }


        //Excluindo país da tabela
        public void ExcluirPais(string nome)
        {
            
            db.Database.ExecuteSqlCommand("delete from pais where  = {0}",ObterPaisPorId(nome));
        }
        //Obter País por id
        public int ObterPaisPorId(string nome)
        {
            return (from country in db.pais where country.nome_pais == nome select country.id_pais).FirstOrDefault();
        }

    }
}
