﻿using Domain.Models;
using Repository.Context;
using System;
using System.Linq;

namespace Repository.Models
{
    public class FilmeRepository : Repository<Filme>
    {
        public FilmeRepository(BaseContext ctx) : base(ctx) { }

        public void EncontrarFilme(int id, string titulo)
        {
            var result = Find(id, titulo);

            if (result is null)
                throw new Exception("Filme não encontrado! Verifique se Id e o Titulo estão corretos.");
            else
                Detached(result);
        }

        public Filme GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public Filme GetByTitulo(string titulo)
        {
            return GetAll().FirstOrDefault(x => x.Titulo == titulo);
        }
    }
}
