import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/login.service';
import { Produto } from 'src/app/models/Produto.models';
import { ProdutoService } from 'src/app/produto.service';

@Component({
  selector: 'app-lista-produto',
  templateUrl: './lista-produto.component.html',
  styleUrls: ['./lista-produto.component.css']
})
export class ListaProdutoComponent implements OnInit {
  
  public produtos: Produto[] = [];

  constructor(private _produtoService:ProdutoService, private _rounter: Router, private _loginService: LoginService){ //Injeção de Dependencia
}
  
  ngOnInit(): void {
    this.listarProdutos();
    this._loginService.setMostraMenu(false);
  }
  listarProdutos():void{
    this._produtoService.getProdutos().subscribe(
      retornaProduto =>{
        this.produtos = retornaProduto.map(
          item => {
            return new Produto(
              item.id,
              item.produto,
              item.descricao,
              item.foto,
              item.preco
            );
          }
        )
      }
    )
  }

  excluir(id: number){
    this._produtoService.removerProduto(id).subscribe(
      produto => {
        this.listarProdutos();
      },
      erro => {
        alert("Erro ao Excluir")
      }
    );
  this._rounter.navigate(["/restrito/lista"])
  }
 

}
