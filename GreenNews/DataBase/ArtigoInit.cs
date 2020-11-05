using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GreenNews.Models;

namespace GreenNews.DataBase
{
    public class ArtigoInit : CreateDatabaseIfNotExists<ArtigoContexto>
    {

        protected override void Seed(ArtigoContexto contexto)
        {
            List<Tag> tags = new List<Tag>()
                {
                    new Tag() { Nome = "Amazônia" },
                    new Tag() { Nome = "Cerrado" },
                    new Tag() { Nome = "Caatinga" },
                    new Tag() { Nome = "Mata Atlântica" },
                    new Tag() { Nome = "Pantanal" },
                    new Tag() { Nome = "Pampa" },
                };

            tags.ForEach(t => contexto.Tags.Add(t));

            List<Artigo> artigos = new List<Artigo>()
                {
                    new Artigo() {
                        Titulo = "O Poder do Hábito",
                        Autor = "Duhigg, Charles",
                        DataCriacao = 2012,
                        Texto = "Acima de tudo, é fundamental ressaltar que a adoção de políticas descentralizadoras prepara-nos para enfrentar situações atípicas decorrentes das posturas dos órgãos dirigentes com relação às suas atribuições. ",
                        Tag = tags.FirstOrDefault(t => t.Nome == "Amazônia")
                    },
                    new Artigo() {
                        Titulo = "Meio Ambiente e Ciências Sociais",
                        Autor = "Marilyn T. Duncan",
                        DataCriacao = 2015,
                        Texto = "   ",
                        Tag = tags.FirstOrDefault(t => t.Nome == "Pantanal")
                    },
                   new Artigo() {
                        Titulo = "Tecnologias e Estudos Ambientais",
                        Autor = "Julie J. Graham",
                        DataCriacao = 2011,
                        Texto = "Evidentemente, a expansão dos mercados mundiais não pode mais se dissociar das regras de conduta normativas.",
                        Tag = tags.FirstOrDefault(t => t.Nome == "Pantanal")
                    },
                   new Artigo() {
                        Titulo = "Planejamento e Meio Ambiente",
                        Autor = "Peggy T. McKeon",
                        DataCriacao = 2005,
                        Texto = "O que temos que ter sempre em mente é que a competitividade nas transações comerciais não pode mais se dissociar dos relacionamentos verticais entre as hierarquias.",
                        Tag = tags.FirstOrDefault(t => t.Nome == "Pantanal")
                    },
                   new Artigo() {
                        Titulo = "Dia internacional da reciclagem",
                        Autor = "Shenita J. McCoy",
                        DataCriacao = 2008,
                        Texto = "Por outro lado, o desenvolvimento contínuo de distintas formas de atuação oferece uma interessante oportunidade para verificação das regras de conduta normativas.",
                        Tag = tags.FirstOrDefault(t => t.Nome == "Cerrado")
                    },
                   new Artigo() {
                        Titulo = "Brasil vai aumentar pontos de coleta de lixo eletrônico ",
                        Autor = "Jeanne E. Ruiz",
                        DataCriacao = 2012,
                        Texto = "Acima de tudo, é fundamental ressaltar que a consolidação das estruturas estende o alcance e a importância do retorno esperado a longo prazo.",
                        Tag = tags.FirstOrDefault(t => t.Nome == "Mata Atlântica")
                    },
                   new Artigo() {
                        Titulo = "Cidades Sustentáveis é tema de podcast da Prefeitura de São Paulo",
                        Autor = "Harold K. Gordon",
                        DataCriacao = 2010,
                        Texto = "Gostaria de enfatizar que a complexidade dos estudos efetuados estimula a padronização dos níveis de motivação departamental.",
                        Tag = tags.FirstOrDefault(t => t.Nome == "Cerrado")
                    },
                   new Artigo() {
                        Titulo = "Novo estudo sobre subida do nível do mar preocupa cientistas",
                        Autor = "Helen R. Russell",
                        DataCriacao = 2012,
                        Texto = "Gostaria de enfatizar que o novo modelo estrutural aqui preconizado maximiza as possibilidades por conta das condições inegavelmente apropriadas.",
                        Tag = tags.FirstOrDefault(t => t.Nome == "Pampa")
                    },
                   new Artigo() {
                        Titulo = "Branqueamento ameaça sobrevivência de corais no litoral paulista",
                        Autor = "Brenda M. McNeil",
                        DataCriacao = 2009,
                        Texto = "Por conseguinte, a necessidade de renovação processual deve passar por modificações independentemente dos paradigmas corporativos.",
                        Tag = tags.FirstOrDefault(t => t.Nome == "Mata Atlântica")
                    },
                   new Artigo() {
                        Titulo = "Os materiais encontrados na natureza que podem substituir o plástico",
                        Autor = "Edna A. Barela",
                        DataCriacao = 2007,
                        Texto = "O empenho em analisar a expansão dos mercados mundiais aponta para a melhoria dos níveis de motivação departamental.",
                        Tag = tags.FirstOrDefault(t => t.Nome == "Pampa")
                    },
                   new Artigo() {
                        Titulo = "Algas podem transformar gases de efeito estufa em biomoléculas",
                        Autor = "Ralph H. Pollman",
                        DataCriacao = 2020,
                        Texto = "Desta maneira, a consolidação das estruturas desafia a capacidade de equalização dos níveis de motivação departamental.",
                        Tag = tags.FirstOrDefault(t => t.Nome == "Mata Atlântica")
                    },

                };

            artigos.ForEach(a => contexto.Artigos.Add(a));

            contexto.SaveChanges();
        }
    }
}