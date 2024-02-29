import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs'; // Classe requisição de forma assinocra
import { Produto } from './models/Produto.models'

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {

  private url = "http://localhost:3000/produtos";

  //injeção de dependencia
  constructor(private _httpCliente: HttpClient) { }
 
  getProduto(id:any): Observable<Produto>{ //Pegar um unico produto pelo id
    const urlIdProduto = `${this.url}?id=${id}`;
    return this._httpCliente.get<Produto>(urlIdProduto);
  }

  getProdutos(): Observable<Produto[]>{   //Listar todos os produtos
    return this._httpCliente.get<Produto[]>(this.url);
  }

  cadastrarProduto(produto: Produto): Observable<Produto[]>{//Cadastra produto pegnd o endereço da api e o q vai cadastrar
    return this._httpCliente.post<Produto[]>(this.url, produto);
  }

  atualizaProduto(id:any, produto: Produto): Observable<Produto[]>{// att produto pegando o id e o produto
    const urlAtualizar = `${this.url}/?${id}`; //variavel nao ser alterada durante o processo
    return this._httpCliente.put<Produto[]>(urlAtualizar, produto)//pegar url produtos e id
  }

  removerProduto(id:any): Observable<Produto[]>{
    const urlDeletar = `${this.url}/?${id}`;
    return this._httpCliente.delete<Produto[]>(urlDeletar);

  }
}
