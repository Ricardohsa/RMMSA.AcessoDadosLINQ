using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMMSA.AcessoDadosLINQ.Introducao
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Data Source
            //var numbers = new int[] {0, 1, 2, 3, 4,5,6,7};

            ////Query
            //var resultQuery = from num in numbers
            //    where num.Equals(1)
            //    select num;

            ////Execução da Query
            //foreach (var numero in resultQuery)
            //{
            //    Console.WriteLine(numero.ToString());
            //}





            //var texto = new string[] {"a", "B1", "FF", "FF"};

            //var Query2 = from t in texto
            //    select t;

            //foreach (var tes in Query2)
            //{
            //    Console.WriteLine(tes);
            //}

            //Console.ReadLine();


            var pessoas = new List<Pessoa>();

            //Este é o nosso o DataSource
            pessoas.Add(new Pessoa(){Nome = "Ricardo", Idade = 34});
            pessoas.Add(new Pessoa() { Nome = "Michelle", Idade = 34 });
            pessoas.Add(new Pessoa() { Nome = "Miguel", Idade = 1 });
            pessoas.Add(new Pessoa() { Nome = "Dulce", Idade = 64 });
            pessoas.Add(new Pessoa() { Nome = "Julio", Idade = 64 });
            pessoas.Add(new Pessoa() { Nome = "Thiago", Idade = 29 });


            //Cria e executa a consulta
            var result = (from lista in pessoas
                select lista.Idade).Sum();

            Console.WriteLine(result);
            Console.ReadLine();



        }
    }
}
