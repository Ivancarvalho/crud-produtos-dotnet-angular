import { Component, OnInit } from '@angular/core';
import { ProdutoService, Produto } from '../../services/produto.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-produto-lista',
  templateUrl: './produto-lista.component.html'
})
export class ProdutoListaComponent implements OnInit {
  produtos: Produto[] = [];

  constructor(private produtoService: ProdutoService, private router: Router) { }

  ngOnInit() {
    this.carregarProdutos();
  }

  carregarProdutos() {
    this.produtoService.getProdutos().subscribe(dados => {
      this.produtos = dados;
    });
  }

  editar(id: string) {
    this.router.navigate(['/produtos/editar', id]);
  }

  excluir(id: string) {
    if (confirm('Confirma exclusão?')) {
      this.produtoService.deleteProduto(id).subscribe(() => {
        this.carregarProdutos();
      });
    }
  }

  novo() {
    this.router.navigate(['/produtos/novo']);
  }
}
