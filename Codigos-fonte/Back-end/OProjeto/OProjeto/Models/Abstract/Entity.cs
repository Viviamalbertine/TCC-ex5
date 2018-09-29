using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OProjeto.Models.Abstract
{
    /// <summary>
    /// Classe abstrata geral que representa uma entidade dentro do sistema; contém propriedades e comportamentos comuns a todas as entidades do sistema
    /// Esta classe n"ao é instanciável: é necessário herdar da mesma.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public abstract class Entity<TKey>
    {
        public TKey Id { get; set; }
    }
}