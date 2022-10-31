USE CONTROLECAIXA
GO

INSERT INTO Movimento (Identificador,Valor,DataMovimento,LancamentoId)
values(NEWID(), 154.25, '2022-10-01','7452DBF7-3093-4C8E-9BCA-53062330E8F6')

INSERT INTO Movimento (Identificador,Valor,DataMovimento,LancamentoId)
values(NEWID(), 4654.77, '2022-10-02','7452DBF7-3093-4C8E-9BCA-53062330E8F6')

INSERT INTO Movimento (Identificador,Valor,DataMovimento,LancamentoId)
values(NEWID(), 6465.25, '2022-10-03','AFE44EA8-F954-4C83-B36E-63EE704776C5')

INSERT INTO Movimento (Identificador,Valor,DataMovimento,LancamentoId)
values(NEWID(), 6465.25, '2022-10-05','6B14CD71-9428-49E4-A020-7D08E5013735')

INSERT INTO Movimento (Identificador,Valor,DataMovimento,LancamentoId)
values(NEWID(), 32423.25, '2022-10-01','7452DBF7-3093-4C8E-9BCA-53062330E8F6')

INSERT INTO Movimento (Identificador,Valor,DataMovimento,LancamentoId)
values(NEWID(), 53453.77, '2022-10-02','6103AC53-6A09-41E6-A98E-DA1F5F018E57')

INSERT INTO Movimento (Identificador,Valor,DataMovimento,LancamentoId)
values(NEWID(), 34523.25, '2022-10-03','6103AC53-6A09-41E6-A98E-DA1F5F018E57')

INSERT INTO Movimento (Identificador,Valor,DataMovimento,LancamentoId)
values(NEWID(), 34523.25, '2022-10-05','9AE223AD-F241-47DF-A8A2-9C93DA9940D3')



select * from Movimento
