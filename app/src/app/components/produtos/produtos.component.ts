import { Component, OnInit } from '@angular/core';
import { Produto } from '../../models/produto';
import { ProdutoService } from '../../services/produto.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-produtos',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.scss'],
  standalone: false,
})
export class ProdutosComponent implements OnInit {
  produtos: any[] = [];
  displayedColumns: string[] = ['id', 'nome', 'preco', 'quantidade'];

  constructor(
    private produtoService: ProdutoService,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.carregarProdutos();
  }

  carregarProdutos(): void {
    this.produtoService.getProdutos().subscribe({
      next: (data) => {
        this.produtos = data;
        this.snackBar.open('Produtos carregados com sucesso!', 'Fechar', {
          duration: 3000,
        });
      },
      error: (error) => {
        this.snackBar.open('Erro ao obter produtos. Tente novamente.', 'Fechar', {
          duration: 3000,
        });
        console.error('Erro ao obter produtos', error);
      },
      complete: () => {
        console.log('Requisição de produtos concluída');
      }
    });
  }


}
