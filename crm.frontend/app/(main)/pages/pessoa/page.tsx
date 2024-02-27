'use client';
import { Button } from 'primereact/button';
import { Column } from 'primereact/column';
import { DataTable } from 'primereact/datatable';
import { Dialog } from 'primereact/dialog';
import { InputText } from 'primereact/inputtext';
import { Dropdown, DropdownChangeEvent } from 'primereact/dropdown';
import { Toast } from 'primereact/toast';
import { Toolbar } from 'primereact/toolbar';
import { classNames } from 'primereact/utils';
import React, { useEffect, useMemo, useRef, useState } from 'react';
import { Crm } from '../../../../types/types';
import { PessoaService } from '../../../../service/PessoaService';
import { EnderecoService } from '../../../../service/EnderecoService';
import { EstadoCivilService } from '../../../../service/EstadoCivilService';

const Pessoa = () => {

    let emptyPessoa: Crm.Pessoa = {
        id: 0,
        nome: '',
        rg: '',
        exp: '',
        cpf: '',
        email: '',
        telefone: '',
        cep: '',
        logradouro: '',
        numero: '',
        complemento: '',
        bairro: '',
        cidade: '',
        uf: '',
        nacionalidade: '',
        profissao: '',
        estado_CivilId: 0,
        estado_Civil: {estado: ''}
    };

    const [pessoas, setPessoas] = useState<Crm.Pessoa[] | null>(null);
    const [pessoa, setPessoa] = useState<Crm.Pessoa>(emptyPessoa);
    const [selectedPessoas, setSelectedPessoas] = useState(null);
    const [pessoaDialog, setPessoaDialog] = useState(false);
    const [estadosCivis, setEstadosCivis] = useState<Crm.Estado_Civil[]>([]);
    const [submitted, setSubmitted] = useState(false);
    const [globalFilter, setGlobalFilter] = useState('');
    const toast = useRef<Toast>(null);
    const dt = useRef<DataTable<any>>(null);
    const pessoaService = useMemo(() => new PessoaService(), []);
    const enderecoService = useMemo(() => new EnderecoService(), []);
    const estadoCivilService = useMemo(() => new EstadoCivilService(), []);
        
    useEffect(() => {
        if(!pessoas){
            pessoaService.listarTodos()
                .then((response) => {
                    setPessoas(response.data);
                }).catch((error) => {
                    console.log(error);
                })
        }
    }, [pessoaService, pessoas]);

    useEffect(() => {
        if(pessoaDialog){
            estadoCivilService.listarTodos()
                .then((response) => {
                    setEstadosCivis(response.data);
                }).catch((error) => {
                    console.log(error);
                })
        }
    }, [pessoaDialog]);

    const openNew = () => {
        setPessoa(emptyPessoa);
        setSubmitted(false);
        setPessoaDialog(true);
    };

    const hideDialog = () => {
        setSubmitted(false);
        setPessoaDialog(false);
    };

    const savePessoa = () => {
         if (!pessoa.id){
            pessoaService.inserir(pessoa)
            .then((response) => {
                setPessoaDialog(false);
                setPessoa(emptyPessoa);
                setPessoas(null);
                toast.current?.show({
                    severity: 'info',
                    summary: 'Sucesso!',
                    detail: 'Pessoa cadastrada com sucesso!'  
                })
            }).catch((error) => {
                console.log(error)
                toast.current?.show({
                    severity: 'error',
                    summary: 'Erro!',
                    detail: 'Erro ao salvar pessoa!' + error.response.messege
                    })
            });
        }else{
            pessoaService.alterar(pessoa)
            .then((response) => {
                setPessoaDialog(false);
                setPessoa(emptyPessoa);
                setPessoas(null);
                toast.current?.show({
                    severity: 'info',
                    summary: 'Sucesso!',
                    detail: 'Pessoa alterada com sucesso!'  
                })
            }).catch((error) => {
                console.log(error)
                toast.current?.show({
                    severity: 'error',
                    summary: 'Erro!',
                    detail: 'Erro ao alterar pessoa! ' + error.data.messege  
                })
            });
        }
    };

    const editPessoa = (editPessoa: Crm.Pessoa) => {
        setPessoa({ ...editPessoa });
        setPessoaDialog(true);
    };

    const onInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>, campo: string) => {
        const val = (e.target && e.target.value) || '';
        let _pessoa = { ...pessoa };
        _pessoa[`${campo}`] = val;

        setPessoa(_pessoa);
    };

    const onSelectedChange = (e: Crm.Estado_Civil) => {
        let _pessoa = { ...pessoa };
        _pessoa['estado_CivilId'] = e.id;
        _pessoa['estado_Civil'] = e;

        setPessoa(_pessoa);
     };

    const onBlurCpf = (e) => {
        if (e.target.value != ""){
            pessoaService.BuscarPessoaCpf(e.target.value)
            .then((response) => {
                setPessoa(response.data);
            }).catch((error) => {
                console.log(error)
            });
        }
    }

    const onBlurCep = (e) => {
        if (e.target.value != ""){
            enderecoService.BuscarEnderecoCep(e.target.value)
            .then((response) => {
                let _pessoa = { ...pessoa };
                _pessoa['logradouro'] = response.data.logradouro;                    
                _pessoa['bairro'] = response.data.bairro;
                _pessoa['cidade'] = response.data.cidade;
                _pessoa['uf'] = response.data.uf;
                setPessoa(_pessoa);
            }).catch((error) => {
                console.log(error)
                if(error.response.status == 404){
                    toast.current?.show({
                        severity: 'error',
                        summary: 'Erro!',
                        detail: 'Cep Não encontrado'
                    })
                }
            });
        }
    }

    const leftToolbarTemplate = () => {
        return (
            <React.Fragment>
                <div className="my-2">
                    <Button label="Novo" icon="pi pi-plus" severity="success" className=" mr-2" onClick={openNew} />
                </div>
            </React.Fragment>
        );
    };

    const idBodyTemplate = (rowData: Crm.Pessoa) => {
        return (
            <>
                <span className="p-column-title">Código</span>
                {rowData.id}
            </>
        );
    };

    const nomeBodyTemplate = (rowData: Crm.Pessoa) => {
        return (
            <>
                <span className="p-column-title">Nome</span>
                {rowData.nome}
            </>
        );
    };

    const rgBodyTemplate = (rowData: Crm.Pessoa) => {
        return (
            <>
                <span className="p-column-title">RG</span>
                {rowData.rg}
            </>
        );
    };

    const expBodyTemplate = (rowData: Crm.Pessoa) => {
        return (
            <>
                <span className="p-column-title">Exp.</span>
                {rowData.exp}
            </>
        );
    };

    const cpfBodyTemplate = (rowData: Crm.Pessoa) => {
        return (
            <>
                <span className="p-column-title">CPF</span>
                {rowData.cpf}
            </>
        );
    };

    const emailBodyTemplate = (rowData: Crm.Pessoa) => {
        return (
            <>
                <span className="p-column-title">E-Mail</span>
                {rowData.email}
            </>
        );
    };

    const telefoneBodyTemplate = (rowData: Crm.Pessoa) => {
        return (
            <>
                <span className="p-column-title">Telefone</span>
                {rowData.telefone}
            </>
        );
    };

    const cepBodyTemplate = (rowData: Crm.Pessoa) => {
        return (
            <>
                <span className="p-column-title">CEP</span>
                {rowData.cep}
            </>
        );
    };

    const logradouroBodyTemplate = (rowData: Crm.Pessoa) => {
        return (
            <>
                <span className="p-column-title">Endereço</span>
                {rowData.logradouro}
            </>
        );
    };

    const numeroBodyTemplate = (rowData: Crm.Pessoa) => {
        return (
            <>
                <span className="p-column-title">Número</span>
                {rowData.numero}
            </>
        );
    };

    const complementoBodyTemplate = (rowData: Crm.Pessoa) => {
        return (
            <>
                <span className="p-column-title">Complemento</span>
                {rowData.complemento}
            </>
        );
    };

    const bairroBodyTemplate = (rowData: Crm.Pessoa) => {
        return (
            <>
                <span className="p-column-title">Bairro</span>
                {rowData.bairro}
            </>
        );
    };

    const cidadeBodyTemplate = (rowData: Crm.Pessoa) => {
        return (
            <>
                <span className="p-column-title">Cidade</span>
                {rowData.cidade}
            </>
        );
    };

    const ufBodyTemplate = (rowData: Crm.Pessoa) => {
        return (
            <>
                <span className="p-column-title">UF</span>
                {rowData.uf}
            </>
        );
    };

    const nacionalidadeBodyTemplate = (rowData: Crm.Pessoa) => {
        return (
            <>
                <span className="p-column-title">Nacionalidade</span>
                {rowData.nacionalidade}
            </>
        );
    };

    const profissaoBodyTemplate = (rowData: Crm.Pessoa) => {
        return (
            <>
                <span className="p-column-title">Profissão</span>
                {rowData.profissao}
            </>
        );
    };

    const estadocivilBodyTemplate = (rowData: Crm.Pessoa) => {
        return (
            <>
                <span className="p-column-title">Estado Civil</span>
                {rowData.estado_Civil?.estado}
            </>
        );
    };

    const actionBodyTemplate = (rowData: Crm.Pessoa) => {
        return (
            <>
                <Button icon="pi pi-pencil" rounded severity="success" className="mr-2" onClick={() => editPessoa(rowData)} />
            </>
        );
    };

    const header = (
        <div className="flex flex-column md:flex-row md:justify-content-between md:align-items-center">
            <h5 className="m-0">Cadastro de Pessoas</h5>
            <span className="block mt-2 md:mt-0 p-input-icon-left">
                <i className="pi pi-search" />
                <InputText type="search" onInput={(e) => setGlobalFilter(e.currentTarget.value)} placeholder="Search..." />
            </span>
        </div>
    );

    const pessoaDialogFooter = (
        <>
            <Button label="Cancelar" icon="pi pi-times" text onClick={hideDialog} />
            <Button label="Salvar" icon="pi pi-check" text onClick={savePessoa} />
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
                        value={pessoas}
                        selection={selectedPessoas}
                        onSelectionChange={(e) => setSelectedPessoas(e.value as any)}
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
                        <Column field="nome" header="Nome" sortable body={nomeBodyTemplate} headerStyle={{ minWidth: '15rem' }}></Column>
                        <Column field="rg" header="Rg" sortable body={rgBodyTemplate}  headerStyle={{ minWidth: '10rem' }}></Column>
                        <Column field="exp" header="Exp." sortable body={expBodyTemplate} headerStyle={{ minWidth: '5rem' }}></Column>
                        <Column field="cpf" header="CPF" sortable body={cpfBodyTemplate} headerStyle={{ minWidth: '10rem' }}></Column>
                        <Column field="email" header="E-mail" sortable body={emailBodyTemplate} headerStyle={{ minWidth: '15rem' }}></Column>
                        <Column field="telefone" header="Telefone" sortable body={telefoneBodyTemplate} headerStyle={{ minWidth: '10rem' }}></Column>
                        <Column field="cep" header="CEP" sortable body={cepBodyTemplate} headerStyle={{ minWidth: '5rem' }}></Column>
                        <Column field="logradouro" header="Endereço" sortable body={logradouroBodyTemplate} headerStyle={{ minWidth: '15rem' }}></Column>
                        <Column field="complemento" header="Complemento" sortable body={complementoBodyTemplate} headerStyle={{ minWidth: '10rem' }}></Column>
                        <Column field="numero" header="Número" sortable body={numeroBodyTemplate} headerStyle={{ minWidth: '5rem' }}></Column>
                        <Column field="bairro" header="Bairro" sortable body={bairroBodyTemplate} headerStyle={{ minWidth: '10rem' }}></Column>
                        <Column field="cidade" header="Cidade" sortable body={cidadeBodyTemplate} headerStyle={{ minWidth: '10rem' }}></Column>
                        <Column field="uf" header="Uf" sortable body={ufBodyTemplate} headerStyle={{ minWidth: '5rem' }}></Column>
                        <Column field="nacionalidade" header="Nacionalidade" sortable body={nacionalidadeBodyTemplate} headerStyle={{ minWidth: '10rem' }}></Column>
                        <Column field="profissao" header="Profissão" sortable body={profissaoBodyTemplate} headerStyle={{ minWidth: '10rem' }}></Column>
                        <Column field="estado_Civil" header="Estado Civil" sortable body={estadocivilBodyTemplate} headerStyle={{ minWidth: '10rem' }}></Column>
                    </DataTable>

                    <Dialog visible={pessoaDialog} style={{ width: '450px' }} header="Detalhes da Pessoa" modal className="p-fluid" footer={pessoaDialogFooter} onHide={hideDialog}>
                    <div className="field">
                            <label htmlFor="Cpf">CPF</label>
                            <InputText
                                id="cpf"
                                value={pessoa.cpf}
                                onChange={(e) => onInputChange(e, 'cpf')}
                                onBlur={(e) => onBlurCpf(e)}
                                required
                                autoFocus
                                className={classNames({
                                    'p-invalid': submitted && !pessoa.cpf
                                })}
                            />
                            {submitted && !pessoa.cpf && <small className="p-invalid">Cpf é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Nome">Nome</label>
                            <InputText
                                id="nome"
                                value={pessoa.nome}
                                onChange={(e) => onInputChange(e, 'nome')}
                                required
                                className={classNames({
                                    'p-invalid': submitted && !pessoa.nome
                                })}
                            />
                            {submitted && !pessoa.nome && <small className="p-invalid">Nome é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Rg">RG</label>
                            <InputText
                                id="rg"
                                value={pessoa.rg}
                                onChange={(e) => onInputChange(e, 'rg')}
                                required
                                className={classNames({
                                    'p-invalid': submitted && !pessoa.rg
                                })}
                            />
                            {submitted && !pessoa.rg && <small className="p-invalid">RG é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Exp">Exp.</label>
                            <InputText
                                id="exp"
                                value={pessoa.exp}
                                onChange={(e) => onInputChange(e, 'exp')}
                                required
                                className={classNames({
                                    'p-invalid': submitted && !pessoa.exp
                                })}
                            />
                            {submitted && !pessoa.exp && <small className="p-invalid">Exp é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Telefone">Telefone</label>
                            <InputText
                                id="telefone"
                                value={pessoa.telefone}
                                onChange={(e) => onInputChange(e, 'telefone')}
                                required
                                className={classNames({
                                    'p-invalid': submitted && !pessoa.telefone
                                })}
                            />
                            {submitted && !pessoa.telefone && <small className="p-invalid">telefone é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Email">E-Mail</label>
                            <InputText
                                id="email"
                                value={pessoa.email}
                                onChange={(e) => onInputChange(e, 'email')}
                                required
                                className={classNames({
                                    'p-invalid': submitted && !pessoa.email
                                })}
                            />
                            {submitted && !pessoa.email && <small className="p-invalid">E-Mail é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Cep">CEP</label>
                            <InputText
                                id="cep"
                                value={pessoa.cep}
                                onChange={(e) => onInputChange(e, 'cep')}
                                onBlur={(e) => onBlurCep(e)}
                                required
                                className={classNames({
                                    'p-invalid': submitted && !pessoa.cep
                                })}
                            />
                            {submitted && !pessoa.cep && <small className="p-invalid">Cep é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Endereco">Endereço</label>
                            <InputText 
                                id="logradouro"
                                value={pessoa.logradouro}
                                onChange={(e) => onInputChange(e, 'logradouro')}
                                required
                                disabled
                                className={classNames({
                                    'p-invalid': submitted && !pessoa.logradouro
                                })}
                            />
                            {submitted && !pessoa.logradouro && <small className="p-invalid">Endereço é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Numero">Número</label>
                            <InputText
                                id="numero"
                                value={pessoa.numero}
                                onChange={(e) => onInputChange(e, 'numero')}
                                required
                                className={classNames({
                                    'p-invalid': submitted && !pessoa.numero
                                })}
                            />
                            {submitted && !pessoa.numero && <small className="p-invalid">Número é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Complemento">Complemento</label>
                            <InputText
                                id="complemento"
                                value={pessoa.complemento}
                                onChange={(e) => onInputChange(e, 'complemento')}
                                className={classNames({
                                    'p-invalid': submitted && !pessoa.complemento
                                })}
                            />
                        </div>

                        <div className="field">
                            <label htmlFor="Bairro">Bairro</label>
                            <InputText
                                id="bairro"
                                value={pessoa.bairro}
                                onChange={(e) => onInputChange(e, 'bairro')}
                                required
                                disabled
                                className={classNames({
                                    'p-invalid': submitted && !pessoa.bairro
                                })}
                            />
                            {submitted && !pessoa.bairro && <small className="p-invalid">Bairo é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Cidade">Cidade</label>
                            <InputText
                                id="cidade"
                                value={pessoa.cidade}
                                onChange={(e) => onInputChange(e, 'cidade')}
                                required
                                disabled
                                className={classNames({
                                    'p-invalid': submitted && !pessoa.cidade
                                })}
                            />
                            {submitted && !pessoa.cidade && <small className="p-invalid">Cidade é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Uf">UF</label>
                            <InputText
                                id="uf"
                                value={pessoa.uf}
                                onChange={(e) => onInputChange(e, 'uf')}
                                required
                                disabled
                                className={classNames({
                                    'p-invalid': submitted && !pessoa.uf
                                })}
                            />
                            {submitted && !pessoa.uf && <small className="p-invalid">UF é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Nacionalidade">Nacionalidade</label>
                            <InputText
                                id="nacionalidade"
                                value={pessoa.nacionalidade}
                                onChange={(e) => onInputChange(e, 'nacionalidade')}
                                required
                                className={classNames({
                                    'p-invalid': submitted && !pessoa.nacionalidade
                                })}
                            />
                            {submitted && !pessoa.nacionalidade && <small className="p-invalid">Nacionalidade é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Profissao">Profissão</label>
                            <InputText
                                id="profissao"
                                value={pessoa.profissao}
                                onChange={(e) => onInputChange(e, 'profissao')}
                                required
                                className={classNames({
                                    'p-invalid': submitted && !pessoa.profissao
                                })}
                            />
                            {submitted && !pessoa.profissao && <small className="p-invalid">Profissão é obrigatório.</small>}
                        </div>

                        <div className="field">
                            <label htmlFor="Estado_Civil">Estado Civil</label>
                            <Dropdown 
                                id="estado_Civil"
                                value={pessoa.estado_Civil} 
                                onChange={(e: DropdownChangeEvent) => onSelectedChange(e.value)}
                                options={estadosCivis} 
                                optionLabel="estado"
                                placeholder="Selecione o estado civil" 
                                required 
                                className={classNames({
                                    'p-invalid': submitted && !pessoa.estado_Civil
                                })}
                            />
                            {submitted && !pessoa.estado_Civil && <small className="p-invalid">Estado civil é obrigatório.</small>}
                        </div>
                    </Dialog>
                </div>
            </div>
        </div>
    );
};

export default Pessoa;