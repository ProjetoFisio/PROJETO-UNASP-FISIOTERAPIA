
using CamadaDeDados.Banco.TabelasSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeDados.Banco.Sql
{
    public class DadosCategoria : bancoSQL
    {
        //Método para Salvar/Atualizar
        public categoria_problema SalvarCategoria(categoria_problema categoria)
        {
            try
            {
                /*Caso o id da categoria for igual a zero, adicione ele a tabela categoria_problema*/
                if (categoria.id_cat == 0)
                {
                    db.categoria_problema.Add(categoria);
                }
                else
                {
                    /*Senão, atualize ou sobreponha os registros alterados*/
                    db.categoria_problema.Attach(categoria);
                    db.Entry(pacientes).State = System.Data.Entity.EntityState.Modified;
                }
                /*Salvando as alterações*/
                db.SaveChanges();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

            return categoria;
        }
        //Obter categoria por id
        public categoria_problema ObterCategoriaPorId(int id)
        {
            return (from c in db.categoria_problema where c.id_cat == id select c).FirstOrDefault();
        }
        //
        public void DeletarCategoria(int id)
        {
            try
            {
                var cat = ObterCategoriaPorId(id);
                if (cat == null)
                {
                    throw new Exception("Registro não encontrado");
                }
                else
                {

                    db.categoria_problema.SqlQuery("delete from categoria where id_cat =" + id);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<categoria_problema> ObterTodasAsCategorias()
        {
            return (from c in db.categoria_problema select c).ToList();
        }

       
    }
}
