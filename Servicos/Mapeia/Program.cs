namespace Mapeia
{
    using Mapeia.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;


    class Program
    {
        private static FoccusContext _contexto;

        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<FoccusContext>(o => o.UseMySql(EssaGestaoCore.DTO.Util.StringDeConexaoPadrao));
            _contexto = serviceCollection.BuildServiceProvider().GetService<FoccusContext>();


            var ret = P01ChavePrimaria();
            ret += "\n";
            ret += P02OneToMany();
            ret += "\n";
            ret += P03OneToOne();
            ret += "\n";

            File.WriteAllText(Directory.GetCurrentDirectory() + "/../../../MAPEAMENTO.txt", ret);

            Console.WriteLine("Finalizado, copie o conteúdo do arquivo MAPEAMENTO.txt da raiz desse projeto.");
            Console.ReadLine();
        }



        static List<Chave> SqlQuery(string sql)
        {
            List<Chave> lista = new List<Chave>();
            using (var command = _contexto.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = sql;
                _contexto.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                    if (reader.HasRows)
                        while (reader.Read())
                            lista.Add(new Chave()
                            {
                                table_schema = reader["table_schema"].ToString(),
                                table_name = reader["table_name"].ToString(),
                                column_name = reader["column_name"].ToString(),
                            });
            }
            return lista;
        }

        private static string P01ChavePrimaria()
        {
            var lista = SqlQuery(@"SELECT
  table_schema,
  table_name,
  column_name
FROM FW_VW_FRAMEWORK_CONSTRAINT
WHERE table_name IN (SELECT
    table_name
  FROM FW_VW_FRAMEWORK_CONSTRAINT
  WHERE constraint_type = 'PRIMARY KEY'
  GROUP BY table_name
  HAVING COUNT(1) > 1)
AND constraint_type = 'PRIMARY KEY'").ToList();

            StringBuilder str = new StringBuilder();
            foreach (var item in lista.GroupBy(c => c.table_name))
                str.AppendLine("modelBuilder.Entity<" + item.Key + ">().HasKey(c => new { " + string.Join(", ", item.Select(d => "c." + d.column_name).ToArray()) + " });");

            return str.ToString();
        }

        private static string P02OneToMany()
        {
            return string.Join("\n",
               SqlQuery(@"SELECT
  CONCAT('modelBuilder.Entity<', Classe, '>().HasMany(e => e.', nomepropriedade, ').WithOne(e => e.', NomePropriedadeReferenciaExterna, ').HasForeignKey(e => e.', COLUMN_NAME_REFERENCIA_EXTERNA, ');') column_name
  , '' table_schema, '' table_name
FROM FW_VW_FRAMEWORK_MAPEAMENTO_ENTITY_PROPRIEDADES_COM_FILHOS
WHERE tipo LIKE '%ICollection%'
ORDER BY Classe").Select(c => c.column_name).ToArray());
        }


        private static string P03OneToOne()
        {
            return string.Join("\n",
               SqlQuery(@"SELECT
  CONCAT('modelBuilder.Entity<', Classe, '>().HasOne(a => a.', nomepropriedade, ').WithOne(b => b.', NomePropriedadeReferenciaExterna, ').HasForeignKey<', TABLE_NAME_REFERENCIA_EXTERNA, '>(b => b.', COLUMN_NAME_REFERENCIA_EXTERNA, ');') column_name
  , '' table_schema, '' table_name
FROM FW_VW_FRAMEWORK_MAPEAMENTO_ENTITY_PROPRIEDADES_COM_FILHOS
WHERE IS_PRIMARY_KEY_EXTERNA = 1
AND TABLE_NAME_REFERENCIA_EXTERNA NOT IN (SELECT
    Classe
  FROM FW_VW_FRAMEWORK_MAPEAMENTO_ENTITY_PROPRIEDADES_COM_FILHOS
  WHERE IS_PRIMARY_KEY_INTERNA = 1
  GROUP BY Classe
  HAVING COUNT(1) > 1)
ORDER BY Classe").Select(c => c.column_name).ToArray());

        }

    }

}
