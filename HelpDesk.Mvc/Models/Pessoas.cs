using Dapper;
using System.Linq;

namespace HelpDesk.Mvc.Models
{
    public class Pessoas
    {
        #region prop
        public int COD_PESSOA { get; set; }
        public string MATRICULA { get; set; }
        public string NOME { get; set; }
        public string LOGIN { get; set; }
        public string EMAIL { get; set; }
        public string SENHA { get; set; }
        public string ACESSO { get; set; }
        public string ENDERECO { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string TELEFONE { get; set; }
        public int COD_NIVEL { get; set; }

        #endregion
        
        public bool Login(string email, string senha)
        {
            var sql = "Select * From Pessoas Where Email = @Email And Senha = @Senha;";
            using (var cx = new Context())
                return cx.Connection.Query<int?>(sql, new { Email = email, Senha = senha }).FirstOrDefault() != null;
        }

        public Pessoas GetPessoa(Pessoas pessoa)
        {
            var sql = "Select * From Pessoas Where Email = @Email";
            using (var cx = new Context())
                return cx.Connection.Query<Pessoas>(sql, new { Email = pessoa.EMAIL}).FirstOrDefault();
        }
        public void Create()
        {
            var sql = @"INSERT INTO [dbo].[PESSOAS]
                                   ([MATRICULA]
                                   ,[NOME]
                                   ,[SENHA]
                                   ,[ACESSO]
                                   ,[ENDERECO]
                                   ,[CPF]
                                   ,[CNPJ]
                                   ,[TELEFONE]
                                   ,[LOGIN]
                                   ,[COD_NIVEL]
                                   ,[EMAIL])
                        VALUES
                                (@Matricula,
                                @Nome,
                                @Senha,
                                @Acesso,
                                @Endereco,
                                @CPF,
                                @CNPJ,
                                @Telefone,
                                @Login,
                                @Cod_Nivel,
                                @Email);";

            using (var cx = new Context())
            {
                cx.Connection.Execute(sql, this);
            }
            
        }

    }

}