using System;
using System.Collections.Generic;
using System.Text;
using Niobe.Data;

namespace Niobe.Service
{
    public interface IEnderecoCommom<T,U> where T : CommomCreateEnderecoDTO where U : CommomReadEnderecoDTO
    {
        U Create(T createDto);
        U GetById(int id);
        List<U> Get();

    }
}
