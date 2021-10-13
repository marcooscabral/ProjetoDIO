using System;

namespace ProjetoDIO
{
    public class Livros : EntidadeBase
    { //Atributos

    private Genero Genero { get; set; }

    private string Titulo { get; set; }

    private string Descricao { get; set;}

    private int Ano { get; set;}

    private int NumeroPaginas { get; set; }

    private string Editora  { get; set; }

    private bool Excluido { get; set; }

    //métodos

    public Livros (int id, Genero Genero, string Titulo, string Descricao, int Ano, int NumeroPaginas, string Editora)
    {
        this.Id = id;
        this.Genero = Genero;
        this.Titulo = Titulo;
        this.Descricao = Descricao;
        this.Ano = Ano;
        this.NumeroPaginas = NumeroPaginas;
        this.Editora = Editora; 
        this.Excluido = false;
    }  
    
    public override string ToString()
    {
        string retorno = "";
        retorno +="Gênero: " + this.Genero + Environment.NewLine;
        retorno +="Título: " + this.Titulo + Environment.NewLine;
        retorno +="Descrição: " + this.Descricao + Environment.NewLine;
        retorno +="Ano de lançamento: " + this.Ano + Environment.NewLine;
        retorno +="Número de páginas: " + this.NumeroPaginas + Environment.NewLine; 
        retorno +="Editora: " + this.Editora + Environment.NewLine;
        retorno += "Excluido: " + this.Excluido + Environment.NewLine;
        return retorno;
    }

    public string RetornaTitulo()
    {
        return this.Titulo;
    }

    public int RetornaId()
    {
        return this.Id;
    }
    public bool RetornaExcluido()
    {
        return this.Excluido;
    }
    public void Excluir()
    { this.Excluido = true;
    }
    }
}