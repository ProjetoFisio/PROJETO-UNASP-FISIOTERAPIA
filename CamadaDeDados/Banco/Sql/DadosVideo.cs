using CamadaDeDados.Banco.TabelasSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeDados.Banco.Sql
{ /*Método para salvar/atualizar*/
    public class DadosVideo : bancoSQL
    {
        //Método para Salvar/Atualizar 
        public video SalvarVideo(video video)
        {
            try
            {
                //Caso o id do video venha com 0, salve ele na tabela video.
                if (video.id_video == 0)
                {
                    db.videos.Add(video);
                }
                else
                {
                    //Senão atualize.
                    db.videos.Attach(video);
                    db.Entry(pacientes).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }

            return video;
        }
    }
}



