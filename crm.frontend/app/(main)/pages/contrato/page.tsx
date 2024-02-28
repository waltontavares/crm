'use client';
import { Button } from 'primereact/button';
import { Column } from 'primereact/column';
import { DataTable } from 'primereact/datatable';
import { Dialog } from 'primereact/dialog';
import { InputText } from 'primereact/inputtext';
import { Dropdown, DropdownChangeEvent } from 'primereact/dropdown';
import { InputNumber, InputNumberValueChangeEvent } from 'primereact/inputnumber';
import { Toast } from 'primereact/toast';
import { Toolbar } from 'primereact/toolbar';
import { classNames } from 'primereact/utils';
import React, { useEffect, useMemo, useRef, useState } from 'react';
import { Crm } from '../../../../types/types';
import { ClausulaService } from '../../../../service/ClausulaService';
//import { ClausulaAbusivaService } from '../../../../service/ClausulaAbusivaService';
import { PessoaService } from '../../../../service/PessoaService';
import { BancoService } from '../../../../service/BancoService';
import { ContratoService } from '../../../../service/ContratoService';

const Contrato = () => {

    let emptyContrato: Crm.Contrato = {
        id: 0,
        num_Contrato: '',
        valor_Bem: 0,
        valor_Entrada: 0,
        valor_Financiar: 0,
        parcelas: 0,
        valor_Parcela: 0,
        total_Financiamento: 0,
        juros_Mensal: 0,
        juros_Anual: 0,
        cet_Mensal: 0,
        cet_Anual: 0,
        iof: 0,
        saldo_Financiar: 0,
        total_Clausulas_Abusivas_Iof: 0,
        total_Acao: 0,
        taxa_Media_Juros: 0,
        valor_Tutela: 0,
        dt_Ins: null,
        dt_Upd: null,
        pessoaId: 0,
        pessoa: {nome: ''},
        bancoId: 0,
        banco: {fantasia: ''},
    };

    let emptyClausula: Crm.Clausula_Abusiva = {
        id: 0,
        contratoId: 0,
        ccontrato: {num_Contrato: '', valor_Bem: 0, valor_Entrada: 0, parcelas: 0, valor_Parcela: 0},
        clausulaId: 0,
        clausula: {desc_Clausula: ''},
        valor_Clausula: 0,
    };

    const [contratos, setContratos] = useState<Crm.Contrato[] | null>(null);
    const [contrato, setContrato] = useState<Crm.Contrato>(emptyContrato);
    const [clausulas, setClausulas] = useState<Crm.Clausula[]>([]);
    const [clausula, setClausula] = useState<Crm.Clausula_Abusiva>(emptyClausula);
    const [selectedContratos, setSelectedContratos] = useState(null);
    const [contratoDialog, setContratoDialog] = useState(false);
    const [clausulaDialog, setClausulaDialog] = useState(false);
    const [pessoas, setPessoas] = useState<Crm.Pessoa[]>([]);
    const [bancos, setBancos] = useState<Crm.Banco[]>([]);
    const [submitted, setSubmitted] = useState(false);
    const [globalFilter, setGlobalFilter] = useState('');
    const toast = useRef<Toast>(null);
    const dt = useRef<DataTable<any>>(null);
    const clausulaService = useMemo(() => new ClausulaService(), []);
    const pessoaService = useMemo(() => new PessoaService(), []);
    const bancoService = useMemo(() => new BancoService(), []);
    const contratoService = useMemo(() => new ContratoService(), []);
        
    useEffect(() => {
        if(!contratos){
            contratoService.listarTodos()
                .then((response) => {
                    setContratos(response.data);
                }).catch((error) => {
                    console.log(error);
                })
        }
    }, [contratoService, contratos]);

    useEffect(() => {
        if(contratoDialog){
            pessoaService.listarTodos()
                .then((response) => {
                    setPessoas(response.data);
                }).catch((error) => {
                    console.log(error);
                })
            bancoService.listarTodos()
            .then((response) => {
                setBancos(response.data);
                }).catch((error) => {
                    console.log(error);
                })
        }
    }, [bancoService, contratoDialog, pessoaService]);

    useEffect(() => {
        if(clausulaDialog){
            clausulaService.listarTodos()
            .then((response) => {
                setPessoas(response.data);
                }).catch((error) => {
                    console.log(error);
                })
        }
    }, [clausulaService, clausulaDialog]);

    const formatCurrency = (value: number) => {
        return value.toLocaleString('pt-BR', {
            style: 'currency',
            currency: 'BRL'
        });
    };

    const openNew = () => {
        setContrato(emptyContrato);
        setSubmitted(false);
        setContratoDialog(true);
    };

    const openClausulaNew = () => {
        setClausula(emptyClausula);
        setSubmitted(false);
        setClausulaDialog(true);
    };

    const hideDialog = () => {
        setSubmitted(false);
        setContratoDialog(false);
    };

    const saveContrato = () => {
         if (!contrato.id){
            const { banco, ...dadosSemBanco } = contrato;
            const { pessoa, ...dadosSemPessoa } = dadosSemBanco;
            contratoService.inserir(dadosSemPessoa)
            .then((response) => {
                setContratoDialog(false);
                setContrato(emptyContrato);
                setContratos(null);
                toast.current?.show({
                    severity: 'info',
                    summary: 'Sucesso!',
                    detail: 'Contrato cadastrado com sucesso!'  
                })
            }).catch((error) => {
                console.log(error)
                toast.current?.show({
                    severity: 'error',
                    summary: 'Erro!',
                    detail: 'Erro ao salvar contrato! ' + error.response.messege
                    })
            });
        }else{
            contratoService.alterar(contrato)
            .then((response) => {
                setContratoDialog(false);
                setContrato(emptyContrato);
                setContratos(null);
                toast.current?.show({
                    severity: 'info',
                    summary: 'Sucesso!',
                    detail: 'Contrato alterada com sucesso!'  
                })
            }).catch((error) => {
                console.log(error)
                toast.current?.show({
                    severity: 'error',
                    summary: 'Erro!',
                    detail: 'Erro ao alterar contrato!' + error.data.messege  
                })
            });
        }
    };

    const editContrato = (editContrato: Crm.Contrato) => {
        setContrato({ ...editContrato });        
        setContratoDialog(true);
    };

    const exportCSV = () => {
        dt.current?.exportCSV();
    };

    const onInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>, campo: string) => {
        const val = (e.target && e.target.value) || '';
        let _contrato = { ...contrato };
        _contrato[`${campo}`] = val;

        setContrato(_contrato);
    };

    const onInputNumberChange = (e: InputNumberValueChangeEvent, campo: string) => {
        const val = (e.target && e.target.value) || 0;
        let _contrato = { ...contrato };
        _contrato[`${campo}`] = val;

        setContrato(_contrato);
    };

    const onSelectedChangePessoa = (e: Crm.Pessoa) => {
        let _contrato = { ...contrato };
        _contrato['pessoaId'] = e.id;
        _contrato['pessoa'] = e;

        setContrato(_contrato);
    };

    const onSelectedChangeClausula = (e: Crm.Clausula) => {
        let _clausula = { ...clausula };
        _clausula['clausulaId'] = e.id;
        _clausula['clausula'] = e;

        setClausula(_clausula);
    };

    const onSelectedChangeBanco = (e: Crm.Banco) => {
        let _contrato = { ...contrato };
        _contrato['bancoId'] = e.id;
        _contrato['banco'] = e;

        setContrato(_contrato);
    };

    const onBlurValorFinanciar = (e, campo: string) => {
        let _contrato = { ...contrato };
        let val = 0;

        if (campo == "valor_Bem"){
            val = parseFloat(e.target.value.replace(',', '.')) - contrato.valor_Entrada || 0;
        }

        if (campo == "valor_Entrada"){
            val = contrato.valor_Bem - parseFloat(e.target.value.replace(',', '.'));
        }
        _contrato['valor_Financiar'] = val;

        setContrato(_contrato);
    }

    const onBlurTotalFinanciado = (e, campo: string) => {
        let _contrato = { ...contrato };
        let val = 0;

        if (campo == "parcelas"){
            val = parseFloat(e.target.value) * contrato.valor_Parcela;
        }

        if (campo == "valor_Parcela"){
            val = contrato.parcelas * parseFloat(e.target.value.replace(',', '.'));
        }
        _contrato['total_Financiamento'] = val;

        setContrato(_contrato);
    }

    // const onBlurCep = (e) => {
    //     if (e.target.value != ""){
    //         enderecoService.BuscarEnderecoCep(e.target.value)
    //         .then((response) => {
    //             let _pessoa = { ...pessoa };
    //             _pessoa['logradouro'] = response.data.logradouro;                    
    //             _pessoa['bairro'] = response.data.bairro;
    //             _pessoa['cidade'] = response.data.cidade;
    //             _pessoa['uf'] = response.data.uf;
    //             setPessoa(_pessoa);
    //         }).catch((error) => {
    //             console.log(error)
    //             if(error.response.status == 404){
    //                 toast.current?.show({
    //                     severity: 'error',
    //                     summary: 'Erro!',
    //                     detail: 'Cep Não encontrado'
    //                 })
    //             }
    //         });
    //     }
    // }

    const leftToolbarTemplate = () => {
        return (
            <React.Fragment>
                <div className="my-2">
                    <Button label="Novo" icon="pi pi-plus" severity="success" className=" mr-2" onClick={openNew} />
                </div>
            </React.Fragment>
        );
    };

    const idBodyTemplate = (rowData: Crm.Contrato) => {
        return (
            <>
                <span className="p-column-title">Código</span>
                {rowData.id}
            </>
        );
    };

    const numeroBodyTemplate = (rowData: Crm.Contrato) => {
        return (
            <>
                <span className="p-column-title">Número</span>
                {rowData.num_Contrato}
            </>
        );
    };

    const pessoaBodyTemplate = (rowData: Crm.Contrato) => {
        return (
            <>
                <span className="p-column-title">Cliente</span>
                {rowData.pessoa?.nome}
            </>
        );
    };

    const bancoBodyTemplate = (rowData: Crm.Contrato) => {
        return (
            <>
                <span className="p-column-title">Banco</span>
                {rowData.banco?.fantasia}
            </>
        );
    };

    const valorBemBodyTemplate = (rowData: Crm.Contrato) => {
        return (
            <>
                <span className="p-column-title">Valor do Bem</span>
                {formatCurrency(rowData.valor_Bem as number)}
            </>
        );
    };

    const valorEntradaBodyTemplate = (rowData: Crm.Contrato) => {
        return (
            <>
                <span className="p-column-title">Valor da Entrada</span>
                {formatCurrency(rowData.valor_Entrada as number)}
            </>
        );
    };

    const valorFianciarBodyTemplate = (rowData: Crm.Contrato) => {
        return (
            <>
                <span className="p-column-title">Valor a Financiar</span>
                {formatCurrency(rowData.valor_Financiar as number)}
            </>
        );
    };

    const parcelasBodyTemplate = (rowData: Crm.Contrato) => {
        return (
            <>
                <span className="p-column-title">Parcelas</span>
                {rowData.parcelas}
            </>
        );
    };

    const valorParcelaBodyTemplate = (rowData: Crm.Contrato) => {
        return (
            <>
                <span className="p-column-title">Valor da Parcela</span>
                {formatCurrency(rowData.valor_Parcela as number)}
            </>
        );
    };

    const totalFianciadoBodyTemplate = (rowData: Crm.Contrato) => {
        return (
            <>
                <span className="p-column-title">Total Financiado</span>
                {formatCurrency(rowData.valor_Financiar as number)}
            </>
        );
    };

    const jurosMensalBodyTemplate = (rowData: Crm.Contrato) => {
        return (
            <>
                <span className="p-column-title">Juros Mensal</span>
                {rowData.juros_Mensal as number}
            </>
        );
    };

    const jurosAnualBodyTemplate = (rowData: Crm.Contrato) => {
        return (
            <>
                <span className="p-column-title">Juros Anual</span>
                {rowData.juros_Anual as number}
            </>
        );
    };

    const cetMensalBodyTemplate = (rowData: Crm.Contrato) => {
        return (
            <>
                <span className="p-column-title">CET Mensal</span>
                {rowData.cet_Mensal as number}
            </>
        );
    };

    const cetAnualBodyTemplate = (rowData: Crm.Contrato) => {
        return (
            <>
                <span className="p-column-title">CET Anual</span>
                {rowData.cet_Anual as number}
            </>
        );
    };

    const iofBodyTemplate = (rowData: Crm.Contrato) => {
        return (
            <>
                <span className="p-column-title">IOF</span>
                {rowData.iof as number}
            </>
        );
    };

    const saldoFinanciarBodyTemplate = (rowData: Crm.Contrato) => {
        return (
            <>
                <span className="p-column-title">Saldo a Financiar</span>
                {formatCurrency(rowData.saldo_Financiar as number)}
            </>
        );
    };

    const totalClausulasBodyTemplate = (rowData: Crm.Contrato) => {
        return (
            <>
                <span className="p-column-title">Clausulas Abusivas com IOF</span>
                {formatCurrency(rowData.total_Clausulas_Abusivas_Iof as number)}
            </>
        );
    };

    const totalAcaoBodyTemplate = (rowData: Crm.Contrato) => {
        return (
            <>
                <span className="p-column-title">Total da Ação</span>
                {formatCurrency(rowData.total_Acao as number)}
            </>
        );
    };

    const mediaJurosBodyTemplate = (rowData: Crm.Contrato) => {
        return (
            <>
                <span className="p-column-title">Taxa Média</span>
                {rowData.taxa_Media_Juros as number}
            </>
        );
    };
  
    const valorTutelaBodyTemplate = (rowData: Crm.Contrato) => {
        return (
            <>
                <span className="p-column-title">Valor Tutela</span>
                {formatCurrency(rowData.valor_Tutela as number)}
            </>
        );
    };

    const actionBodyTemplate = (rowData: Crm.Contrato) => {
        return (
            <>
                <Button icon="pi pi-pencil" rounded severity="success" className="mr-2" onClick={() => editContrato(rowData)} />
            </>
        );
    };

    const header = (
        <div className="flex flex-column md:flex-row md:justify-content-between md:align-items-center">
            <h5 className="m-0">Cadastro de Contratos</h5>
            <span className="block mt-2 md:mt-0 p-input-icon-left">
                <i className="pi pi-search" />
                <InputText type="search" onInput={(e) => setGlobalFilter(e.currentTarget.value)} placeholder="Search..." />
            </span>
        </div>
    );

    const pessoaDialogFooter = (
        <>
            <Button label="Cancelar" icon="pi pi-times" text onClick={hideDialog} />
            <Button label="Salvar" icon="pi pi-check" text onClick={saveContrato} />
        </>
    );
    
    return (
        <div className="grid crud-demo">
            <div className="col-12">
                <div className="card">
                    <Toast ref={toast} />
                    <Toolbar className="mb-4" left={leftToolbarTemplate}></Toolbar>

                    <DataTable
                        ref={dt}
                        value={contratos}
                        selection={selectedContratos}
                        onSelectionChange={(e) => setSelectedContratos(e.value as any)}
                        dataKey="id"
                        paginator
                        rows={10}
                        rowsPerPageOptions={[5, 10, 25]}
                        className="datatable-responsive"
                        paginatorTemplate="FirstPageLink PrevPageLink PageLinks NextPageLink LastPageLink CurrentPageReport RowsPerPageDropdown"
                        currentPageReportTemplate="Mostrando {first} até {last} de {totalRecords} pessoas"
                        globalFilter={globalFilter}
                        emptyMessage="Nenhuma pessoa encontrada."
                        header={header}
                        responsiveLayout="scroll"
                    >
                        <Column body={actionBodyTemplate} headerStyle={{ minWidth: '5rem' }}></Column>
                        <Column field="id" header="Id" sortable body={idBodyTemplate} headerStyle={{ minWidth: '5rem' }}></Column>
                        <Column field="num_Contrato" header="Num. Contrato" sortable body={numeroBodyTemplate}  headerStyle={{ minWidth: '5rem' }}></Column>
                        <Column field="pessoa" header="Pessoa" sortable body={pessoaBodyTemplate} headerStyle={{ minWidth: '15rem' }}></Column>
                        <Column field="banco" header="Banco" sortable body={bancoBodyTemplate} headerStyle={{ minWidth: '15rem' }}></Column>
                        <Column field="valor_Bem" header="Valor Bem" sortable body={valorBemBodyTemplate}  headerStyle={{ minWidth: '5rem' }}></Column>
                        <Column field="valor_Entrada" header="Valor Entrada" sortable body={valorEntradaBodyTemplate} headerStyle={{ minWidth: '5rem' }}></Column>
                        <Column field="valor_Financiar" header="Valor Financiar" sortable body={valorFianciarBodyTemplate} headerStyle={{ minWidth: '5rem' }}></Column>
                        <Column field="parcelas" header="Parcelas" sortable body={parcelasBodyTemplate} headerStyle={{ minWidth: '5rem' }}></Column>
                        <Column field="valor_Parcela" header="Valor Parcela" sortable body={valorParcelaBodyTemplate} headerStyle={{ minWidth: '5rem' }}></Column>
                        <Column field="total_Financiado" header="Total Financiado" sortable body={totalFianciadoBodyTemplate} headerStyle={{ minWidth: '5rem' }}></Column>
                        <Column field="juros_Mensal" header="Juros Mensal" sortable body={jurosMensalBodyTemplate} headerStyle={{ minWidth: '5rem' }}></Column>
                        <Column field="juros_Anual" header="Juros Anual" sortable body={jurosAnualBodyTemplate} headerStyle={{ minWidth: '5rem' }}></Column>
                        <Column field="cet_Mensal" header="CET Mensal" sortable body={cetMensalBodyTemplate} headerStyle={{ minWidth: '5rem' }}></Column>
                        <Column field="cet_Anual" header="CET Anual" sortable body={cetAnualBodyTemplate} headerStyle={{ minWidth: '5rem' }}></Column>
                        <Column field="iof" header="IOF" sortable body={iofBodyTemplate} headerStyle={{ minWidth: '5rem' }}></Column>
                        <Column field="saldo_Financiar" header="Saldo Financiar" sortable body={saldoFinanciarBodyTemplate} headerStyle={{ minWidth: '5rem' }}></Column>
                        <Column field="total_Clausulas_Abusivas_Iof" header="Clausulas Abusivas" sortable body={totalClausulasBodyTemplate} headerStyle={{ minWidth: '5rem' }}></Column>
                        <Column field="total_Acao" header="Total Acao" sortable body={totalAcaoBodyTemplate} headerStyle={{ minWidth: '5rem' }}></Column>
                        <Column field="taxa_Media_Juros" header="Taxa Juros" sortable body={mediaJurosBodyTemplate} headerStyle={{ minWidth: '5rem' }}></Column>
                        <Column field="valor_Tutela" header="Valor Tutela" sortable body={valorTutelaBodyTemplate} headerStyle={{ minWidth: '5rem' }}></Column>
                    </DataTable>

                    <Dialog visible={contratoDialog} style={{ width: '450px' }} header="Detalhes da Contrato" modal className="p-fluid" footer={pessoaDialogFooter} onHide={hideDialog}>
                        <div className="field">
                            <label htmlFor="Pessoa">Cliente</label>
                            <Dropdown 
                                id="pessoa"
                                value={contrato.pessoa} 
                                onChange={(e: DropdownChangeEvent) => onSelectedChangePessoa(e.value)}
                                options={pessoas} 
                                optionLabel="nome"
                                placeholder="Selecione o cliente" 
                                required 
                                className={classNames({
                                    'p-invalid': submitted && !contrato.pessoa
                                })}
                            />
                            {submitted && !contrato.pessoa && <small className="p-invalid">Cliente é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Banco">Banco</label>
                            <Dropdown 
                                id="banco"
                                value={contrato.banco} 
                                onChange={(e: DropdownChangeEvent) => onSelectedChangeBanco(e.value)}
                                options={bancos} 
                                optionLabel="fantasia"
                                placeholder="Selecione o banco" 
                                required 
                                className={classNames({
                                    'p-invalid': submitted && !contrato.banco
                                })}
                            />
                            {submitted && !contrato.banco && <small className="p-invalid">Banco é obrigatório.</small>}
                        </div>

                    <div className="field">
                            <label htmlFor="Contrato">Contrato</label>
                            <InputText
                                id="num_Contrato"
                                value={contrato.num_Contrato}
                                onChange={(e) => onInputChange(e, 'num_Contrato')}
                                required
                                autoFocus
                                className={classNames({
                                    'p-invalid': submitted && !contrato.num_Contrato
                                })}
                            />
                            {submitted && !contrato.num_Contrato && <small className="p-invalid">Número do contrato é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Bem">Valor do Bem</label>
                            <InputNumber
                                id="valor_Bem"
                                value={contrato.valor_Bem}
                                onValueChange={(e) => onInputNumberChange(e, 'valor_Bem')}
                                onBlur={(e) => onBlurValorFinanciar(e, 'valor_Bem')}
                                required
                                locale="pt-BR" minFractionDigits={2}
                                className={classNames({
                                    'p-invalid': submitted && !contrato.valor_Bem
                                })}
                            />
                            {submitted && !contrato.valor_Bem && <small className="p-invalid">Valor do Bem é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Entrada">Valor da Entrada</label>
                            <InputNumber
                                id="valor_Entrada"
                                value={contrato.valor_Entrada}
                                onValueChange={(e) => onInputNumberChange(e, 'valor_Entrada')}
                                onBlur={(e) => onBlurValorFinanciar(e, 'valor_Entrada')}
                                locale="pt-BR" minFractionDigits={2}
                                required
                                className={classNames({
                                    'p-invalid': submitted && !contrato.valor_Entrada
                                })}
                            />
                            {submitted && !contrato.valor_Entrada && <small className="p-invalid">Valor da Entrada é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Financiar">Valor a Financiar</label>
                            <InputNumber
                                id="valor_Financiar"
                                value={contrato.valor_Financiar}
                                onValueChange={(e) => onInputNumberChange(e, 'valor_Financiar')}
                                locale="pt-BR" minFractionDigits={2}
                                required
                                disabled
                                className={classNames({
                                    'p-invalid': submitted && !contrato.valor_Financiar
                                })}
                            />
                            {submitted && !contrato.valor_Financiar && <small className="p-invalid">Valor a Financiar é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Parcelas">Parcelas</label>
                            <InputNumber
                                id="parcelas"
                                value={contrato.parcelas}
                                onValueChange={(e) => onInputNumberChange(e, 'parcelas')}
                                onBlur={(e) => onBlurTotalFinanciado(e, 'parcelas')}
                                required
                                className={classNames({
                                    'p-invalid': submitted && !contrato.parcelas
                                })}
                            />
                            {submitted && !contrato.parcelas && <small className="p-invalid">Quantidade de Parcelas é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Parcela">Valor da Parcela</label>
                            <InputNumber
                                id="valor_Parcela"
                                value={contrato.valor_Parcela}
                                onValueChange={(e) => onInputNumberChange(e, 'valor_Parcela')}
                                onBlur={(e) => onBlurTotalFinanciado(e, 'valor_Parcela')}
                                locale="pt-BR" minFractionDigits={2}
                                required
                                className={classNames({
                                    'p-invalid': submitted && !contrato.valor_Parcela
                                })}
                            />
                            {submitted && !contrato.valor_Parcela && <small className="p-invalid">Valor da Parcela é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Financiar">Total Financiamento</label>
                            <InputNumber
                                id="total_Financiamento"
                                value={contrato.total_Financiamento}
                                onValueChange={(e) => onInputNumberChange(e, 'total_Financiamento')}
                                locale="pt-BR" minFractionDigits={2}
                                required
                                disabled
                                className={classNames({
                                    'p-invalid': submitted && !contrato.total_Financiamento
                                })}
                            />
                            {submitted && !contrato.total_Financiamento && <small className="p-invalid">Total Financiamento é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Mensal">Juros Mensal</label>
                            <InputNumber
                                id="juros_Mensal"
                                value={contrato.juros_Mensal}
                                onValueChange={(e) => onInputNumberChange(e, 'juros_Mensal')}
                                required
                                className={classNames({
                                    'p-invalid': submitted && !contrato.juros_Mensal
                                })}
                            />
                            {submitted && !contrato.juros_Mensal && <small className="p-invalid">Juros Mensal é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Anual">Juros Anual</label>
                            <InputNumber 
                                id="juros_Anual"
                                value={contrato.juros_Anual}
                                onValueChange={(e) => onInputNumberChange(e, 'juros_Anual')}
                                required
                                className={classNames({
                                    'p-invalid': submitted && !contrato.juros_Anual
                                })}
                            />
                            {submitted && !contrato.juros_Anual && <small className="p-invalid">Juros Anual é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="CetMensal">CET Mensal</label>
                            <InputNumber
                                id="cet_Mensal"
                                value={contrato.cet_Mensal}
                                onValueChange={(e) => onInputNumberChange(e, 'cet_Mensal')}
                                required
                                className={classNames({
                                    'p-invalid': submitted && !contrato.cet_Mensal
                                })}
                            />
                            {submitted && !contrato.cet_Mensal && <small className="p-invalid">CET Mensal é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="CetAnual">CET Anual</label>
                            <InputNumber
                                id="cet_Anual"
                                value={contrato.cet_Anual}
                                onValueChange={(e) => onInputNumberChange(e, 'cet_Anual')}
                                required
                                className={classNames({
                                    'p-invalid': submitted && !contrato.cet_Anual
                                })}
                            />
                            {submitted && !contrato.cet_Anual && <small className="p-invalid">CET Anual é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Iof">IOF</label>
                            <InputNumber
                                id="iof"
                                value={contrato.iof}
                                onValueChange={(e) => onInputNumberChange(e, 'iof')}
                                required
                                className={classNames({
                                    'p-invalid': submitted && !contrato.iof
                                })}
                            />
                            {submitted && !contrato.iof && <small className="p-invalid">IOF é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Saldo">Saldo a Financiar</label>
                            <InputNumber
                                id="saldo_Financiar"
                                value={contrato.saldo_Financiar}
                                onValueChange={(e) => onInputNumberChange(e, 'saldo_Financiar')}
                                required
                                className={classNames({
                                    'p-invalid': submitted && !contrato.saldo_Financiar
                                })}
                            />
                            {submitted && !contrato.saldo_Financiar && <small className="p-invalid">Saldo a Financiar é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="ClausulasUf">Total Clausulas Abusivas</label>
                            <div className="formgrid grid">
                                <div style={{ width: '350px' }}>
                                    <InputNumber
                                        id="total_Clausulas_Abusivas_Iof"
                                        value={contrato.total_Clausulas_Abusivas_Iof}
                                        onValueChange={(e) => onInputNumberChange(e, 'total_Clausulas_Abusivas_Iof')}
                                        required
                                        className={classNames({
                                            'p-invalid': submitted && !contrato.total_Clausulas_Abusivas_Iof
                                        })}
                                    />
                                </div>
                                <div>
                                    <Button label="..."  onClick={hideDialog} />
                                </div>
                                {submitted && !contrato.total_Clausulas_Abusivas_Iof && <small className="p-invalid">Total Clausulas Abusivas é obrigatório.</small>}
                            </div>
                        </div>

                        <div className="field">
                            <label htmlFor="Acao">Total da Ação</label>
                            <InputNumber
                                id="total_Acao"
                                value={contrato.total_Acao}
                                onValueChange={(e) => onInputNumberChange(e, 'total_Acao')}
                                required
                                className={classNames({
                                    'p-invalid': submitted && !contrato.total_Acao
                                })}
                            />
                            {submitted && !contrato.total_Acao && <small className="p-invalid">Total da Ação é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Juros">Taxa Média de Juros</label>
                            <InputNumber
                                id="taxa_Media_Juros"
                                value={contrato.taxa_Media_Juros}
                                onValueChange={(e) => onInputNumberChange(e, 'taxa_Media_Juros')}
                                required
                                className={classNames({
                                    'p-invalid': submitted && !contrato.taxa_Media_Juros
                                })}
                            />
                            {submitted && !contrato.taxa_Media_Juros && <small className="p-invalid">Taxa Média de Juros é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Tutela">Valor da Tutela</label>
                            <InputNumber
                                id="valor_Tutela"
                                value={contrato.valor_Tutela}
                                onValueChange={(e) => onInputNumberChange(e, 'valor_Tutela')}
                                required
                                className={classNames({
                                    'p-invalid': submitted && !contrato.valor_Tutela
                                })}
                            />
                            {submitted && !contrato.valor_Tutela && <small className="p-invalid">Valor da Tutela é obrigatório.</small>}
                        </div>
                    </Dialog>
                    <Dialog visible={clausulaDialog} style={{ width: '450px' }} header="Clausulas Abusivas" modal className="p-fluid" footer={pessoaDialogFooter} onHide={hideDialog}>
                        <div className="field">
                            <label htmlFor="Clausula">Clausula</label>
                            <Dropdown 
                                id="clausula"
                                value={clausula.clausula} 
                                onChange={(e: DropdownChangeEvent) => onSelectedChangeClausula(e.value)}
                                options={clausula} 
                                optionLabel="desc_Clausula"
                                placeholder="Selecione a Cllausula" 
                                required 
                                className={classNames({
                                    'p-invalid': submitted && !clausula.clausula
                                })}
                            />
                            {submitted && !clausula.clausula && <small className="p-invalid">Clausula é obrigatório.</small>}
                        </div>
                        <div className="field">
                            <label htmlFor="Tutela">Valor da Tutela</label>
                            <InputNumber
                                id="valor_Tutela"
                                value={contrato.valor_Tutela}
                                onValueChange={(e) => onInputNumberChange(e, 'valor_Tutela')}
                                required
                                className={classNames({
                                    'p-invalid': submitted && !contrato.valor_Tutela
                                })}
                            />
                            {submitted && !contrato.valor_Tutela && <small className="p-invalid">Valor da Tutela é obrigatório.</small>}
                        </div>                        
                    </Dialog>
                </div>
            </div>
        </div>
    );
};

export default Contrato;