import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

export interface Produto {
    id?: string;
    codigo: string;
    descricao: string;
    departamentoCodigo: string;
    preco: number;
    ativo: boolean;
}

export interface Departamento {
    codigo: string;
    descricao: string;
}

@Injectable({
    providedIn: 'root'
})
export class ProdutoService {
    private apiUrl = environment.apiUrl + '/produto';
    private deptUrl = environment.apiUrl.replace('/api', '/api/departamentos');

    constructor(private http: HttpClient) { }

    getProdutos(): Observable<Produto[]> {
        return this.http.get<Produto[]>(this.apiUrl);
    }

    getProduto(id: string): Observable<Produto> {
        return this.http.get<Produto>(`${this.apiUrl}/${id}`);
    }

    addProduto(produto: Produto): Observable<any> {
        return this.http.post(this.apiUrl, produto);
    }

    updateProduto(id: string, produto: Produto): Observable<any> {
        return this.http.put(`${this.apiUrl}/${id}`, produto);
    }

    deleteProduto(id: string): Observable<any> {
        return this.http.delete(`${this.apiUrl}/${id}`);
    }

    getDepartamentos(): Observable<Departamento[]> {
        return this.http.get<Departamento[]>(this.deptUrl);
    }
}
