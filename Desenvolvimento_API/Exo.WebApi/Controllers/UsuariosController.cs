using Exo.WebApi.Models;
using Exo.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Exo.WebApi.Controllers
{
    [Produces("application/json")] // Especifica que as respostas serão em JSON.
    [Route("api/[controller]")] // Define a rota base como "api/nomedocontroller".
    [ApiController] // Indica que esta classe é um controlador de API.
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository; // Declara uma variável para o repositório de usuários.
        public UsuariosController(UsuarioRepository usuarioRepository) // Construtor para injeção de dependência do repositório de usuários.
        {
            _usuarioRepository = usuarioRepository; // Inicializa a variável com a instância do repositório.
        }
        // GET -> /api/usuarios
        [HttpGet] // Mapeia solicitações GET para este método.
        public IActionResult Listar() // Método para listar todos os usuários.
        {
            return Ok(_usuarioRepository.Listar()); // Retorna a lista de usuários com status 200 (OK).
        }
        // POST -> /api/usuarios
        // [HttpPost] // Mapeia solicitações POST para este método.
        // public IActionResult Cadastrar(Usuario usuario) // Método para cadastrar um novo usuário.
        // {
        //     _usuarioRepository.Cadastrar(usuario); // Chama o repositório para cadastrar o usuário.
        //     return StatusCode(201); // Retorna status 201 (Criado).
        // }

        // Novo código POST para auxiliar o método de Login.
        public IActionResult Post(Usuario usuario)
            {
            Usuario usuarioBuscado = _usuarioRepository.Login(usuario.Email, 
            usuario.Senha);
            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos!");
            }
            // Se o usuário for encontrado, segue a criação do token.
            // Define os dados que serão fornecidos no token - Payload.
            var claims = new[]
            {
                // Armazena na claim o e-mail usuário autenticado.
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                // Armazena na claim o id do usuário autenticado.
                new Claim(JwtRegisteredClaimNames.Jti, 
                usuarioBuscado.Id.ToString()),
            };
            // Define a chave de acesso ao token.
            var key = new
            SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("exoapi-chaveautenticacao"));
            // Define as credenciais do token.
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            // Gera o token.
            var token = new JwtSecurityToken(
                issuer: "exoapi.webapi", // Emissor do token.
                audience: "exoapi.webapi", // Destinatário do token.
                claims: claims, // Dados definidos acima.
                expires: DateTime.Now.AddMinutes(30), // Tempo de expiração.
                signingCredentials: creds // Credenciais do token.
            );
            // Retorna ok com o token.
            return Ok(
                new { token = new JwtSecurityTokenHandler().WriteToken(token) }
            );
        }
        // Fim do novo código POST para auxiliar o método de Login.

        // GET -> /api/usuarios/{id}
        [HttpGet("{id}")] // Mapeia solicitações GET para este método com um parâmetro ID.
        public IActionResult BuscarPorId(int id) // Método para buscar um usuário pelo ID.
        {
            Usuario usuario = _usuarioRepository.BuscaPorId(id); // Busca o usuário pelo ID.
            if (usuario == null)
            {
                return NotFound(); // Retorna 404 se o usuário não for encontrado.
            }
            return Ok(usuario); // Retorna o usuário encontrado com status 200 (OK).
        }
        // PUT -> /api/usuarios/{id}
        // Atualiza
        [Authorize]
        [HttpPut("{id}")]// Mapeia solicitações PUT para este método com um parâmetro ID.

        public IActionResult Atualizar(int id, Usuario usuario) // Método para atualizar um usuário pelo ID.
        {
            _usuarioRepository.Atualizar(id, usuario); // Chama o repositório para atualizar o usuário.
            return StatusCode(204); // Retorna status 204 (Sem Conteúdo) após atualização.
        }
        // DELETE -> /api/usuarios/{id}
        [Authorize]
        [HttpDelete("{id}")] // Mapeia solicitações DELETE para este método com um parâmetro ID.
        public IActionResult Deletar(int id) // Método para deletar um usuário pelo ID.
        {
            try
            {
                _usuarioRepository.Deletar(id); // Chama o repositório para deletar o usuário.
                return StatusCode(204); // Retorna status 204 (Sem Conteúdo) após exclusão.
            }
            catch (Exception e)
            {
                return BadRequest(); // Retorna status 400 (Solicitação Inválida) em caso de erro.
            }
        }
    }
}
