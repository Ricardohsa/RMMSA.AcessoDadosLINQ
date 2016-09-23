using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RMMSA.AcessoDafosLINQ.Operacoes
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataSource
            //var Ricardo = new Pessoa() { Nome = "Ricardo", Idade = 34, Id = 1, Sobrenome = "Sá", Sexo = "M"};
            //var Michelle = new Pessoa() { Nome = "Michelle", Idade = 34, Id = 2, Sobrenome = "Barboza", Sexo = "F" };
            //var Miguel = new Pessoa() { Nome = "Miguel", Idade = 1, Id = 3, Sobrenome = "Sá", Sexo = "M" };
            //var Dulce = new Pessoa() { Nome = "Dulce", Idade = 64, Id = 4, Sobrenome = "Irene", Sexo = "F" };
            //var Julio = new Pessoa() { Nome = "Julio", Idade = 64, Id = 5, Sobrenome = "Sá", Sexo = "M" };
            //var Thiago = new Pessoa() { Nome = "Thiago", Idade = 29, Id = 6, Sobrenome = "Barboza", Sexo = "M" };
            //var Daniela  = new Pessoa() { Nome = "Daniela", Idade = 29, Id = 7, Sobrenome = "Silva", Sexo = "F" };
            //var Joao = new Pessoa() { Nome = "João", Idade = 12, Id = 8, Sobrenome = "Moura", Sexo = "M" };

            //var Pessoas = new List<Pessoa>() {Ricardo, Michelle, Joao, Daniela, Dulce, Miguel, Thiago, Julio};

            //var ContaEmails = new List<ContaEmail>();

            //ContaEmails.Add(new ContaEmail() {Id = 1, Email = "r.humberto.sa@gamil.com"});
            //ContaEmails.Add(new ContaEmail() { Id = 2, Email = "michelle.brg@hotmail.com" });
            //ContaEmails.Add(new ContaEmail() { Id = 3, Email = "teste" });
            //ContaEmails.Add(new ContaEmail() { Id = 4, Email = "dulce.sa@gamil.com" });
            //ContaEmails.Add(new ContaEmail() { Id = 5, Email = "teste" });
            //ContaEmails.Add(new ContaEmail() { Id = 6, Email = "thiagosa@gamil.com" });
            //ContaEmails.Add(new ContaEmail() { Id = 7, Email = "daniela@gamil.com" });
            //ContaEmails.Add(new ContaEmail() { Id = 8, Email = "teste" });

            //SobreNome(Pessoas);
            //Sexo(Pessoas);
            //Consulta_Join(Pessoas, ContaEmails);
            //ConsultaBasica(Pessoas);
            //ConsultaOrdenada(Pessoas);
            //ConsultaDisc(Pessoas);

            var numeros = new[] { 59, 82, 70, 56, 92, 98, 85, 5 , 80, 79};

            var consulta = numeros
                .OrderByDescending(a => a)
                .SkipWhile(a => a >= 80);

            Console.WriteLine("Resultado do SkipewHILE");
            foreach (var v in consulta)
            {
                Console.WriteLine(v);
            }

            var num2 = new[] {2, 6, 9, 66, 5, 8, 95, 22, 27};
            var con = num2
                
                .TakeWhile(a => a <= 20);


            Console.WriteLine("Resultado do TakeWhile");
            foreach (var resultado in con)
            {
                Console.WriteLine(resultado);
            }
            Console.ReadKey();

        }

        
        
        
        private static void Sexo(List<Pessoa> lista)
        {
            var consulta = from c in lista
                group c by c.Sexo
                into SexoGrupo
                orderby SexoGrupo.Key
                           select SexoGrupo;

            foreach (var grupo in consulta)
            {
                Console.WriteLine("Key: {0}", grupo.Key);
                foreach (var nome in grupo)
                {
                    Console.WriteLine("\t{0}, {1}", nome.Nome, nome.Sobrenome);
                }
            }
        }

        private static void SobreNome(List<Pessoa> Pessoas)
        {
            var consulta = from lista in Pessoas
                group lista by lista.Sobrenome
                into novoGrupo
                orderby novoGrupo.Key
                select novoGrupo;

            foreach (var nomeGrupo in consulta)
            {
                Console.WriteLine("key: {0}", nomeGrupo.Key );
                foreach (var nome in nomeGrupo)
                {
                    Console.WriteLine("\t{0},{1}", nome.Sobrenome, nome.Nome);
                }
            }


        }

        private static void Consulta_Join(List<Pessoa> Pessoas, List<ContaEmail> Email)
        {


            var consulta = (from pessoa in Pessoas
                            join email in Email on pessoa.Id equals email.Id
                            select new { PessoaEmail = pessoa.Nome, PessoaEmail2 = email.Email }
                                );

            foreach (var lista in consulta)
            {
                Console.WriteLine(lista.PessoaEmail);
                Console.WriteLine(lista.PessoaEmail2);
            }
        }

        private static void ConsultaBasica(List<Pessoa> Lista_Pessoas)
        {
            var consultaBasica = (from lista in Lista_Pessoas
                where lista.Nome.Contains("i")
                select lista.Nome);

            foreach (var resul in consultaBasica)
            {
                Console.WriteLine(resul);
            }

            Console.Write("\n*********************************");
        }


        private static void ConsultaOrdenada(List<Pessoa> lista_pessoa)
        {
            var consultaOrdenada = (from lista in lista_pessoa
                                    orderby lista.Nome
                                    select lista.Nome);

            foreach (var resul in consultaOrdenada)
            {
                Console.WriteLine(resul);
            }

            Console.Write("\n*********************************");
        }


        private static void ConsultaDisc(List<Pessoa> lista_pessoa)
        {
            var consultaDistinta = (from lista in lista_pessoa
                                    orderby lista.Nome
                                    select lista.Nome).Distinct();

            foreach (var resul in consultaDistinta)
            {
                Console.WriteLine(resul);
            }

            Console.Write("\n*********************************");
        }
    }
}
