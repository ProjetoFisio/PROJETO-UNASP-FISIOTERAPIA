using CamadaDeDados.Banco.TabelasSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeDados.Banco.Sql
{
    /*Aqui estará os métodos correspondente ás suas respectivas classes.*/
    public class DadosPaciente : bancoSQL
    {
        /*Método de cadastro*/
        public paciente SalvarPaciente(paciente paciente)
        {
            try
            {
                /*Caso o id do paciente for igual a zero, adicione ele a tabela pacientes*/
                if (paciente.id_pac == 0)
                {
                    db.pacientes.Add(paciente);
                }
                else
                {
                    /*Senão, atualize ou sobreponha os registros alterados*/
                    db.pacientes.Attach(paciente);
                    db.Entry(pacientes).State = System.Data.Entity.EntityState.Modified;
                }
                /*Salvando as alterações*/
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

            return paciente;
        }
        /*Método para obter um paciente pelo o id(necessário passar um valor do tipo inteiro para o prosseguimento do método)*/
        public paciente ObterPorId(int id)
        {
            return (from p in db.pacientes where p.id_pac == id select p).FirstOrDefault();
        }
        /*Método para obter um paciente pelo o login e senha(necessário passar dois valores do tipo string para o prosseguimento do método)*/
        public paciente ObterPorLogin(string email, string senha)
        {
            return (from p in db.pacientes where p.email_pac == email && p.senha_pac == senha select p).FirstOrDefault();
        }
        /*Método para desativar*/
        public void Desativar(int id)
        {
            try
            {
                /*Para desativar, é necessário passar por parâmetro um valor inteiro para o método,
                 *sendo assim a variável do tipo var (variável = que aceita qualquer tipo de dado) irá pedir ao método
                  ObterPacientePorId(ID) um paciente correspondente ao Id passado à ele.*/
                var pacID = ObterPorId(id);
                if (pacID == null)
                {
                    /*Se a variável 'var pac' receber nada/nulo/vazio do método ObterPacientePorId(ID),
                  *irá ser lançada uma excessão na tela com a mensagem abaixo.*/
                    throw new Exception("Registro não encontrado");
                }
                else
                {
                    /*Caso venha com um paciente irá ser executado a linha abaixo que irá atualizar a coluna 'ativo_pac' da tabela paciente, tornando a coluna para o valor falso, correspondente ao ID informado.*/
                    bool desativar = false;
                    db.pacientes.SqlQuery("Update paciente set ativo_pac = " + desativar + "Where id_pac = " + id);
                    db.Entry(fisioterapeutas).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        /*Método para listar todos os pacientes*/
        public List<paciente> ObterTodosPacientes()
        {
            return (from p in db.pacientes select p).ToList();
        }
        //Esse método têm como função pesquisar no banco se há o email e senha digitado.
        public bool ProcurarPorUsuario(string email, string senha)
        {
            //Fazendo a busca no banco.
            //Procurando se há a existência do email passado.
            var pacEmail = (from p in db.pacientes where p.email_pac == email select p.email_pac).FirstOrDefault();
            //Procurando se há a existência da senha passada.
            var pacSenha = (from p in db.pacientes where p.senha_pac == senha select p.senha_pac).FirstOrDefault();
            //Se o email e senha capturadas do banco forem diferentes dos parâmetros passado
            if (email != pacEmail && senha != pacSenha || email == pacEmail && senha != pacSenha || email != pacEmail && senha == pacSenha)
            {
                //O método(do tipo booleano(true/false)) terá como retorno como resposta 'falso', passando o valor para o método anterior(o que fez a requisição desse método).
                return false;
            }
            //Caso contrário, retornará 'true'.
            return true;
        }
    }
}
