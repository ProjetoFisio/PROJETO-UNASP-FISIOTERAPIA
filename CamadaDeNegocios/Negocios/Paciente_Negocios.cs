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
    public class Paciente_Negocios
    {
        DadosPaciente dp = new DadosPaciente();

        public void SalvarPaciente(paciente paciente)
        {
            if (paciente != null)
            {
                dp.SalvarPaciente(paciente);
            }
        }
        public void Desativar(paciente paciente)
        {

            if (paciente == null)
            {
                throw new Exception("Paciente vazio");
            }
            dp.Desativar(paciente.id_pac);
        }
        public bool fazerLogin(string email, string senha)
        {

            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(senha))
            {
                throw new Exception("Email e Senha Vazios");
            }
            return dp.ProcurarPorUsuario(email, senha);
        }
        public paciente ObterPorLogin(string email, string senha)
        {
            return dp.ObterPorLogin(email, senha);
        }
    }
}
