
using CamadaDeDados.Banco.TabelasSQL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDeDados.Banco.Sql
{
    /*Método de cadastro*/
    public class DadosFisioterapeuta : bancoSQL
    {
        /*Método para salvar ou atualizar*/
        public fisioterapeuta SalvarFisioterapeuta(fisioterapeuta fisioterapeuta)
        {
            try
            {
                /*Caso o id do fisioterapeuta for igual a zero, adicione ele a tabela fisioterapeuta*/
                if (fisioterapeuta.id_fis == 0)
                {
                    //Estava mexendo na tabela de relacionamento!!!!!!!!!!!!!!!!!!!!!!!!!!
                    int id_cli = 1;
                    db.Database.ExecuteSqlCommand(@"insert into fisioterapeuta(nome_fis,email_fis,senha_fis,dados_fis,cel_fis,cpf_fis,rg_fis,nasc_fis,ativo_fis,adm_fis,sexo_fis) values ({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10})",fisioterapeuta.nome_fis, fisioterapeuta.email_fis,  fisioterapeuta.senha_fis, fisioterapeuta.dados_fis,  fisioterapeuta.cel_fis, fisioterapeuta.cpf_fis,  fisioterapeuta.rg_fis, fisioterapeuta.nasc_fis, fisioterapeuta.ativo_fis,  fisioterapeuta.adm_fis,fisioterapeuta.sexo_fis);
                    int id_fis = ObterID(fisioterapeuta.email_fis);
                    db.Database.ExecuteSqlCommand(@"insert into cli_fis(id_cli,id_fis) values ({0},{1})", id_cli,id_fis);
                    //db.fisioterapeutas.Add(fisioterapeuta);
                }
                else
                {
                    /*Senão, atualize ou sobreponha os registros alterados*/
                    db.fisioterapeutas.Attach(fisioterapeuta);
                    db.Entry(fisioterapeutas).State = System.Data.Entity.EntityState.Modified;
                }
                /*Salvando as alterações*/
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return fisioterapeuta;
        }
        /*Método para obter um fisioterapeuta pelo o id(necessário passar um valor do tipo inteiro para o prosseguimento do método)*/
        public fisioterapeuta ObterPorId(int id)
        {
            return (from f in db.fisioterapeutas where f.id_fis == id select f).FirstOrDefault();
        }
        /*Método para buscar o id através do email*/
        public int ObterID(string email)
        {
            return (from f in db.fisioterapeutas where f.email_fis == email select f.id_fis).FirstOrDefault();
        }
        /*Método para desativar*/
        public void Desativar(int id)
        {
            try
            {
                /*Para desativar, é necessário passar por parâmetro um valor inteiro para o método,
                 *sendo assim a variável do tipo var (variável = que aceita qualquer tipo de dado) irá pedir ao método
                  ObterFisioterapeutaPorId(ID) um Fisioterapeuta correspondente ao Id passado à ele.*/
                var fisioID = ObterPorId(id);
                if (fisioID == null)
                {
                    /*Se a variável 'var pac' receber nada/nulo/vazio do método ObterFisioterapeutaPorId(ID),
                     *irá ser lançada uma excessão na tela com a mensagem abaixo.*/
                    throw new Exception("Registro não encontrado");
                }
                else
                {
                    /*Caso venha com um fisioterapeuta irá ser executado a linha abaixo que irá atualizar a coluna 'ativo_fis' da tabela fisioterapeuta, tornando a coluna para o valor falso, correspondente ao ID informado.*/
                    bool desativar = false;
                    db.fisioterapeutas.SqlQuery("Update fisioterapeuta set ativo_pac = " + desativar + "Where id_pac = " + id);
                    db.Entry(fisioterapeutas).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        //Método para obter uma lista de fisioterapeutas.
        public List<fisioterapeuta> ObterTodosFisioterapeutas()
        {
            return (from f in db.fisioterapeutas select f).ToList();
        }
        //Método para logar no sistema.
        public bool ProcurarPorUsuario(string email, string senha)
        {
            //Fazendo a busca no banco.
            //Procurando se há a existência do email passado.
            var fisioEmail = (from f in db.fisioterapeutas where f.email_fis == email select f.email_fis).FirstOrDefault();
            //Procurando se há a existência da senha passada.
            var fisioSenha = (from f in db.fisioterapeutas where f.senha_fis == senha select f.senha_fis).FirstOrDefault();
            //Se o email e senha capturadas do banco forem diferentes dos parâmetros passado
            if (email != fisioEmail && senha != fisioSenha || email == fisioEmail && senha != fisioSenha || email != fisioEmail && senha == fisioSenha)
            {
                //O método(do tipo booleano(true/false)) terá como retorno como resposta 'falso', passando o valor para o método anterior(o que fez a requisição desse método).
                return false;
            }
            //Caso contrário, retornará 'true'.
            return true;
        }
        //Método para obter um fisioterapeuta.
        public fisioterapeuta ObterPorLogin(string email, string senha)
        {
            return (from f in db.fisioterapeutas where f.email_fis == email && f.senha_fis == senha select f).FirstOrDefault();
        }

       /* EM MANUNTENÇÃO!!! private byte ConverterImagem(byte[] img)
        {
            return Convert.ToByte(img);
        }*/
    }

}

