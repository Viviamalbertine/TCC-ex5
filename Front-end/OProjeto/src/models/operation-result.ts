//
//@Estrutura utilizada para representar os dados de uma operação qualquer, incluindo a operação de autenticação.
//
export interface OperationResult {
    success?: boolean;
    code?: string;
    message?: string;
}
