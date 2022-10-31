USE CONTROLECAIXA
GO

INSERT INTO lancamento(Identificador,codigoLancamento,finalidade,tipodc,DataHoraCriacao)
VALUES(NEWID(),1010,'Venda a Crédito','C',GETDATE())

INSERT INTO lancamento(Identificador,codigoLancamento,finalidade,tipodc,DataHoraCriacao)
VALUES(NEWID(),1020,'Venda a Débito','D',GETDATE())

INSERT INTO lancamento(Identificador,codigoLancamento,finalidade,tipodc,DataHoraCriacao)
VALUES(NEWID(),1015,'Prestação de serviço','C',GETDATE())

INSERT INTO lancamento(Identificador,codigoLancamento,finalidade,tipodc,DataHoraCriacao)
VALUES(NEWID(),1030,'Pagamento de Boleto','D',GETDATE())

INSERT INTO lancamento(Identificador,codigoLancamento,finalidade,tipodc,DataHoraCriacao)
VALUES(NEWID(),1035,'Recebimento de Parcelamento','C',GETDATE())

SELECT * FROM lancamento
