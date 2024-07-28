using Exo.WebApi.Contexts;
using Exo.WebApi.Models; 
using System.Collections.Generic; 
using System.Linq; 

namespace Exo.WebApi.Repositories
{
    public class UsuarioRepository
    {
        private readonly ExoContext _context; // Declara uma variável para o contexto do banco de dados.
        public UsuarioRepository(ExoContext context) // Construtor para injeção de dependência do contexto do banco de dados.
        {
            _context = context; // Inicializa a variável com a instância do contexto.
        }
        public Usuario Login(string email, string senha) // Método para login de usuário.
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha); // Busca o primeiro usuário que corresponda ao email e senha fornecidos.
        }
        public List<Usuario> Listar() // Método para listar todos os usuários.
        {
            return _context.Usuarios.ToList(); // Retorna todos os usuários em uma lista.
        }
        public void Cadastrar(Usuario usuario) // Método para cadastrar um novo usuário.
        {
            _context.Usuarios.Add(usuario); // Adiciona o novo usuário ao contexto.
            _context.SaveChanges(); // Salva as mudanças no banco de dados.
        }
        public Usuario BuscaPorId(int id) // Método para buscar um usuário pelo ID.
        {
            return _context.Usuarios.Find(id); // Retorna o usuário encontrado pelo ID.
        }
        public void Atualizar(int id, Usuario usuario) // Método para atualizar um usuário existente.
        {
            Usuario usuarioBuscado = _context.Usuarios.Find(id); // Busca o usuário pelo ID.
            if (usuarioBuscado != null) // Verifica se o usuário foi encontrado.
            {
                usuarioBuscado.Email = usuario.Email; // Atualiza o email do usuário.
                usuarioBuscado.Senha = usuario.Senha; // Atualiza a senha do usuário.
                _context.Usuarios.Update(usuarioBuscado); // Atualiza o usuário no contexto.
                _context.SaveChanges(); // Salva as mudanças no banco de dados.
            }
        }
        public void Deletar(int id) // Método para deletar um usuário pelo ID.
        {
            Usuario usuarioBuscado = _context.Usuarios.Find(id); // Busca o usuário pelo ID.
            _context.Usuarios.Remove(usuarioBuscado); // Remove o usuário do contexto.
            _context.SaveChanges(); // Salva as mudanças no banco de dados.
        }
    }
}