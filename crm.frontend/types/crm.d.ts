declare namespace Crm{

    //EstadoCivilService
    type Estado_Civil = {
        id?: number;
        estado?: string;
    };

    //PessoaService
    type Pessoa = {
        id?: number;
        nome?: string;
        rg?: string;
        exp?: string;
        cpf?: string;
        email?: string;
        telefone?: string;
        cep?: string;
        logradouro?: string;
        numero?: string;
        complemento?: string;
        bairro?: string;
        cidade?: string;
        uf?: string;
        nacionalidade?: string;
        profissao?: string;
        estado_CivilId?: number,
        estado_Civil?: Estado_Civil;
    };

    //BancoService
    type Banco = {
        id?: number;
        fantasia?: string;
        razao?: string;
        cnpj?: string;
        endereco?: string;
        complemento?: string;
        bairro?: string;
        cidade?: string;
        uf?: string;
        cep?: string;
        email?: string;
        telefone?: string;
    };

    //ContratoService
    type Contrato = {
        id?: number;
        num_Contrato?: string;
        valor_Bem: number;
        valor_Entrada: number;
        valor_Financiar?: number;
        parcelas: number;
        valor_Parcela: number;
        total_Financiamento?: number;
        juros_Mensal?: number;
        juros_Anual?: number;
        cet_Mensal?: number;
        cet_Anual?: number;
        iof?: number;
        saldo_Financiar?: number;
        total_Clausulas_Abusivas_Iof?: number;
        total_Acao?: number;
        taxa_Media_Juros?: number;
        valor_Tutela?: number;
        dt_Ins?: datetime;
        dt_Upd?: datetime;
        pessoaId?: number;
        pessoa?: Pessoa 
        bancoId?: number;
        banco?: Banco;
    };

    //ClausulaService
    type Clausula = {
        id?: number;
        desc_Clausula?: string;
    };

    //ClausulaAbusicaService
    type Clausula_Abusiva = {
        id?: number;
        contratoId?: number;
        ccontrato: Contrato;
        clausulaId?: number;
        clausula: Clausula;
        valor_Clausula?: number;
    };
}