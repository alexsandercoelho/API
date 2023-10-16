﻿using Domain.Interfaces.Generics;
using Entities.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IPerfil
{
    public interface InterfacePerfil : IInterfaceGeneric<Perfil>
    {
        Task<IList<Perfil>> ListarPerfilUsuario(string emailUsuario);
    }
}
