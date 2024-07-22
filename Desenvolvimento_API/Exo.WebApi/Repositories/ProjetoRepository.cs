// Faz parte de um padrão de projeto que utilizamos no desenvolvimento 
// da API. Ela é responsável direta pela manipulação com o banco de dados.
using Exo.WebApi.Contexts;
using Exo.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Exo.WebApi.Repositories
{
public class ProjetoRepository
{
private readonly ExoContext _context;
public ProjetoRepository(ExoContext context)
{
_context = context;
}
public List<Projeto> Listar()
{
return _context.Projetos.ToList();
}
}
}