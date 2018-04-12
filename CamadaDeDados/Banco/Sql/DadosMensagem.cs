
using CamadaDeDados.Banco.TabelasSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeDados.Banco.Sql
{
    public class DadosMensagem : bancoSQL
    {
        public mensagem SalvarMensagem(mensagem mensagem)
        {
            try
            {
                if (mensagem.id_mensagem == 0)
                {
                    db.mensagems.Add(mensagem);
                }
                else
                {
                    db.mensagems.Attach(mensagem);
                    db.Entry(mensagem).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return mensagem;
        }

        public mensagem ObterPorId(int id)
        {
            return (from m in db.mensagems where m.id_mensagem == id select m).FirstOrDefault();
        }
    }
}
