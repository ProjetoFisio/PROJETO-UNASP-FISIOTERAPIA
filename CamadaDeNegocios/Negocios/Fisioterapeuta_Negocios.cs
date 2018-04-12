using CamadaDeDados.Banco;
using CamadaDeDados.Banco.Sql;
using CamadaDeDados.Banco.TabelasSQL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeNegocios.Negocios
{
    public class Fisioterapeuta_Negocios
    {
        DadosFisioterapeuta df = new DadosFisioterapeuta();

        public void SalvarFisioterapeuta(fisioterapeuta fisioterapeuta)
        {
            if (fisioterapeuta != null)
            {
                DadosFisioterapeuta df = new DadosFisioterapeuta();
             
                df.SalvarFisioterapeuta(fisioterapeuta);
            }
            else
            {
                throw new Exception();
            }
        }
        public void Desativar(fisioterapeuta fisioterapeuta)
        {
            DadosFisioterapeuta df = new DadosFisioterapeuta();
            if (fisioterapeuta == null)
            {
                throw new Exception("Fisioterapeuta não encontrado");
            }
            df.Desativar(fisioterapeuta.id_fis);
        }
        public bool fazerLogin(string email, string senha)
        {
            DadosFisioterapeuta df = new DadosFisioterapeuta();
            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(senha))
            {
                throw new Exception("Email e Senha Vazios");
            }
            return df.ProcurarPorUsuario(email, senha);
        }
        public fisioterapeuta ObterPorLogin(string email, string senha)
        {
            return df.ObterPorLogin(email, senha);
        }
    }
}
