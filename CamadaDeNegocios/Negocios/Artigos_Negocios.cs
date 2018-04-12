using CamadaDeDados.Banco;
using CamadaDeDados.Banco.Sql;
using CamadaDeDados.Banco.TabelasSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeNegocios.Negocios
{
    public class Artigos_Negocios
    {
        public void enviarArtigo(artigo_dica a)
        {
            if (a == null)
            {
                throw new Exception("Conteúdo vazio");
            }

            DadosArtigo da = new DadosArtigo();
            da.SalvarArtigo(a);
        }
    }
}
