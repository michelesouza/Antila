using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public abstract class Grids<T>
    {
        public List<T> ListDados { get; set; }
        public T Entidade { get; set; }

        public Grids()
        {
            this.ListDados = new List<T>();

        }

    }
}