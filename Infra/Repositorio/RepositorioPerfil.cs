﻿using Domain.Interfaces.Generics;
using Entities.Entidades;
using Infra.Configuracao;
using Infra.Repositorio.Generics;

namespace Infra.Repositorio
{
    public class RepositorioPerfil : Repository<Perfil>, IPerfilRepository
    {
        public RepositorioPerfil(ContextBase context) : base(context){ }

    }
}
