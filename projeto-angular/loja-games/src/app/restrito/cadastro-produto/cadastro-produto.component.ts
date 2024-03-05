import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Produto } from 'src/app/models/Produto.models';
import { ProdutoService } from 'src/app/produto.service';
 
@Component({
  selector: 'app-cadastro-produto',
  templateUrl: './cadastro-produto.component.html',
  styleUrls: ['./cadastro-produto.component.css']
}) 
export class CadastroProdutoComponent {

  public produto: Produto = new Produto(0,"","","",0);
  
  constructor(private _produtoService:ProdutoService, private _rounter: Router){}

  cadastrar():void{
    this._produtoService.cadastrarProduto(this.produto).subscribe(
      produto => {
        this.produto = new Produto(0,"","","",0);
        alert("Cadastrado com sucesso!")
      },
      err => {
        alert("Erro ao Cadastrar")
      }
    );

    this._rounter.navigate(["restrito/lista"]);
  }



} 
