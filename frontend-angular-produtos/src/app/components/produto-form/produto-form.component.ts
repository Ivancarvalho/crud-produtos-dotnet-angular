import { Component, OnInit } from '@angular/core';
import { ProdutoService, Produto, Departamento } from '../../services/produto.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-produto-form',
  templateUrl: './produto-form.component.html'
})
export class ProdutoFormComponent implements OnInit {
  produto: Produto = {
    codigo: '',
    descricao: '',
    departamentoCodigo: '',
    preco: 0,
    ativo: true
  };
  departamentos: Departamento[] = [];
  editando = false;

  constructor(
    private produtoService: ProdutoService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit() {
    this.produtoService.getDepartamentos().subscribe(depts => {
      this.departamentos = depts;
    });

    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.editando = true;
      this.produtoService.getProduto(id).subscribe(produto => {
        this.produto = produto;
      });
    }
  }

  salvar() {
    if (this.editando && this.produto.id) {
      this.produtoService.updateProduto(this.produto.id, this.produto).subscribe(() => {
        this.router.navigate(['/produtos']);
      });
    } else {
      this.produtoService.addProduto(this.produto).subscribe(() => {
        this.router.navigate(['/produtos']);
      });
    }
  }

  cancelar() {
    this.router.navigate(['/produtos']);
  }
}
